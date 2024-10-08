﻿/*
 * Title: frmMain.Styling.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-07
 * Purpose: To programatially style the battleship game screen,
 * ensuring all controls remain centred/alligned on screen resize
 */

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace Definition
namespace Assignment2
{
    /// <summary>
    /// Provides all styling/restyling methods for the form
    /// </summary>
    public partial class frmMain
    {
        #region Constants and Static Styling Variables

        private static Size FORM_MINIMUM_SIZE = new Size(720, 450);
        private static Size MAXIMUM_SETUP_PANEL_SIZE = new Size(0, 29);

        private const int MAXIMUM_BUTTON_FONT_SIZE = 25;
        private const int MINIMUM_BUTTON_FONT_SIZE = 8;

        private const int MAXIMUM_MISSLES_FIRED_HEIGHT = 75;

        private const int MARGIN = 10;

        #endregion

        #region Properties

        // Header
        private Label lblHeader { get; set; }
        private Panel pnlGameSetup { get; set; }
        private Button btnNewGame { get; set; }
        private Button btnExitApplication { get; set; }
        private Button btnRestartGame { get; set; }

        // Game area
        private PictureBox pbxBattleshipBackground { get; set; }
        private Panel pnlGameArea { get; set; }
        private Label lblStartGamePrompt { get; set; }

        // Missles fired - nullable because they will not be instantiated in constructor
        private Panel? pnlMisslesFired { get; set; }
        private Label? lblMisslesFired { get; set; }

        // Progress panel
/*        private Panel pnlProgress { get; set; }
        private Button btnViewProgress { get; set; }*/

        // Tool tips
        private ToolTip ToolTips { get; set; }

        #endregion

        #region Styling Methods

        /// <summary>
        /// Styles all controls for initial screen.
        /// </summary>
        private void StyleControls()
        {
            // This integer helps to provide relative positioning for each control
            int relativePosition = ClientSize.Width + ClientSize.Height;

            #region Form

            MinimumSize = FORM_MINIMUM_SIZE;
            AcceptButton = btnNewGame;
            CancelButton = btnExitApplication;

            #endregion

            #region lblHeader

            lblHeader.Text = "BATTLESHIP";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            lblHeader.Location = new Point(0, 0);
            lblHeader.BackColor = Color.Black;
            lblHeader.ForeColor = Color.White;

            #endregion

            #region pnlGameSetup

            // The panel itself
            pnlGameSetup.MaximumSize = MAXIMUM_SETUP_PANEL_SIZE;
            pnlGameSetup.BackColor = Color.FromArgb(222, 222, 222);

            // btnNewGame
            ToolTips.SetToolTip(btnNewGame, "Click here, or press 'Alt + N' to reset all progress and start a new game.");
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "&NEW GAME";
            btnNewGame.BackColor = Color.Black;
            btnNewGame.ForeColor = Color.White;

            // btnRestartGame
            ToolTips.SetToolTip(btnRestartGame, "Click here, or press 'Alt + R' to reset all progress and game board.");
            btnRestartGame.TabIndex = 1;
            btnRestartGame.Text = "&RESET";
            btnRestartGame.BackColor = Color.Black;
            btnRestartGame.ForeColor = Color.White;

            // btnExitApplication
            ToolTips.SetToolTip(btnExitApplication, "Click here, or press 'Alt + X' to exit application.");
            btnExitApplication.TabIndex = 2;
            btnExitApplication.Text = "&X";
            btnExitApplication.BackColor = Color.Black;
            btnExitApplication.ForeColor = Color.Red;

            #endregion

            #region pnlGameArea

            // Game area
            pnlGameArea.BackColor = Color.FromArgb(0, 255, 255, 255);

            // Background Picture
            pbxBattleshipBackground.Image = Image.FromStream(new MemoryStream(Properties.Resources.BattleshipBackground));
            pbxBattleshipBackground.Size = new Size(1920, 1080);

            // Start game prompt
            lblStartGamePrompt.Text = "There is no game active right now...Click 'New Game', or press ALT + 'N' to start one!";
            lblStartGamePrompt.TextAlign = ContentAlignment.MiddleCenter;

            lblStartGamePrompt.BackColor = Color.Black;
            lblStartGamePrompt.ForeColor = Color.White;

            // Update sizing/positioning based on form width and height
            StylePositioning();

            #endregion
        }

