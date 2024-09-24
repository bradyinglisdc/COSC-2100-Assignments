/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-23
 * Purpose: This class represents the main menu for this application. It defines, styles, and
 * adds logic to the the main menu's controls
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public class MainMenuPanel : Panel
    {
        #region Properties
        public Label lblMenuHeader { get; set; }
        public Button btnStartHumanVsHuman { get; set; }
        public Button btnStartHumanVsAI { get; set; }
        public Button btnExitGame { get; set; }
        public int[] ParentControlDimensions { get; set; }
        #endregion

        #region Consructor(s)
        /// <summary>
        /// Main menu constructor simply instantiates, adds logic to, and styles all child controls
        /// </summary>
        public MainMenuPanel()
        {
            InstantiateControls();
            SubscribeEventHandlers();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds the main menu child controls
        /// </summary>
        private void InstantiateControls()
        {
            // Control Definitions
            lblMenuHeader = new Label();
            btnStartHumanVsHuman = new Button();
            btnStartHumanVsAI = new Button();
            btnExitGame = new Button();

            // Add to controls to collection of controls
            this.Controls.Add(lblMenuHeader);
            this.Controls.Add(btnStartHumanVsHuman);
            this.Controls.Add(btnStartHumanVsAI);
            this.Controls.Add(btnExitGame);
        }

        /// <summary>
        /// Adds event handlers to each control
        /// </summary>
        private void SubscribeEventHandlers()
        {
            btnStartHumanVsHuman.Click += new EventHandler(btnStartHumanVsHuman_Click);

        }

        /// <summary>
        /// Styles the child controls. This method is called after the main menu is instantiated
        /// to accurately use the parent form's properties
        /// </summary>
        public void StyleControls()
        {
            // Ensure parent control exists
            if (Parent == null) { return; }

            // If parent exists, change ParentControlDimensions to reflect parent dimensions and grab centres for styling
            ParentControlDimensions = new int[] { Parent.Width, Parent.Height };
            int horizontalCentre = ParentControlDimensions[0] / 2;
            int verticalCentre = ParentControlDimensions[1] / 2;

            #region Panel Styling
            this.Width = ParentControlDimensions[0];
            this.Height = ParentControlDimensions[1];
            #endregion

            #region lblMenuHeader Styling
            lblMenuHeader.Text = "Tic Tac Toe";
            lblMenuHeader.ForeColor = Color.FromArgb(0, 200, 0);
            lblMenuHeader.Width = Parent.Width;
            lblMenuHeader.Height = verticalCentre / 2;
            lblMenuHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblMenuHeader.Font = new Font("Segoe UI", 30);
            lblMenuHeader.Location = new Point(horizontalCentre - lblMenuHeader.Width / 2, verticalCentre / 4);
            #endregion


            #region btnStartHumanVsHumn Styling
            btnStartHumanVsHuman.Text = "Human Vs Human";
            btnStartHumanVsHuman.BackColor = Color.FromArgb(190, 190, 190);
            btnStartHumanVsHuman.Width = horizontalCentre;
            btnStartHumanVsHuman.Height = 25;
            btnStartHumanVsHuman.Location = new Point(horizontalCentre - btnStartHumanVsHuman.Width / 2, verticalCentre - btnStartHumanVsHuman.Height);
            #endregion

            #region btnStartHumanVsAI Styling
            btnStartHumanVsAI.Text = "Human Vs AI";
            btnStartHumanVsAI.BackColor = Color.FromArgb(190, 190, 190);
            btnStartHumanVsAI.Width = horizontalCentre;
            btnStartHumanVsAI.Height = 25;
            btnStartHumanVsAI.Location = new Point(horizontalCentre - btnStartHumanVsHuman.Width / 2, verticalCentre);
            #endregion

            #region btnStartHumanVsAI Styling
            btnExitGame.Text = "Exit Game";
            btnExitGame.BackColor = Color.FromArgb(190, 190, 190);
            btnExitGame.Width = horizontalCentre / 2;
            btnExitGame.Height = 25;
            btnExitGame.Location = new Point(horizontalCentre - btnExitGame.Width / 2, verticalCentre + btnExitGame.Height);
            #endregion
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// All event handler methods defined here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartHumanVsHuman_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
    #endregion
}
#endregion
