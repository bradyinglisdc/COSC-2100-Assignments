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
        private int[] ParentControlDimensions { get; set; }
        private Label lblMenuHeader { get; set; }
        private Button btnStartHumanVsHuman { get; set; }
        private Button btnStartHumanVsAI { get; set; }
        private Button btnExitGame { get; set; }
        private ToolTip ToolTips { get; set; }
        #endregion

        #region Consructor(s)
        /// <summary>
        /// Main menu constructor simply instantiates, adds logic to, and styles all child controls
        /// </summary>
        public MainMenuPanel() : base()
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
            ToolTips = new ToolTip();

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
            btnStartHumanVsAI.Click += new EventHandler(btnStartHumanVsAI_Click);
            btnExitGame.Click += new EventHandler(btnExitGame_Click);
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
            lblMenuHeader.Width = 282;
            lblMenuHeader.Height = 46;
            lblMenuHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblMenuHeader.Font = new Font("Courier New", 30, FontStyle.Underline);
            lblMenuHeader.Location = new Point(horizontalCentre - lblMenuHeader.Width / 2, verticalCentre / 2);
            #endregion

            #region btnStartHumanVsHuman Styling
            ToolTips.SetToolTip(btnStartHumanVsHuman, "To start a Human Vs Human Tic Tac Toe game, click here, or press Alt + H");
            btnStartHumanVsHuman.TabIndex = 0;
            btnStartHumanVsHuman.Text = "Human Vs &Human";
            btnStartHumanVsHuman.BackColor = Color.FromArgb(255, 255, 255);
            btnStartHumanVsHuman.ForeColor = Color.FromArgb(0, 100, 0);
            btnStartHumanVsHuman.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnStartHumanVsHuman.Width = horizontalCentre;
            btnStartHumanVsHuman.Height = 30;
            btnStartHumanVsHuman.Location = new Point(horizontalCentre - btnStartHumanVsHuman.Width / 2, lblMenuHeader.Location.Y + lblMenuHeader.Height * 2);
            btnStartHumanVsHuman.MaximumSize = new Size(500, 30);
            btnStartHumanVsHuman.Focus();
            #endregion

            #region btnStartHumanVsAI Styling
            ToolTips.SetToolTip(btnStartHumanVsAI, "To start a Human Vs AI Tic Tac Toe game, click here, or press Alt + A");
            btnStartHumanVsAI.TabIndex = 1;
            btnStartHumanVsAI.Text = "Human Vs &AI";
            btnStartHumanVsAI.BackColor = Color.FromArgb(255, 255, 255);
            btnStartHumanVsAI.ForeColor = Color.FromArgb(0, 100, 0);
            btnStartHumanVsAI.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnStartHumanVsAI.Width = horizontalCentre;
            btnStartHumanVsAI.Height = 30;
            btnStartHumanVsAI.Location = new Point(horizontalCentre - btnStartHumanVsHuman.Width / 2, btnStartHumanVsHuman.Location.Y + btnStartHumanVsHuman.Height);
            btnStartHumanVsAI.MaximumSize = new Size(500, 30);
            #endregion

            #region btnExitGame Styling
            ToolTips.SetToolTip(btnExitGame, "To exit the application, click here, or press Alt + X");
            btnExitGame.TabIndex = 2;
            btnExitGame.Text = "E&xit Game";
            btnExitGame.BackColor = Color.FromArgb(255, 255, 255);
            btnExitGame.ForeColor = Color.FromArgb(0, 100, 0);
            btnExitGame.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnExitGame.Width = horizontalCentre / 2;
            btnExitGame.Height = 30;
            btnExitGame.Location = new Point(horizontalCentre - btnExitGame.Width / 2, btnStartHumanVsAI.Location.Y + btnStartHumanVsAI.Height);
            btnExitGame.MaximumSize = new Size(300, 30);
            #endregion
        }
        #endregion
        
        #region Event Handlers
        /// <summary>
        /// Start a new HumanVsHuman game on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartHumanVsHuman_Click(object sender, EventArgs e)
        {
            // Ensure parent exists and is frmMain
            if (Parent == null || !(Parent is frmMain)) { return; }

            // Set parent control to a new instance of the HumanVsHuman panel
            ((frmMain)Parent).pnlHumanVsHuman = new HumanVsHumanPanel();
        }

        /// <summary>
        /// Start a new HumanVsAI game on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartHumanVsAI_Click(object sender, EventArgs e)
        {
            // Ensure parent isn't null
            if (Parent == null) { return; }

            // Clear parent controls, instantiate and add HumanVsAI panel
            Control parent = Parent;
            parent.Controls.Clear();

            GenericGamePanel pnlHumanVsAI = new GenericGamePanel();
            parent.Controls.Add(pnlHumanVsAI);
        }

        /// <summary>
        /// Exit the application on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitGame_Click(object sender, EventArgs e)
        {
            CloseParentForm();
        }
        #endregion

        #region General Methods
        /// <summary>
        /// Ensures parent is a valid Form and then closes it.
        /// </summary>
        private void CloseParentForm()
        {
            // Ensure parent exists and is a form first
            if (Parent == null || !(Parent is Form)) { return; }

            // Convert parent control to it's child type (Form), and then close it
            ((Form)Parent).Close();
        }
        #endregion
    }
    #endregion
}
#endregion
