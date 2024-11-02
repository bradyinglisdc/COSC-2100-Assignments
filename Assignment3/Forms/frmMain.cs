/*
 * Title: frmMain.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-02
 * Purpose: The main form where users are given the ability to view and choose to edit characters.
 */

#region Namespaces Used

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
            set { if (value != null) { ChangeSelectedCharacter(value); } }
        }

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

        /// <summary>
        /// To be called when the form first loads - communicates with back-end to load default 
        /// game objects and pull the first page of characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            Driver.InstantiateDefaultGameObjects();
            LoadCharacterPanelsByPage();
        }

        #endregion

        #region Setup Methods

        /// <summary>
        /// Initializes 5 character labels based on the current page number, selecting
        /// the first character in that page automatically.
        /// </summary>
        private void LoadCharacterPanelsByPage()
        {
            // Grab character page and clear current panel list.
            List<Character> characterPage = Character.GetPage(_currentPage);
            CharacterPanels.Clear();

            // Load and style the panels
            CreateCharacterPanels(characterPage);


        }

        /// <summary>
        /// Instantiates and styles new Panels for each character to display
        /// </summary>
        /// <param name="characterPage">List of characters to display</param>
        private void CreateCharacterPanels(List<Character> characterPage)
        {
            // The height and width where the first panel should start, and other sizing variables
            int margin = 20;
            int startingX = 147;
            int startingY = lblCharacterStatsHeader.Location.Y + margin;

            foreach (Character character in characterPage)
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
                pnlCurrent.Location = new Point(startingX, startingY);
                pnlCurrent.BorderStyle = BorderStyle.FixedSingle;

                // Styling the name label
                lblCharacterName.Text = character.Name;
                lblCharacterName.Font = new Font("Algerian", 12, FontStyle.Regular);
                lblCharacterName.Size = new Size(pnlCurrent.Width / 2, pnlCurrent.Height);
                lblCharacterName.Location = new Point(pnlCurrent.Width / 2 - lblCharacterName.Width / 2);
                lblCharacterName.TextAlign = ContentAlignment.MiddleCenter;

                // If a class cannot be found, do not attempt to create picture boxes for this character.
                if (character.Class == null) { continue; }

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
                pbxClassIconLeft.BringToFront();
                pbxClassIconRight.BringToFront();

                startingY += 78;
            }
        }

        #endregion

        #region Character Interaction

        /// <summary>
        /// Deselects the current character and selects the new one.
        /// </summary>
        /// <param name="characterToSelect">The character which should be focused.</param>
        private void ChangeSelectedCharacter(string characterToSelect)
        {

        }

        #endregion
    }
}

#endregion
