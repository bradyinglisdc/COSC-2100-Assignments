/*
 * Title: GamePanel.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-24
 * Purpose: This panel contains the front-end logic for the tic tac toe game.
 * Back-end logic is found within the GamePanel.Backend.cs file.
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
    public partial class GamePanel
    {
        #region Backing Data Members
        private BoardPanel _pnlGameBoard;
        private GameInfoPanel _pnlGameInfo;
        #endregion

        #region Properties

        #region Game Setup Properties
        private bool IsAIGame { get; set; }
        private int[] ParentControlDimensions { get; set; }
        private int HorizontalCentre { get; set; }
        private int VerticalCentre { get; set; }
        private Panel pnlGameSetup { get; set; }
        private Label lblGameSetupHeader { get; set; }
        private Label lblPlayerOneNamePrompt { get; set; }
        private TextBox txtPlayerOneNameInput { get; set; }
        private Label lblPlayerTwoNamePrompt { get; set; }
        private TextBox txtPlayerTwoNameInput { get; set; }
        private Button btnStartGame { get; set; }
        private Label lblDisclaimer { get; set; }

        // Difficulty for AI game
        private RadioButton rbtnDifficultyEasy { get; set; }
        private RadioButton rbtnDifficultyHard { get; set; }
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
        /// <summary>
        /// The game info panel. Contains info about the game.
        /// </summary>
        public GameInfoPanel pnlGameInfo
        {
            get { return _pnlGameInfo; }
            set
            {
                this._pnlGameInfo = value;
                this.Controls.Add(value);
                value.StyleControls();
                StyleGameControls(); // Ensure all game controls are styled
            }
        }
        private Label lblCurrentPlayerHeader { get; set; }
        public Button btnPlayAgain { get; set; }

        #endregion

        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds all setup controls for eithe a human vs human or
        /// human vs AI game
        /// </summary>
        private void InstantiateControls()
        {
            if (!IsAIGame) { SetupHumanVsHumanGameControls(); }
            else { SetupHumanVsAIGameControls(); }
        }

        /// <summary>
        /// Instantiates and adds all setup controls for human vs human game
        /// </summary>
        private void SetupHumanVsHumanGameControls()
        {
            // Instantiating game setup controls
            InstantiateMainControls();
            lblPlayerTwoNamePrompt = new Label();
            txtPlayerTwoNameInput = new TextBox();

            // Adding game setup controls to their parent
            pnlGameSetup.Controls.Add(lblPlayerTwoNamePrompt);
            pnlGameSetup.Controls.Add(txtPlayerTwoNameInput);
            this.Controls.Add(pnlGameSetup);
        }

        /// <summary>
        /// Instantiates and adds all setup controls for human vs ai game
        /// </summary>
        private void SetupHumanVsAIGameControls()
        {
            // Instantiating game setup controls
            InstantiateMainControls();
            rbtnDifficultyEasy = new RadioButton();
            rbtnDifficultyHard = new RadioButton();

            // Adding game setup controls to their parent
            this.pnlGameSetup.Controls.Add(rbtnDifficultyEasy);
            this.pnlGameSetup.Controls.Add(rbtnDifficultyHard);
            this.Controls.Add(pnlGameSetup);
        }

        /// <summary>
        /// Instantiates main controls which will be the same for humanvshuman and AI games
        /// </summary>
        private void InstantiateMainControls()
        {
            // Instantiating Controls - Setup
            pnlGameSetup = new Panel();
            lblPlayerOneNamePrompt = new Label();
            txtPlayerOneNameInput = new TextBox();
            lblGameSetupHeader = new Label();
            btnStartGame = new Button();
            lblDisclaimer = new Label();

            // Instantiating Controls - Game
            lblCurrentPlayerHeader = new Label();
            btnPlayAgain = new Button();

            // Adding
            pnlGameSetup.Controls.Add(lblGameSetupHeader);
            pnlGameSetup.Controls.Add(lblPlayerOneNamePrompt);
            pnlGameSetup.Controls.Add(txtPlayerOneNameInput);
            pnlGameSetup.Controls.Add(btnStartGame);
            pnlGameSetup.Controls.Add(lblDisclaimer);
        }

        /// <summary>
        /// Subscribes all setup event handlers
        /// </summary>
        private void SubscribeEventHandlers()
        {
            #region Main/Game Setup Event Handlers
            btnStartGame.Click += new EventHandler(btnStartGame_Click);
            btnPlayAgain.Click += new EventHandler(btnPlayAgain_Click);
            #endregion
        }

        /// <summary>
        /// Styles child controls. To be called after parent is defined. If no parent is defined, instantly returns
        /// </summary>
        public void StyleControls()
        {
            // Return if parent deosn't exist
            if (Parent == null) { return; }

            // Grab the dimensions of the parent control and centre for styling
            ParentControlDimensions = new int[] { Parent.Width, Parent.Height };
            HorizontalCentre = ParentControlDimensions[0] / 2;
            VerticalCentre = ParentControlDimensions[1] / 2;

            #region Panel Styling
            this.Width = Parent.Width;
            this.Height = Parent.Height;
            this.BackColor = Color.FromArgb(0, 10, 0);
            #endregion

            #region pnlGameSetup Styling
            pnlGameSetup.Width = HorizontalCentre + 50;
            pnlGameSetup.Height = this.Height;
            pnlGameSetup.Location = new Point(HorizontalCentre - pnlGameSetup.Width / 2, VerticalCentre - pnlGameSetup.Height / 2 + 20);
            pnlGameSetup.MaximumSize = new Size(800, 0);
            #endregion

            #region Gamemode Styling
            if (IsAIGame) { StyleHumanVsAIGameSetup(); }
            else { StyleHumanVsHumanGameSetup(); }
            #endregion

            // Style main game controls if a board is present
            StyleGameControls();
        }

        /// <summary>
        /// Styles all setup controls for a human vs human game
        /// </summary>
        private void StyleHumanVsHumanGameSetup()
        {

            #region lblGameSetupHeader
            lblGameSetupHeader.Text = "Human Vs Human";
            lblGameSetupHeader.ForeColor = Color.FromArgb(0, 200, 0);
            lblGameSetupHeader.Width = lblGameSetupHeader.Parent.Width;
            lblGameSetupHeader.Height = pnlGameSetup.Height / 12;
            lblGameSetupHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblGameSetupHeader.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 40, FontStyle.Underline);
            #endregion

            #region lblPlayerOneNamePrompt
            lblPlayerOneNamePrompt.Text = "Player X, enter your nickname here:";
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
            lblPlayerTwoNamePrompt.Text = "Player O, enter your nickname here:";
            lblPlayerTwoNamePrompt.ForeColor = Color.FromArgb(0, 200, 0);
            lblPlayerTwoNamePrompt.Width = pnlGameSetup.Width;
            lblPlayerTwoNamePrompt.Height = 40;
            lblPlayerTwoNamePrompt.TextAlign = ContentAlignment.MiddleLeft;
            lblPlayerTwoNamePrompt.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 75);
            lblPlayerTwoNamePrompt.Location = new Point(10, txtPlayerOneNameInput.Location.Y + txtPlayerOneNameInput.Height * 2);
            #endregion

            #region txtPlayerTwoNameInput
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
            btnStartGame.Width = HorizontalCentre / 2;
            btnStartGame.Height = 30;
            btnStartGame.Location = new Point(pnlGameSetup.Width / 2 - btnStartGame.Width / 2, txtPlayerTwoNameInput.Location.Y + txtPlayerTwoNameInput.Height * 2);
            btnStartGame.MaximumSize = new Size(300, 30);
            #endregion

            #region btnExitToMenu Styling
            btnExitToMenu.TabIndex = 4;
            #endregion

            #region lblDisclaimer Styling
            lblDisclaimer.Text = "First turn is randomly picked*";
            lblDisclaimer.ForeColor = Color.FromArgb(0, 50, 0);
            lblDisclaimer.BackColor = Color.FromArgb(255, 255, 255);
            lblDisclaimer.Width = pnlGameSetup.Width;
            lblDisclaimer.Height = (pnlGameSetup.Width + pnlGameSetup.Height) / 20;
            lblDisclaimer.TextAlign = ContentAlignment.MiddleCenter;
            lblDisclaimer.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 75, FontStyle.Bold);
            lblDisclaimer.Location = new Point(pnlGameSetup.Width / 2 - lblDisclaimer.Width / 2, btnStartGame.Location.Y + btnStartGame.Height + 20);
            #endregion

        }

        /// <summary>
        /// Styles all setup controls for a human vs AI game
        /// </summary>
        private void StyleHumanVsAIGameSetup()
        {
            #region lblGameSetupHeader Styling
            lblGameSetupHeader.Text = "Human Vs AI";
            lblGameSetupHeader.ForeColor = Color.FromArgb(0, 200, 0);
            lblGameSetupHeader.Width = lblGameSetupHeader.Parent.Width;
            lblGameSetupHeader.Height = pnlGameSetup.Height / 12;
            lblGameSetupHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblGameSetupHeader.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 40, FontStyle.Underline);
            #endregion

            #region lblPlayerOneNamePrompt
            lblPlayerOneNamePrompt.Text = "Player X, enter your nickname here:";
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
            #endregion

            #region rbtnDifficultyEasy Styling
            ToolTips.SetToolTip(rbtnDifficultyEasy, "Click here, or press Alt + E to set difficulty to easy.");
            rbtnDifficultyEasy.TabIndex = 0;
            rbtnDifficultyEasy.Text = "&Easy Mode";
            rbtnDifficultyEasy.ForeColor = Color.FromArgb(0, 200, 0);
            rbtnDifficultyEasy.Font = new Font("Courier New", 10, FontStyle.Bold);
            rbtnDifficultyEasy.Focus();
            #endregion

            #region rbtnDifficultyHard Styling
            ToolTips.SetToolTip(rbtnDifficultyHard, "Click here, or press Alt + H to set difficulty to hard.");
            rbtnDifficultyHard.TabIndex = 1;
            rbtnDifficultyHard.Text = "&Hard Mode";
            rbtnDifficultyHard.ForeColor = Color.FromArgb(0, 200, 0);
            rbtnDifficultyHard.Font = new Font("Courier New", 10, FontStyle.Bold);
            rbtnDifficultyEasy.Location = new Point(pnlGameSetup.Width / 2 - (rbtnDifficultyEasy.Width + rbtnDifficultyHard.Width) / 2, txtPlayerOneNameInput.Location.Y + txtPlayerOneNameInput.Height);
            rbtnDifficultyHard.Location = new Point(rbtnDifficultyEasy.Location.X + rbtnDifficultyEasy.Width, txtPlayerOneNameInput.Location.Y + txtPlayerOneNameInput.Height);
            #endregion

            #region btnStartGame Styling
            ToolTips.SetToolTip(btnStartGame, "Click here, or press Alt + S to start the Human Vs AI game.");
            btnStartGame.TabIndex = 2;
            btnStartGame.Text = "&Start Game";
            btnStartGame.BackColor = Color.FromArgb(255, 255, 255);
            btnStartGame.ForeColor = Color.FromArgb(0, 100, 0);
            btnStartGame.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnStartGame.Width = HorizontalCentre / 2;
            btnStartGame.Height = 30;
            btnStartGame.Location = new Point(pnlGameSetup.Width / 2 - btnStartGame.Width / 2, rbtnDifficultyHard.Location.Y + rbtnDifficultyHard.Height * 2);
            btnStartGame.MaximumSize = new Size(300, 30);
            #endregion

            #region btnExitToMenu Styling
            btnExitToMenu.TabIndex = 3;
            #endregion

            #region lblDisclaimer Styling
            lblDisclaimer.Text = "First turn is randomly picked*\nAI speed may vary.";
            lblDisclaimer.ForeColor = Color.FromArgb(0, 50, 0);
            lblDisclaimer.BackColor = Color.FromArgb(255, 255, 255);
            lblDisclaimer.Width = pnlGameSetup.Width;
            lblDisclaimer.Height = (pnlGameSetup.Width + pnlGameSetup.Height) / 20;
            lblDisclaimer.TextAlign = ContentAlignment.MiddleCenter;
            lblDisclaimer.Font = new Font("Courier New", (pnlGameSetup.Size.Width + pnlGameSetup.Size.Height) / 75, FontStyle.Bold);
            lblDisclaimer.Location = new Point(pnlGameSetup.Width / 2 - lblDisclaimer.Width / 2, btnStartGame.Location.Y + btnStartGame.Height + 20);
            #endregion
        }

        /// <summary>
        /// Styles/Restyles game board
        /// </summary>
        private void StyleGameControls()
        {
            // Return if the board/game state hasn't been instantiated
            if (pnlGameBoard == null || BoundGameState == null) { return; }

            #region lblCurrentPlayerHeader Styling
            lblCurrentPlayerHeader.ForeColor = Color.FromArgb(0, 200, 0);
            lblCurrentPlayerHeader.Width = this.Width;
            lblCurrentPlayerHeader.Height = 46;
            lblCurrentPlayerHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentPlayerHeader.Font = new Font("Courier New", 25, FontStyle.Underline);
            lblCurrentPlayerHeader.Location = new Point(ParentControlDimensions[0] / 2 - lblCurrentPlayerHeader.Width / 2, 10);
            #endregion

            #region btnPlayAgain Styling
            pnlGameBoard.ToolTips.SetToolTip(btnPlayAgain, "To play again and save this score to memory, click here, or press Alt + P");
            btnPlayAgain.TabIndex = 2;
            btnPlayAgain.Text = "&Play Again?";
            btnPlayAgain.BackColor = Color.FromArgb(255, 255, 255);
            btnPlayAgain.ForeColor = Color.FromArgb(0, 100, 0);
            btnPlayAgain.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnPlayAgain.Width = this.Width / 4;
            btnPlayAgain.Height = 30;
            btnPlayAgain.Location = new Point(this.Width / 2 - btnPlayAgain.Width / 2, lblCurrentPlayerHeader.Location.Y + lblCurrentPlayerHeader.Height);
            btnPlayAgain.MaximumSize = new Size(500, 30);

            // Button only shows when game is over
            btnPlayAgain.Visible = BoundGameState.GameOver;
            #endregion

            #region pnlGameBoard Styling
            pnlGameBoard.StyleControls();
            #endregion

            #region pnlGameInfo Styling
            pnlGameInfo.StyleControls();
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
            // If player two name input has not been instantiate, it is an AI game. Instantiate it with ai name.
            if (txtPlayerTwoNameInput == null) { txtPlayerTwoNameInput = new TextBox() { Text = "AI Bot" }; }

            // Attempt to validate user names.
            try
            {
                GameState.ValidateName(txtPlayerOneNameInput.Text);
                GameState.ValidateName(txtPlayerTwoNameInput.Text);
            }

            // If there was an exception, the names entered were invalid. Show the error.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Otherwise, subscribe exit confirmation method to the exit button then start the game
            btnExitToMenu.Click -= btnExitToMenu_Click;
            btnExitToMenu.Click += btnExitToMenuConfirmation_Click;
            StartGame();
        }

        /// <summary>
        /// Instantiates a new game board, removing the previous one and
        /// updating backend board state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void btnPlayAgain_Click(object sender, EventArgs args)
        {
            ResetBoard();
        }
        #endregion


    }
    #endregion
}
#endregion
