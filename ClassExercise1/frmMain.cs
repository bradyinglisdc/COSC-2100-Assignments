/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: The purpose of this class is to provide the main back-end logic for
 * displaying MainMenuPanel, as well as any playable games.
 */

# region Namespaces Used
using System;
using System.Windows.Forms;
#endregion

#region Namespace Definiton
namespace ClassExercise1
{
    #region Class Definition
    public partial class frmMain : Form
    {
        #region Backing fields
        private MainMenuPanel _pnlMainMenu;
        #endregion

        #region Properties
        public MainMenuPanel pnlMainMenu
        {
            get
            {
                return _pnlMainMenu;
            }
            set
            {
                _pnlMainMenu = value;
                Controls.Add(value);
            }
        }
        #endregion

        #region Constructor(s)
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Methods
        /// <summary>
        /// Called on form load event.
        /// Calls method to initialize the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Setup the main menu
            InitializeMenu();
        }
        #endregion

        #region Form Setup Methods
        /// <summary>
        /// Simply initializes main menu.
        /// </summary>
        private void InitializeMenu()
        {
            // Insatioate and add main menu to form controls
            pnlMainMenu = new MainMenuPanel(Height);
        }
        #endregion

        #region Game Change Logic Methods
        /// <summary>
        /// Switches to specified game.
        /// </summary>
        /// <param name="gameName">Game to change to.</param>
        public void ChangeGame(string gameName)
        {
            // Firstly, minimize menu
            pnlMainMenu.MinimizePanel();
        }
        #endregion




    }
    #endregion
}
#endregion