        /// <summary>
        /// Styles/Restyles controls when screen resizes. Just updates sizes and positions.
        /// </summary>
        private void StylePositioning()
        {

            // This integer helps to provide relative positioning for each control
            int relativePosition = ClientSize.Width + ClientSize.Height;

            #region lblHeader

            lblHeader.Size = new Size(ClientSize.Width, relativePosition / 25);
            lblHeader.Font = new Font("Impact", lblHeader.Height / 2, FontStyle.Regular);

            #endregion

            #region pnlGameSetup

            // The panel itself
            pnlGameSetup.Size = new Size(ClientSize.Width, lblHeader.Height / 2);
            pnlGameSetup.Location = new Point(0, lblHeader.Location.Y + lblHeader.Height);

            // btnNewGame
            btnNewGame.Size = new Size(ClientSize.Width / 2, pnlGameSetup.Height);
            btnNewGame.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // btnRestartGame
            btnRestartGame.Size = new Size(ClientSize.Width / 15, pnlGameSetup.Height);
            btnRestartGame.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // btnExitApplication
            btnExitApplication.Size = new Size(ClientSize.Width / 20, pnlGameSetup.Height);
            btnExitApplication.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // Button locations
            btnNewGame.Location = new Point(pnlGameSetup.Width / 2 - btnNewGame.Width / 2, 0);
            btnExitApplication.Location = new Point(MARGIN, 0);
            btnRestartGame.Location = new Point(btnExitApplication.Location.X + btnExitApplication.Width);

            // Ensure button fonts do not suprass limit
            if (btnNewGame.Font.Size > MAXIMUM_BUTTON_FONT_SIZE)
            {
                btnNewGame.Font = new Font("Segoe UI", MAXIMUM_BUTTON_FONT_SIZE, FontStyle.Regular);
                btnExitApplication.Font = new Font("Segoe UI", MAXIMUM_BUTTON_FONT_SIZE, FontStyle.Regular);
            }
            else if (btnNewGame.Font.Size < MINIMUM_BUTTON_FONT_SIZE)
            {
                btnNewGame.Font = new Font("Segoe UI", MINIMUM_BUTTON_FONT_SIZE, FontStyle.Regular);
                btnExitApplication.Font = new Font("Segoe UI", MINIMUM_BUTTON_FONT_SIZE, FontStyle.Regular);
            }

            #endregion

            #region pnlGameArea

            // Game area
            pnlGameArea.Size = new Size(ClientSize.Width - MARGIN * 2, ClientSize.Height - pnlGameSetup.Height - lblHeader.Height - MARGIN * 2);
            pnlGameArea.Location = new Point(MARGIN, pnlGameSetup.Location.Y + pnlGameSetup.Height + MARGIN);
            pbxBattleshipBackground.Location = new Point(pnlGameArea.Width / 2 - pbxBattleshipBackground.Width / 2, pnlGameArea.Height / 2 - pbxBattleshipBackground.Height / 2);

            // Style game area based on game happening status
            if (CurrentGameState.GameHappening)
            {
                StyleActiveGamePositioning();
            }
            else
            {
                StyleNoActiveGamePositioning(relativePosition);
            }

            #endregion
        }

        /// <summary>
        /// To be called only after a game starts. Sets unchangeing properties
        /// for pnlMisslesFired
        /// </summary>
        private void StyleMissleTracker()
        {
            // If the controls are somehow null (SetMissleTracker was never called), just return
            if (pnlMisslesFired == null || lblMisslesFired == null) { return; }

            #region pnlMisslesFired Styling
            
            ToolTips.SetToolTip(lblMisslesFired, "Click any non red/white square above to fire a missle!");
            pnlMisslesFired.BackColor = Color.FromArgb(120, 255, 0, 0);
            pnlMisslesFired.MaximumSize = new Size(0, MAXIMUM_MISSLES_FIRED_HEIGHT);
            pnlMisslesFired.BringToFront();

            #endregion

            #region lblMissles Fired Styling

            lblMisslesFired.TextAlign = ContentAlignment.MiddleCenter;
            lblMisslesFired.BringToFront();
            UpdateMisslesFiredLabel();
            
            #endregion
        }

