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
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public partial class frmMain : Form
    {
        #region Properties
        public MainMenuPanel pnlMainMenu { get; set; }
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
            DefineControls();
        }

        /// <summary>
        /// Defines each control, adds to parent control/form
        /// </summary>
        private void DefineControls()
        {
            #region Main Menu
            pnlMainMenu = new MainMenuPanel();
            this.Controls.Add(pnlMainMenu);
            pnlMainMenu.StyleControls(); 
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
