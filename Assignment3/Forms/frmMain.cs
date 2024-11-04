/*
 * Title: frmMain.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-02
 * Purpose: The main form where users are given the ability to view and choose to edit characters.
 */

#region Namespaces Used

using Assignment3.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

#region Namespace Definition

namespace Assignment3
{
    /// <summary>
    /// This class serves as the interface between the user and each d&d character.
    /// It provides them with the option to create, edit, and view each character.
    /// </summary>
    public partial class frmMain : Form
    {
        #region Styling Constants/Styling Instance Variables

        private const int CharacterPanelXPosition = 147;
        private const int CharacterYPositionSpacing = 70;
        private const int margin = 20;

        private static Font DefaultCharacterPanelFont = new Font("Algerian", 12, FontStyle.Regular);
        private static Color DefaultCharacterFontColour = Color.Black;

        private static Font SelectedCharacterPanelFont = new Font("Algerian", 14, FontStyle.Underline);
        private static Color SelectedCharacterFontColour = Color.Red;

        private int CharacterPanelStartingYPosition { get; set; }

        #endregion


        #region Backing Instance Members/Variables

        /// <summary>
        /// The current page index of characters to show.
        /// </summary>
        private int _currentPage = 1;

        /// <summary>
        /// The name of the character which is currently selected.
        /// </summary>
        private string? _selectedCharacter;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets the currently selected character.
        /// Sets the currently selected character to value and
        /// automatically updates front-end.
        /// </summary>
        private string? SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                ChangeSelectedCharacter(value);
                _selectedCharacter = value;
                DisplaySelectedCharacterStats();

            }
        }

        /// <summary>
        /// Becomes true when all characters of a page are loaded.
        /// </summary>
        bool PageLoaded = false;

        /// <summary>
        /// A list of characters corresponding with the current page.
        /// </summary>
        private List<Panel> CharacterPanels = new List<Panel>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - This class only contains a single no parameter constructor,
        /// as it is only to be instantiated when the user bridges from the splash page.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        #region Visual Interaction

        /// <summary>
        /// To be called when mouse hover begins on character creator access button or exit button. Visually indicates hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneric_MouseEnter(object sender, EventArgs e)
        {
            IndicateHoverOnButton((Button)sender);
        }

        /// <summary>
        /// To be called when mouse hover ends on character creator access button or exit. Visually indicates end of hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneric_MouseLeave(object sender, EventArgs e)
        {
            IndicateHoverEndOnButton((Button)sender);
        }

        #endregion

        #region Character Interaction

        /// <summary>
        /// To be called when the form first loads - Sets styling variables then communicates with back-end to load default 
        /// game objects and pull the first page of characters. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            CharacterPanelStartingYPosition = lblCharacterStatsHeader.Location.Y + margin;
            Driver.InstantiateDefaultGameObjects();
            LoadCharacterPanelsByPage(sender, e);
        }

        /// <summary>
        /// To be called when a character panel is clicked. Selects that panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterPanel_Click(object? sender, EventArgs e)
        {
            if (sender is Panel) { SelectedCharacter = ((Panel)sender).Name; }
        }

        /// <summary>
        /// Instantiates and opens a new frmCharacterEditor. 
        /// Since no character is requied, the default constructor is used.
        /// The form is opened as a dialog in order to take priority over the current form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCharacter_Click(object sender, EventArgs e)
        {
            PageLoaded = false;
            (new frmCharacterEditor()).ShowDialog();
        }

        /// <summary>
        /// Instantiates and opens a new frmCharacterEditor. 
        /// Since a character is requied, the parameterized constructor is used.
        /// The form is opened as a dialog in order to take priority over the current form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditCharacter_Click(object sender, EventArgs e)
        {
            if (SelectedCharacter == null) { return; }
            PageLoaded = false;

            Character? characterToEdit = Character.FindByName(SelectedCharacter);
            if (characterToEdit != null)
            {
                frmCharacterEditor characterEditor = new frmCharacterEditor(characterToEdit);
                characterEditor.ShowDialog();
            }
        }

        /// <summary>
        /// Deletes the currently selected character if user agrees to prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCharacter_Click(object sender, EventArgs e)
        {
            if (SelectedCharacter != null && MessageBox.Show($"Are you sure you want to delete {SelectedCharacter}? This cannot be undone.", $"Delete {SelectedCharacter}?",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteCharacter();
            }
        }

        /// <summary>
        /// Adds one to the current page, then re loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            _currentPage += 1;
            LoadPage();
        }

        /// <summary>
        /// Subtracts one from current page, then re loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPage - 1 != 0)
            {
                _currentPage -= 1;
                LoadPage();
            }
        }

        #endregion

        #region Descriptions

        /// <summary>
        /// Opens new form to display full class description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClassDescription_Click(object sender, EventArgs e)
        {
            if (SelectedCharacter == null) { return; }
            Character? currentCharacter = Character.FindByName(SelectedCharacter);

            if (currentCharacter == null || currentCharacter.Class == null) { return; }
            (new frmGenericDescriptor(currentCharacter.Class.Description)).Show();
        }

        /// <summary>
        /// Opens new form to display full race description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRaceDescription_Click(object sender, EventArgs e)
        {
            if (SelectedCharacter == null) { return; }
            Character? currentCharacter = Character.FindByName(SelectedCharacter);

            if (currentCharacter == null || currentCharacter.Race == null || currentCharacter.Race.Description == null) { return; }
            (new frmGenericDescriptor(currentCharacter.Race.Description)).Show();
        }

        /// <summary>
        /// Opens a new form to display full attribute description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewAttributes_Click(object sender, EventArgs e)
        {
            if (SelectedCharacter == null) { return; }
            Character? currentCharacter = Character.FindByName(SelectedCharacter);

            if (currentCharacter == null){ return; }
            (new frmGenericDescriptor(currentCharacter.GetFormattedAttributes())).Show();
        }

        #endregion

        #region Cleanup

        /// <summary>
        /// Prompts user, closes form if they confirm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit? None of your characters will save.", "Exit application?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
            }
        }

        /// <summary>
        /// Exits application on form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #endregion

        #region Setup Methods

        /// <summary>
        /// Initializes 5 character labels based on the current page number, selecting
        /// the first character in that page automatically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadCharacterPanelsByPage(object sender, EventArgs e)
        {
            if (!PageLoaded)
            {
                SelectedCharacter = string.Empty;
                LoadPage();
            }
        }

        /// <summary>
        /// Load the current page of characters
        /// </summary>
        private void LoadPage()
        {
            // Grab character page and clear current panel list.
            List<Character> characterPage = Character.GetPage(_currentPage);
            if (characterPage.Count <= 0)
            {
                _currentPage -= 1;
                return;
            }

            ClearCharacterPanels();

            // Load and style the panels
            CreateCharacterPanels(characterPage);

            // Set the selected character to the first character of the page to begin with, and indicate that page is now loaded.
            if (characterPage.Count > 0) { SelectedCharacter = characterPage[0].Name; }
            PageLoaded = true;
        }

        /// <summary>
        /// Instantiates and styles new Panels for each character to display
        /// </summary>
        /// <param name="characterPage">List of characters to display</param>
        private void CreateCharacterPanels(List<Character> characterPage)
        {
            // The Y position of the current character panel, to be added to as each panel is added.
            int yPosition = CharacterPanelStartingYPosition;

            foreach (Character character in characterPage)
            {
                CreateCharacterPanel(character, yPosition);
                yPosition += CharacterYPositionSpacing;
            }
        }

        private void CreateCharacterPanel(Character character, int yPosition)
        {
            // Instantiating each control
            Panel pnlCurrent = new Panel();
            PictureBox pbxClassIconLeft = new PictureBox();
            Label lblCharacterName = new Label();
            PictureBox pbxClassIconRight = new PictureBox();

            // Styling the panel
            pnlCurrent.Width = Width / 2 - (margin * 5);
            pnlCurrent.Height = 60;
            pnlCurrent.BackColor = Color.White;
            pnlCurrent.Location = new Point(CharacterPanelXPosition, yPosition);
            pnlCurrent.BorderStyle = BorderStyle.FixedSingle;
            pnlCurrent.Name = character.Name;

            // Styling the name label
            lblCharacterName.Text = character.Name;
            lblCharacterName.Font = DefaultCharacterPanelFont;
            lblCharacterName.Size = new Size(pnlCurrent.Width - 110, pnlCurrent.Height);
            lblCharacterName.Location = new Point(pnlCurrent.Width / 2 - lblCharacterName.Width / 2);
            lblCharacterName.TextAlign = ContentAlignment.MiddleCenter;

            // If a class cannot be found, do not attempt to create picture boxes for this character.
            if (character.Class == null) { return; }

            // Styling the left class icon
            pbxClassIconLeft.Load(character.Class.ClassSymbolURI);
            pbxClassIconLeft.Size = new Size(50, 50);
            pbxClassIconLeft.Location = new Point(lblCharacterName.Location.X - pbxClassIconLeft.Width, 5);
            pbxClassIconLeft.SizeMode = PictureBoxSizeMode.StretchImage;

            // Styling the right class icon
            pbxClassIconRight.Load(character.Class.ClassSymbolURI);
            pbxClassIconRight.Size = new Size(50, 50);
            pbxClassIconRight.Location = new Point(lblCharacterName.Location.X + lblCharacterName.Width, 5);
            pbxClassIconRight.SizeMode = PictureBoxSizeMode.StretchImage;

            // Adding controls
            pnlCurrent.Controls.Add(lblCharacterName);
            pnlCurrent.Controls.Add(pbxClassIconLeft);
            pnlCurrent.Controls.Add(pbxClassIconRight);
            Controls.Add(pnlCurrent);
            pnlCurrent.BringToFront();

            // Add the panel to the list of current panels and subscribe to click event
            CharacterPanels.Add(pnlCurrent);
            pnlCurrent.Click += CharacterPanel_Click;
            lblCharacterName.Click += (sender, eventArgs) => { CharacterPanel_Click(pnlCurrent, eventArgs); };
            pbxClassIconLeft.Click += (sender, eventArgs) => { CharacterPanel_Click(pnlCurrent, eventArgs); };
            pbxClassIconRight.Click += (sender, eventArgs) => { CharacterPanel_Click(pnlCurrent, eventArgs); };
        }

        #endregion

        #region Character Interaction

        /// <summary>
        /// Deselects the current character and selects the new one.
        /// </summary>
        /// <param name="characterToSelect">The character which should be focused.</param>
        private void ChangeSelectedCharacter(string? characterToSelect)
        {
            // If the character is already selected, just return
            if (characterToSelect == SelectedCharacter) { return; }

            // Search through current panels. If the selected panel is found, deselect. If the panel to select is found, select.
            foreach (Panel characterPanel in CharacterPanels)
            {
                if (characterPanel.Name == SelectedCharacter) { DeselectCharacter(characterPanel); }
                else if (characterPanel.Name == characterToSelect) { SelectCharacter(characterPanel); }
            }
        }

        /// <summary>
        /// Searches through the character panel's controls. If a label is found, that label
        /// is set to the default character label font.
        /// </summary>
        /// <param name="characterToDeselect"></param>
        private void DeselectCharacter(Panel characterToDeselect)
        {
            foreach (Control control in characterToDeselect.Controls)
            {
                if (control is Label)
                {
                    Label characterLabel = (Label)control;
                    characterLabel.Font = DefaultCharacterPanelFont;
                    characterLabel.ForeColor = DefaultCharacterFontColour;
                    characterLabel.Text = SelectedCharacter;
                }

            }
        }

        /// <summary>
        /// Searches through the character panel's controls. If a label is found, that label
        /// is set to the default character label font.
        /// </summary>
        /// <param name="characterToDeselect"></param>
        private void SelectCharacter(Panel characterToDeselect)
        {
            foreach (Control control in characterToDeselect.Controls)
            {
                if (control is Label)
                {
                    Label characterLabel = (Label)control;
                    characterLabel.Font = SelectedCharacterPanelFont;
                    characterLabel.ForeColor = SelectedCharacterFontColour;
                    characterLabel.Text = "> " + characterLabel.Text + " <";
                }
            }
        }

        /// <summary>
        /// Updates the front-end to reflect character data.
        /// </summary>
        private void DisplaySelectedCharacterStats()
        {
            // Find the corresponding character if the selected character exists
            if (SelectedCharacter == null) { return; }
            Character? characterToDisplay = Character.FindByName(SelectedCharacter);

            // Return if this character has no race/class
            if (characterToDisplay == null || characterToDisplay.Class == null || characterToDisplay.Race == null) { return; }

            // Update all character info
            lblGender.Text = $"Gender: {characterToDisplay.Gender}";
            lblAlignment.Text = $"Alignment: {characterToDisplay.Alignment.ToString()}";
            lblInitiative.Text = $"Initiative: {characterToDisplay.Initiatve}";
            lblArmourClass.Text = $"Armour Class: {characterToDisplay.ArmourClass}";
            lblHitPoints.Text = $"Hit Points: {characterToDisplay.HitPoints}";
            lblSpeed.Text = $"Speed: {characterToDisplay.Speed}";

            lblLevel.Text = $"Level: {characterToDisplay.Level}";
            lblExperiencePoints.Text = $"Experience Points: {characterToDisplay.ExperiencePoints}";

            lblClass.Text = $"Class: {characterToDisplay.Class.Name}";
            lblClassHPDice.Text = $"HP Dice: {characterToDisplay.Class.HPDice}";

            lblRace.Text = $"Race: {characterToDisplay.Race.Name}";
        }

        /// <summary>
        /// Deletes the currently selected character from display and memory
        /// </summary>
        private void DeleteCharacter()
        {
            if (SelectedCharacter == null) { return; }
            Control[] panelsToRemove = Controls.Find(SelectedCharacter, false);

            // Remove from panel list and controls
            if (panelsToRemove.Length > 0) { CharacterPanels.Remove((Panel)panelsToRemove[0]); }
            Controls.RemoveByKey(SelectedCharacter);
            Character.Delete(SelectedCharacter);

            // Reselect last character if it exists, else select none
            SelectedCharacter = CharacterPanels.Count <= 0 ? null : CharacterPanels[CharacterPanels.Count - 1].Name;
        }

        #endregion

        #region Dynamic Styling

        /// <summary>
        /// Expands and changes a button's font to red to indicate a mouse hover.
        /// </summary>
        /// <param name="btnToStyle">The button to style.</param>
        private void IndicateHoverOnButton(Button btnToStyle)
        {
            // Simply update the button size to indicate a hover and re adjust positioning
            btnToStyle.Size = new Size(btnToStyle.Width + 8, btnToStyle.Height + 8);
            btnToStyle.Location = new Point(btnToStyle.Location.X - 4, btnToStyle.Location.Y - 4);

            // Update font colour to red
            btnToStyle.ForeColor = Color.Red;
        }

        /// <summary>
        /// Shrinks and changes a button's font to black to indicate a mouse hover end.
        /// </summary>
        /// <param name="btnToStyle">The button to style.</param>
        private void IndicateHoverEndOnButton(Button btnToStyle)
        {
            // Simply update the button size to indicate a hover and re adjust positioning
            btnToStyle.Size = new Size(btnToStyle.Width - 8, btnToStyle.Height - 8);
            btnToStyle.Location = new Point(btnToStyle.Location.X + 4, btnToStyle.Location.Y + 4);

            // Update font colour to black
            btnToStyle.ForeColor = Color.Black;
        }

        #endregion

        #region Cleanup

        private void ClearCharacterPanels()
        {
            foreach (Panel panel in CharacterPanels) { Controls.Remove(panel); }
            CharacterPanels.Clear();
        }

        #endregion
    }
}

#endregion
