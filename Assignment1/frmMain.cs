/*
 * Title: frmMain
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-23
 * Purpose: This is the parent form where each control for the program will be placed.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public partial class frmMain : Form
    {
        #region Backing Data Members
        private MainMenuPanel _pnlMainMenu;
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets main menu panel for the application.
        /// When setter is called, controls will be cleared and
        /// the new main menu value will replace any other controls.
        /// </summary>
        public MainMenuPanel pnlMainMenu
        {
            get { return _pnlMainMenu; }
            set
            {
                this._pnlMainMenu = value;
                this.Controls.Clear();
                this.Controls.Add(value);
                this._pnlMainMenu.StyleControls();
                this._pnlMainMenu.StyleControls();
            }
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Constructor for the main form.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            SetupControls();
            SubscribeEventListeners();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Defines and styles each control for this form
        /// </summary>
        private void SetupControls()
        {
            #region Main Menu
            pnlMainMenu = new MainMenuPanel();
            #endregion
        }

        /// <summary>
        /// Subscribes event listeners for each control
        /// </summary>
        private void SubscribeEventListeners()
        {
            this.Resize += RestyleControls;
        }
        #endregion

        #region General Methods
        /// <summary>
        /// Restyles whichever panel control isn't null
        /// </summary>
        private void RestyleControls(object sender, EventArgs e)
        {
            if (pnlMainMenu != null) { pnlMainMenu.StyleControls(); }
        }
        #endregion
    }

    #endregion
}
#endregion