        /// <summary>
        /// Styles each label in array of labels for this game.
        /// </summary>
        private void StyleActiveGamePositioning()
        {
            // Ensure game area panel is not on screen to prevent lag
            Controls.Remove(pnlGameArea);
            
            // The current difficulty as it's integer value
            int boardSize = (int)CurrentGameState.Difficulty;

            // The width and height of each label. If a label is off screen, ensure it is made smaller and visible
            int size = (pnlGameArea.Width + pnlGameArea.Height) / 40;
            if (size * boardSize + MARGIN * boardSize >= pnlGameArea.Width ||
                size * boardSize + MARGIN * boardSize >= pnlGameArea.Height)
            {
                size = 15;
            }

            // For horizontal/vertical spacing
            int defaultHorizontalSpacing = pnlGameArea.Width / 2 - (boardSize * MARGIN + boardSize * size) / 2;
            int horizontalSpacing = defaultHorizontalSpacing;
            int verticalSpacing = MARGIN;

            // Iterate through each game position (label) within game area, updating position apropriately for each
            for (int i = 0; i < CurrentGameState.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGameState.BoardArray.GetLength(1); j++)
                {
                    CurrentGameState.BoardArray[i, j].BringToFront();
                    CurrentGameState.BoardArray[i, j].Width = size;
                    CurrentGameState.BoardArray[i, j].Height = size;
                    CurrentGameState.BoardArray[i, j].Location = new Point(horizontalSpacing, verticalSpacing);
                    horizontalSpacing += CurrentGameState.BoardArray[i, j].Width + MARGIN;
                }
                horizontalSpacing = defaultHorizontalSpacing;
                verticalSpacing += CurrentGameState.BoardArray[i, i].Width + MARGIN;
            }

            // Add game area back, ensure background stays behind all
            Controls.Add(pnlGameArea);

            // Style missles fired panel
            StyleMisslesFiredPositioning();
        }

        /// <summary>
        /// To be called after game panel is styled. 
        /// Styles pnlMisslesFired and its label so that it appears
        /// directly below the last boardposition row.
        /// </summary>
        private void StyleMisslesFiredPositioning()
        {
         
            // If the controls are somehow null (SetMissleTracker was never called), just return
            if (pnlMisslesFired == null || lblMisslesFired == null) { return; }

            // Get the last board position row
            int lastRow = CurrentGameState.BoardArray.GetLength(0);
            Label lastRowBoardPosition = CurrentGameState.BoardArray[lastRow - 1, 0];

            #region pnlMisslesFired Styling
            
            pnlMisslesFired.Location = new Point(lastRowBoardPosition.Location.X, lastRowBoardPosition.Location.Y + 
                lastRowBoardPosition.Height + MARGIN);
            pnlMisslesFired.Width = (lastRowBoardPosition.Width * lastRow) + (MARGIN * (lastRow - 1));
            pnlMisslesFired.Height = pnlGameArea.Height - ((lastRowBoardPosition.Height * lastRow) + (MARGIN * (lastRow - 1)));

            #endregion

            #region lblMisslesFired Styling

            lblMisslesFired.Size = new Size(pnlMisslesFired.Width, pnlMisslesFired.Height);
            lblMisslesFired.Font = new Font("Impact", lblMisslesFired.Height / 4, FontStyle.Regular);

            #endregion
        }

        /// <summary>
        /// Displays prompt informing user there is no active game.
        /// </summary>
        /// <param name="relativePosition">For relative styling based on parent form.</param>
        private void StyleNoActiveGamePositioning(int relativePosition)
        {
            // Start game prompt
            lblStartGamePrompt.Size = new Size(ClientSize.Width, relativePosition / 25);
            lblStartGamePrompt.Font = new Font("Segoe UI", lblHeader.Height / 5, FontStyle.Regular);
            lblStartGamePrompt.Location = new Point(0, pnlGameArea.Height / 2 - lblStartGamePrompt.Height / 2);
            lblStartGamePrompt.BringToFront();
        }

        #endregion

    }
}
#endregion
