/*
 * Title: HumanVsHumanPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-24
 * Purpose: This panel contains the front-end logic for the HumanVsHuman tic tac toe game.
 * Back-end logic is found within the HumanVsHumanPanel.Backend.cs file.
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
    public partial class HumanVsHumanPanel : GenericGamePanel
    {
        #region Backing Data Members
        private BoardPanel _pnlGameBoard;
        #endregion

        #region Properties

        #region Game Setup Properties
        private int[] ParentControlDimensions { get; set; }
        private Panel pnlGameSetup { get; set; }
        private Label lblGameSetupHeader { get; set; }
        private Label lblPlayerOneNamePrompt { get; set; }
        private TextBox txtPlayerOneNameInput { get; set; }
        private Label lblPlayerTwoNamePrompt { get; set; }
        private TextBox txtPlayerTwoNameInput { get; set; }
        private Button btnStartGame { get; set; }
        #endregion

        #region Game Board Properties
        /// <summary>
        /// The game board panel. Setter auto clears controls and adds the value.
        /// </summary>
        public BoardPanel pnlGameBoard
        {
            get { return _pnlGameBoard; }
            set
            {
                this._pnlGameBoard = value;
                this.Controls.Add(value);
                value.StyleControls();
            }
        }
        public GameInfoPanel pnlGameInfo { get; set; }
        #endregion

        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds all setup controls
        /// </summary>
        private void InstantiateSetupControls()
        {
            // Instantiating Controlss
            pnlGameSetup = new Panel();
            lblGameSetupHeader = new Label();
            lblPlayerOneNamePrompt = new Label();
            txtPlayerOneNameInput = new TextBox();
            lblPlayerTwoNamePrompt = new Label();
            txtPlayerTwoNameInput = new TextBox();
            btnStartGame = new Button();

            // Adding controls to their children
            pnlGameSetup.Controls.Add(lblGameSetupHeader);
            pnlGameSetup.Controls.Add(lblPlayerOneNamePrompt);
            pnlGameSetup.Controls.Add(txtPlayerOneNameInput);
            pnlGameSetup.Controls.Add(lblPlayerTwoNamePrompt);
            pnlGameSetup.Controls.Add(txtPlayerTwoNameInput);
            pnlGameSetup.Controls.Add(btnStartGame);
            this.Controls.Add(pnlGameSetup);
        }

        /// <summary>
        /// Subscribes all setup event handlers
        /// </summary>
        private void SubscribeSetupEventHandlers()
        {
            #region Main/Game Setup Event Handlers
            btnStartGame.Click += new EventHandler(btnStartGame_Click);
            #endregion
        }

        /// <summary>
        /// Styles child controls. To be called after parent is defined. If no parent is defined, instantly returns
        /// </summary>
        public void StyleSetupControls()
        {
            // Return if parent deosn't exist
            if (Parent == null) { return; }

            // Grab the dimensions of the parent control and centre for styling
            ParentControlDimensions = new int[] { Parent.Width, Parent.Height };
            int horizontalCentre = ParentControlDimensions[0] / 2;
            int verticalCentre = ParentControlDimensions[1] / 2;

            #region Panel Styling
            this.Width = Parent.Width;
            this.Height = Parent.Height;
            this.BackColor = Color.FromArgb(0, 10, 0);
            #endregion

            #region pnlGameSetup Styling
            pnlGameSetup.Width = horizontalCentre + 50;
            pnlGameSetup.Height = this.Height;
            pnlGameSetup.Location = new Point(horizontalCentre - pnlGameSetup.Width / 2, verticalCentre - pnlGameSetup.Height / 2 + 20);
            pnlGameSetup.MaximumSize = new Size(800, 0);
            #endregion

            #region lblGameSetupHeader
            lblGameSetupHeader.Text = "Human Vs Human";
            lblGameSetupHeader.ForeColor = Color.FromArgb(0, 200, 0);
            lblGameSetupHeader.Width = lblGameSetupHeader.Parent.Width;
            lblGameSetupHeader.Height = pnlGameSetup.Height / 12;
            lblGameSetupHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblGameSetupHeader.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 40, FontStyle.Underline);
            #endregion

            #region lblPlayerOneNamePrompt
            lblPlayerOneNamePrompt.Text = "Player one, enter your name here:";
            lblPlayerOneNamePrompt.ForeColor = Color.FromArgb(0, 200, 0);
            lblPlayerOneNamePrompt.Width = pnlGameSetup.Width;
            lblPlayerOneNamePrompt.Height = 40;
            lblPlayerOneNamePrompt.TextAlign = ContentAlignment.MiddleLeft;
            lblPlayerOneNamePrompt.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 75);
            lblPlayerOneNamePrompt.Location = new Point(10, lblGameSetupHeader.Height * 2);
            #endregion

            #region txtPlayerOneNameInput
            ToolTips.SetToolTip(txtPlayerOneNameInput, "Player one, click here or navigate to tab index 0 to begin typing your name");
            txtPlayerOneNameInput.TabIndex = 0;
            txtPlayerOneNameInput.BackColor = Color.White;
            txtPlayerOneNameInput.ForeColor = Color.FromArgb(0, 100, 0);
            txtPlayerOneNameInput.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 50);
            txtPlayerOneNameInput.Width = pnlGameSetup.Width - 20;
            txtPlayerOneNameInput.Height = pnlGameSetup.Height / 50;
            txtPlayerOneNameInput.Location = new Point(pnlGameSetup.Width / 2 - txtPlayerOneNameInput.Width / 2, lblPlayerOneNamePrompt.Location.Y + lblPlayerOneNamePrompt.Height);
            txtPlayerOneNameInput.Focus();
            #endregion

            #region lblPlayerTwoNamePrompt
            lblPlayerTwoNamePrompt.Text = "Player two, enter your name here:";
            lblPlayerTwoNamePrompt.ForeColor = Color.FromArgb(0, 200, 0);
            lblPlayerTwoNamePrompt.Width = pnlGameSetup.Width;
            lblPlayerTwoNamePrompt.Height = 40;
            lblPlayerTwoNamePrompt.TextAlign = ContentAlignment.MiddleLeft;
            lblPlayerTwoNamePrompt.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 75);
            lblPlayerTwoNamePrompt.Location = new Point(10, txtPlayerOneNameInput.Location.Y + txtPlayerOneNameInput.Height * 2);
            #endregion

            #region txtPlayerOneNameInput
            ToolTips.SetToolTip(txtPlayerTwoNameInput, "Player two, click here or navigate to tab index 1 to begin typing your name");
            txtPlayerTwoNameInput.TabIndex = 1;
            txtPlayerTwoNameInput.BackColor = Color.White;
            txtPlayerTwoNameInput.ForeColor = Color.FromArgb(0, 100, 0);
            txtPlayerTwoNameInput.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 50);
            txtPlayerTwoNameInput.Width = pnlGameSetup.Width - 20;
            txtPlayerTwoNameInput.Height = pnlGameSetup.Height / 50;
            txtPlayerTwoNameInput.Location = new Point(pnlGameSetup.Width / 2 - txtPlayerOneNameInput.Width / 2, lblPlayerTwoNamePrompt.Location.Y + lblPlayerTwoNamePrompt.Height);
            #endregion

            #region btnStartGame Styling
            ToolTips.SetToolTip(btnStartGame, "Click here, or press Alt + S to start the Human Vs Human game when you've entered your names.");
            btnStartGame.TabIndex = 3;
            btnStartGame.Text = "&Start Game";
            btnStartGame.BackColor = Color.FromArgb(255, 255, 255);
            btnStartGame.ForeColor = Color.FromArgb(0, 100, 0);
            btnStartGame.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnStartGame.Width = horizontalCentre / 2;
            btnStartGame.Height = 30;
            btnStartGame.Location = new Point(pnlGameSetup.Width / 2 - btnStartGame.Width / 2, txtPlayerTwoNameInput.Location.Y + txtPlayerTwoNameInput.Height * 2);
            btnStartGame.MaximumSize = new Size(300, 30);
            #endregion

            #region btnExitToMenu Styling
            btnExitToMenu.TabIndex = 4;
            #endregion


        }

        #endregion

        #region Event Handler Methods
        /// <summary>
        /// Attempts to start a new game. If user names are not valid,
        /// displays error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // Attempt to validate user names.
            try
            {
                GameState.ValidateName(txtPlayerOneNameInput.Text);
                GameState.ValidateName(txtPlayerTwoNameInput.Text);
            }

            // If there was an exception, the names entered were invalid. Show the error.
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Otherwise start the game
            StartGame();
        }
        #endregion
    }
    #endregion
}
#endregion
