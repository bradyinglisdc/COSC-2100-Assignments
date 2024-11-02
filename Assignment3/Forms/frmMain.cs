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

        private void CreateCharacterPanels(int characterPage)

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
