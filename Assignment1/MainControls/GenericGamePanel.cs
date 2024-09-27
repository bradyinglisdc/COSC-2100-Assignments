/*
 * Title: GenericGamePanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-24
 * Purpose: This class represents a generic game panel for all tic tac toe panel's to inherit.
 * This allows each game Panel to implicitly come with specific properties and methods, such as returning
 * to the main menu.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public class GenericGamePanel : Panel
    {
        #region Properties
        public Button btnExitToMenu { get; set; }
        public ToolTip ToolTips { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Instantiates and adds logic to all Properties child should come with, also calls Panel constructor
        /// </summary>
        public GenericGamePanel() : base()
        {
            InstantiateControls();
            SubscribeEventHandlers();
            StyleControls();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds all generic controls. Should be overridden in child class
        /// to instantiate new controls.
        /// </summary>
        private void InstantiateControls()
        {
            // Control Definitions
            btnExitToMenu = new Button();
            ToolTips = new ToolTip();

            // Add to controls to collection of controls
            this.Controls.Add(btnExitToMenu);
        }

        /// <summary>
        /// Adds event handlers to each generic control. Should be overridden in child class
        /// </summary>
        private void SubscribeEventHandlers()
        {
            btnExitToMenu.Click += new EventHandler(btnExitToMenu_Click);
        }

        /// <summary>
        /// Styles the child controls.
        /// </summary>
        private void StyleControls()
        {
            #region btnExitToMenu Styling
            ToolTips.SetToolTip(btnExitToMenu, "Click here, or press Alt + X to return to Main menu");
            btnExitToMenu.Text = "&X";
            btnExitToMenu.BackColor = Color.FromArgb(255, 255, 255);
            btnExitToMenu.ForeColor = Color.Red;
            btnExitToMenu.Font = new Font("Courier New", 15);
            btnExitToMenu.Width = 30;
            btnExitToMenu.Height = 30;
            btnExitToMenu.Location = new Point(0, 0);
            #endregion
        }
        #endregion

        #region Event handler methods
        /// <summary>
        /// Returns to main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnExitToMenu_Click(object sender, EventArgs e)
        {
            // Ensure parent exists and is the main form
            if (Parent == null || !(Parent is frmMain)) { return; }

            // Provided parent exists, add a new main menu
            frmMain parent = (frmMain)Parent;
            parent.pnlMainMenu = new MainMenuPanel();
        }

        /// <summary>
        /// Returns to main menu after prompting user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnExitToMenuConfirmation_Click(object sender, EventArgs e)
        {
            // If user confirms they want to exit, then exit
            if (MessageBox.Show("Are you sure you want to exit to the main menu? Your game progress," +
                "including all scores will be lost.", "Exit Game?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                btnExitToMenu_Click(sender, e);
            }
        }
        #endregion
    }
    #endregion
}
#endregion
