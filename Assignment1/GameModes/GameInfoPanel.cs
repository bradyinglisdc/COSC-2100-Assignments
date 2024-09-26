/*
 * Title: GameInfoPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-26
 * Purpose: This Panel class displays the game information found in a GameState.
 * Constructor takes a game state which information will be pulled from.
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
    #region Class Defintions
    public class GameInfoPanel : Panel
    {
        #region Properties
        private ToolTip ToolTips { get; set; }
        private GameState BoundGameState { get; set; }
        private Button btnChangeFocus { get; set; }
        private Button btnResetGame { get; set; }
        private Label lblGameInfoHeader { get; set; }
        private Label lblPlayerOneScore { get; set; }
        private Label lblDrawScore { get; set; }
        private Label lblPlayerTwoScore { get; set; }
        private bool IsMinimized { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Sets the game state then instantiates and adds controls
        /// </summary>
        /// <param name="boundGameState">The game state to pull data from.</param>
        public GameInfoPanel(GameState boundGameState)
        {
            BoundGameState = boundGameState;
            IsMinimized = true;
            InstantiateControls();
            SubscribeEventHandlers();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds all controls to their respective parents.
        /// </summary>
        private void InstantiateControls()
        {
            // Instantiating controls
            ToolTips = new ToolTip();
            btnChangeFocus = new Button();
            btnResetGame = new Button();
            lblGameInfoHeader = new Label();
            lblPlayerOneScore = new Label();
            lblDrawScore = new Label();
            lblPlayerTwoScore = new Label();

            // Adding controls
            this.Controls.Add(btnChangeFocus);
            this.Controls.Add(btnResetGame);
            this.Controls.Add(lblPlayerOneScore);
            this.Controls.Add(lblDrawScore);
            this.Controls.Add(lblPlayerTwoScore);
        }

        /// <summary>
        /// Styles all controls; only to be called after this Panel is instantiated
        /// and has a parent for relative positioning.
        /// </summary>
        public void StyleControls()
        {
            // Return if the parent hasn't been defined
            if (Parent == null) { return; }

            #region Panel Styling
            this.Width = Parent.Width;
            this.Height = Parent.Height / 2;
            this.BackColor = Color.FromArgb(80, 100, 80);
            this.Location = new Point(0, Parent.Height - this.Height);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BringToFront();
            #endregion

            #region btnChangeFocus
            ToolTips.SetToolTip(btnChangeFocus, Settings.MaximizeInfoPanelToolTip);
            btnChangeFocus.TabIndex = 3;
            btnChangeFocus.Text = Settings.MaximizeInfoPanelPrompt;
            btnChangeFocus.BackColor = Color.FromArgb(255, 255, 255);
            btnChangeFocus.ForeColor = Color.FromArgb(0, 50, 0);
            btnChangeFocus.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnChangeFocus.Width = this.Width / 4;
            btnChangeFocus.Height = 25;
            btnChangeFocus.Location = new Point(0, 0);
            btnChangeFocus.Focus();
            #endregion

            #region btnResetGame
            ToolTips.SetToolTip(btnResetGame, "Click here, or press Alt + R to reset board and scores.");
            btnResetGame.TabIndex = 4;
            btnResetGame.Text = "&Reset Game";
            btnResetGame.BackColor = Color.FromArgb(255, 255, 255);
            btnResetGame.ForeColor = Color.FromArgb(200, 0, 0);
            btnResetGame.Font = new Font("Courier New", 10, FontStyle.Bold);
            btnResetGame.Width = this.Width / 5;
            btnResetGame.Height = 25;
            btnResetGame.Location = new Point(this.Width - (btnResetGame.Width + 19), 0);
            #endregion

            #region Score Styling/Setting
            SetScores();
            #endregion

            // Score board should be minimized at first
            ChangeFocus();
        }

        /// <summary>
        /// Uses the bound game state to style and set scores.
        /// </summary>
        public void SetScores()
        {
            // Just return if the gamestate/parent doesn't exist
            if (Parent == null || BoundGameState == null) { return; }
            int margin = 5;

            #region lblPlayerOneScore Styling
            ToolTips.SetToolTip(lblPlayerOneScore, $"{BoundGameState.PlayerOneName}'s win count is {BoundGameState.Scores[0]}");
            lblPlayerOneScore.Text = $"{BoundGameState.PlayerOneName}'s Wins: {BoundGameState.Scores[0]}";
            lblPlayerOneScore.ForeColor = Color.FromArgb(0, 200, 0);
            lblPlayerOneScore.BackColor = Color.FromArgb(0, 30, 0);
            lblPlayerOneScore.Width = this.Width;
            lblPlayerOneScore.Height = this.Height / 3 - btnChangeFocus.Height - margin;
            lblPlayerOneScore.TextAlign = ContentAlignment.MiddleLeft;
            lblPlayerOneScore.Font = new Font("Courier New", 15, FontStyle.Bold);
            lblPlayerOneScore.Location = new Point(0, btnChangeFocus.Height + margin);
            #endregion

            #region lblDrawScore Styling
            ToolTips.SetToolTip(lblDrawScore, $"Draw count is {BoundGameState.Scores[2]}");
            lblDrawScore.Text = $"Draws: {BoundGameState.Scores[2]}";
            lblDrawScore.ForeColor = Color.FromArgb(0, 200, 0);
            lblDrawScore.BackColor = Color.FromArgb(0, 30, 0);
            lblDrawScore.Width = this.Width;
            lblDrawScore.Height = this.Height / 3 - btnChangeFocus.Height - margin;
            lblDrawScore.TextAlign = ContentAlignment.MiddleLeft;
            lblDrawScore.Font = new Font("Courier New", 15, FontStyle.Bold);
            lblDrawScore.Location = new Point(0, lblPlayerOneScore.Location.Y + lblPlayerOneScore.Height + margin);
            #endregion

            #region lblPlayerTwoScore Styling
            ToolTips.SetToolTip(lblPlayerTwoScore, $"{BoundGameState.PlayerTwoName}'s win count is {BoundGameState.Scores[1]}");
            lblPlayerTwoScore.Text = $"{BoundGameState.PlayerTwoName}'s Wins: {BoundGameState.Scores[1]}";
            lblPlayerTwoScore.ForeColor = Color.FromArgb(0, 200, 0);
            lblPlayerTwoScore.BackColor = Color.FromArgb(0, 30, 0);
            lblPlayerTwoScore.Width = this.Width;
            lblPlayerTwoScore.Height = this.Height / 3 - btnChangeFocus.Height - margin;
            lblPlayerTwoScore.TextAlign = ContentAlignment.MiddleLeft;
            lblPlayerTwoScore.Font = new Font("Courier New", 15, FontStyle.Bold);
            lblPlayerTwoScore.Location = new Point(0, lblDrawScore.Location.Y + lblDrawScore.Height + margin);
            #endregion
        }

        /// <summary>
        /// Subscribes event handlers for all controls that need them.
        /// </summary>
        private void SubscribeEventHandlers()
        {
            btnChangeFocus.Click += new EventHandler(btnChangeFocus_Click);
        }
        #endregion

        #region Event Handler Methods
        private void btnChangeFocus_Click(object sender, EventArgs args)
        {
            ChangeFocus();
        }
        #endregion


        #region Focus Control Methods
        public void ChangeFocus()
        {
            if (IsMinimized) { Maximize(); }
            else { Minimize(); }
        }

        /// <summary>
        /// Sets Y higher to make full card visible.
        /// </summary>
        private void Maximize()
        {
            this.Location = new Point(0, Parent.Height - this.Height);
            ToolTips.SetToolTip(btnChangeFocus, Settings.MinmizeInfoPanelToolTip);
            btnChangeFocus.Text = Settings.MinmizeInfoPanelPrompt;
            IsMinimized = false;
        }

        /// <summary>
        /// Sets Y lower to make full card invisible
        /// </summary>
        private void Minimize()
        {
            this.Location = new Point(0, Parent.Height - (btnChangeFocus.Height + 40));
            ToolTips.SetToolTip(btnChangeFocus, Settings.MaximizeInfoPanelToolTip);
            btnChangeFocus.Text = Settings.MaximizeInfoPanelPrompt;
            IsMinimized = true;
        }


        #endregion
    }
    #endregion

}
#endregion