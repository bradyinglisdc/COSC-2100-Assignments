/*
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

        // Form and Setup panel
        public static Size FORM_MINIMUM_SIZE = new Size(720, 600);
        public static Size MAXIMUM_SETUP_PANEL_SIZE = new Size(0, 29);

        // Board sizing
        public const int MAXIMUM_BOARD_POSITION_SIZE = 55;
        public const int MINIMUM_BOARD_POSITION_SIZE = 30;

        // Button sizing
        public const int MAXIMUM_BUTTON_FONT_SIZE = 25;
        private const int MINIMUM_BUTTON_FONT_SIZE = 8;

        // Missiles Fired control sizing
        public const int VIEW_PROGRESS_BUTTON_HEIGHT = 50;
        public const int MAXIMUM_MISSILES_FIRED_HEIGHT = 75;
        public const int MINIMUM_MISSILES_FIRED_HEIGHT = 25;

        // Resizeable Panel Sizing
        public const int MIMIMIZED_PANEL_HEIGHT = 50;
        public const int PROGRESS_HEADERS_FONT_SIZE = 12;

        // General styling
        private const int MARGIN = 10;

        #endregion

        #region Properties

        // Header
        private Label lblHeader { get; set; }
        private Panel pnlGameSetup { get; set; }
        private Button btnNewGame { get; set; }
        private Button btnExitApplication { get; set; }
        /*private Button btnRestartGame { get; set; }*/

        // Game area
        private PictureBox pbxBattleshipBackground { get; set; }
        private Panel pnlGameArea { get; set; }
        private Label lblStartGamePrompt { get; set; }

        // Missiles fired
        private PictureBox pbxMissilesFired { get; set; }
        private Label lblMissilesFired { get; set; }

        // Progress panel
        private Panel pnlProgress { get; set; }
        private Button btnViewProgress { get; set; }

        private Label lblCarrierHealthHeader { get; set; }
        private ProgressBar pbrCarrierHealthIndicator { get; set; }

        private Label lblBattleshipHealthHeader { get; set; }
        private ProgressBar pbrBattleshipHealthIndicator { get; set; }

        private Label lblCruiserHealthHeader { get; set; }
        private ProgressBar pbrCruiserHealthIndicator { get; set; }

        private Label lblSubmarineHealthHeader { get; set; }
        private ProgressBar pbrSubmarineHealthIndicator { get; set; }

        private Label lblDestroyerHealthHeader { get; set; }
        private ProgressBar pbrDestroyerHealthIndicator { get; set; }

        // Manual Controls Panel
        private Panel pnlManualControls { get; set; }
        private Button btnViewManualControls { get; set; }
        private Label lblManualXCoordinatesHeader { get; set; }
        private NumericUpDown nudManualXCoordinates { get; set; }
        private Label lblManualYCoordinatesHeader { get; set; }
        private NumericUpDown nudManualYCoordinates { get; set; }
        private Button btnManualFire { get; set; }

        // Tool tips
        private ToolTip ToolTips { get; set; }

        #endregion

        #region Unchanging Styles

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
/*            ToolTips.SetToolTip(btnRestartGame, "Click here, or press 'Alt + R' to reset all progress and game board.");
            btnRestartGame.TabIndex = 1;
            btnRestartGame.Text = "&RESET";
            btnRestartGame.BackColor = Color.Black;
            btnRestartGame.ForeColor = Color.White;*/

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

            #endregion

            #region pbxMissleTracker

            // The Picturebox
            ToolTips.SetToolTip(lblMissilesFired, "Click any non red/white square above to fire a missle!");
            pbxMissilesFired.Image = Image.FromStream(new MemoryStream(Properties.Resources.MissilesFiredPanel));
            pbxMissilesFired.MaximumSize = new Size(0, MAXIMUM_MISSILES_FIRED_HEIGHT);
            pbxMissilesFired.MinimumSize = new Size(0, MINIMUM_MISSILES_FIRED_HEIGHT);

            // The Tracking Label
            lblMissilesFired.TextAlign = ContentAlignment.MiddleCenter;
            lblMissilesFired.ForeColor = Color.FromArgb(50, 255, 255, 255);

            #endregion

            #region pnlManualControls

            // Access Styling
            ChangeManualControlsPanelSize(); // Minimize at first
            SetResizablePanelProperties(pnlManualControls, btnViewManualControls);
            btnViewManualControls.TabIndex = 0;

            // Set label texts
            lblManualXCoordinatesHeader.Text = "X COORDINATES:";
            lblManualXCoordinatesHeader.ForeColor = Color.White;
            lblManualXCoordinatesHeader.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Underline);

            lblManualYCoordinatesHeader.Text = "Y COORDINATES:";
            lblManualYCoordinatesHeader.ForeColor = Color.White;
            lblManualYCoordinatesHeader.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Underline);

            // Set numeric up downs
            ToolTips.SetToolTip(nudManualXCoordinates, "Enter the X Coordinates you want to fire on here!");
            nudManualXCoordinates.TabIndex = 1;
            nudManualXCoordinates.Maximum = BS.MAX_BOARD_SIZE;
            nudManualXCoordinates.Minimum = 1;

            ToolTips.SetToolTip(nudManualYCoordinates, "Enter the Y Coordinates you want to fire on here!");
            nudManualYCoordinates.TabIndex = 2;
            nudManualYCoordinates.Maximum = BS.MAX_BOARD_SIZE;
            nudManualYCoordinates.Minimum = 1;

            // btnManualFire
            ToolTips.SetToolTip(btnManualFire, "Click here, or press 'ALT + F' to fire at the above coordiantes!");
            btnManualFire.TabIndex = 3;
            btnManualFire.Text = "&FIRE!";
            btnManualFire.BackColor = Color.Black;
            btnManualFire.ForeColor = Color.Green;

            #endregion

            #region pnlProgress

            // Access Styling
            ChangeProgressPanelSize(); // Minimize at first
            SetResizablePanelProperties(pnlProgress, btnViewProgress);
            btnViewProgress.TabIndex = 0;

            #endregion

            // Update sizing/positioning based on form width and height
            StylePositioning();
        }


        /// <summary>
        /// Styles both resizeable panel's unchanging propeties
        /// </summary>
        /// <param name="panelToStyle">The resizeable panel to style.</param>
        /// <param name="buttonToStyle">The corresponding buttons.</param>
        private void SetResizablePanelProperties(Panel pnlToStyle, Button btnToStyle)
        {
            pnlToStyle.BackColor = Color.FromArgb(30, 30, 30);
            btnToStyle.BackColor = Color.Black;
            btnToStyle.ForeColor = Color.White;
            btnToStyle.TextAlign = ContentAlignment.MiddleCenter;
            btnToStyle.Height = VIEW_PROGRESS_BUTTON_HEIGHT;
        }

        #endregion

        #region Dynamic Styles

        /// <summary>
        /// Styles/Restyles controls when screen resizes. Just updates sizes and positions.
        /// </summary>
        private void StylePositioning()
        {
            // If minimized, do not style or exceptions will be thrown when styling
            if (WindowState == FormWindowState.Minimized) { return; }

            // This integer helps to provide relative positioning for each control
            int relativePosition = ClientSize.Width + ClientSize.Height;

            #region lblHeader

            lblHeader.Size = new Size(ClientSize.Width, relativePosition / 25);

            if (lblHeader.Height / 2 > 0)
            {
                lblHeader.Font = new Font("Impact", lblHeader.Height / 2, FontStyle.Regular);
            }

            #endregion

            #region pnlGameSetup

            // The panel itself
            pnlGameSetup.Size = new Size(ClientSize.Width, lblHeader.Height / 2);
            pnlGameSetup.Location = new Point(0, lblHeader.Location.Y + lblHeader.Height);

            // btnNewGame
            btnNewGame.Size = new Size(ClientSize.Width / 2, pnlGameSetup.Height);
            btnNewGame.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // btnRestartGame
/*            btnRestartGame.Size = new Size(ClientSize.Width / 15, pnlGameSetup.Height);
            btnRestartGame.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);*/

            // btnExitApplication
            btnExitApplication.Size = new Size(ClientSize.Width / 20, pnlGameSetup.Height);
            btnExitApplication.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // Button locations
            btnNewGame.Location = new Point(pnlGameSetup.Width / 2 - btnNewGame.Width / 2, 0);
            btnExitApplication.Location = new Point(MARGIN, 0);
/*            btnRestartGame.Location = new Point(btnExitApplication.Location.X + btnExitApplication.Width);*/

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

            #endregion

            // Style remaining game area if game state exists
            if (CurrentGameState.GameHappening)
            {
                StyleActiveGamePositioning();
            }
            else
            {
                StyleNoActiveGamePositioning(relativePosition);
            }
        }

        /// <summary>
        /// Styles each label in array of labels for this game.
        /// </summary>
        private void StyleActiveGamePositioning()
        {
            // The current difficulty as it's integer value
            int boardSize = (int)CurrentGameState.Difficulty;

            // The width and height of each label. Ensure size doesn't suprass max position size for proper centering.
            int size = (pnlGameArea.Width + pnlGameArea.Height) / 40;
            if (size > MAXIMUM_BOARD_POSITION_SIZE) { size = MAXIMUM_BOARD_POSITION_SIZE; }

            // For horizontal/vertical spacing
            int defaultHorizontalSpacing = (pnlGameArea.Width / 2 - (boardSize * MARGIN + boardSize * size) / 2) + MARGIN / 2;
            int horizontalSpacing = defaultHorizontalSpacing;
            int verticalSpacing = MARGIN;

            // Iterate through each game position (label) within game area, updating position apropriately for each
            for (int i = 0; i < CurrentGameState.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGameState.BoardArray.GetLength(1); j++)
                {
                    CurrentGameState.BoardArray[i, j].Width = size;
                    CurrentGameState.BoardArray[i, j].Height = size;
                    CurrentGameState.BoardArray[i, j].Location = new Point(horizontalSpacing, verticalSpacing);
                    horizontalSpacing += CurrentGameState.BoardArray[i, j].Width + MARGIN;
                }
                horizontalSpacing = defaultHorizontalSpacing;
                verticalSpacing += CurrentGameState.BoardArray[i, i].Width + MARGIN;
            }

            // Style missles fired panel positioning
            StyleMissilesFiredPositioning();

            // Style progress panel positioning
            StyleProgressPanelPositioning();

            // Style manual firing panel positioning
            StyleManualControlsPositioning();

        }

        /// <summary>
        /// To be called after game panel is styled. 
        /// Styles pbxMissilesFired and its label so that it appears
        /// directly below the last boardposition row.
        /// </summary>
        private void StyleMissilesFiredPositioning()
        {
            // Get length of the board and a board position for size reference
            int boardSize = CurrentGameState.BoardArray.GetLength(0);
            Label boardPosition = CurrentGameState.BoardArray[boardSize - 1, 0];

            #region pbxMissilesFired Styling

            pbxMissilesFired.Location = new Point(boardPosition.Location.X, pnlGameArea.Height - pbxMissilesFired.Height);
            pbxMissilesFired.Width = (boardPosition.Width * boardSize) + (MARGIN * (boardSize - 1));
            pbxMissilesFired.Height = pnlGameArea.Height - ((boardPosition.Height * boardSize) + (MARGIN * (boardSize - 1)));
            pbxMissilesFired.Location = new Point(boardPosition.Location.X, pnlGameArea.Height - pbxMissilesFired.Height);

            #endregion

            #region lblMissilesFired Styling

            lblMissilesFired.Size = new Size(pbxMissilesFired.Width, pbxMissilesFired.Height);

            if (lblMissilesFired.Height / 4 > 0)
            {
                lblMissilesFired.Font = new Font("Impact", lblMissilesFired.Height / 4, FontStyle.Regular);
            }

            #endregion
        }

        #region Progress Panel Dynamic Styling
        /// <summary>
        /// To be called after game panel is styled. 
        /// Styles pnlProgress and its controls so that it appears
        /// on the right most side of the game area.
        /// </summary>
        private void StyleProgressPanelPositioning()
        {
            // Generic styling
            StyleResizeablePanel(pnlProgress, btnViewProgress);

            // X position is on right side of the game area. Y position varies based on minimized status
            pnlProgress.Location = new Point(pnlGameArea.Width - pnlProgress.Width, GetResizeablePanelYPosition(ProgressPanelMinimized));

            // Style all progress controls
            SetProgress(btnViewProgress, lblCarrierHealthHeader, pbrCarrierHealthIndicator);
            SetProgress(pbrCarrierHealthIndicator, lblBattleshipHealthHeader, pbrBattleshipHealthIndicator);
            SetProgress(pbrBattleshipHealthIndicator, lblCruiserHealthHeader, pbrCruiserHealthIndicator);
            SetProgress(pbrCruiserHealthIndicator, lblSubmarineHealthHeader, pbrSubmarineHealthIndicator);
            SetProgress(pbrSubmarineHealthIndicator, lblDestroyerHealthHeader, pbrDestroyerHealthIndicator);
        }

        /// <summary>
        /// Sets the styling of a label/progress bar based on the previous one.
        /// </summary>
        /// <param name="previousControl">The progress bar/button which should prepend the new one.</param>
        /// <param name="newProgressLabel">The label for the new progress bar.</param>
        /// <param name="newProgressBar">The new progress bar.</param>
        private void SetProgress(Control previousControl, Label newProgressLabel, ProgressBar newProgressBar)
        {
            // Styling the label
            newProgressLabel.Location = new Point(0, previousControl.Location.Y + previousControl.Height + MARGIN);
            newProgressLabel.Width = pnlProgress.Width;
            newProgressLabel.Font = new("Segoe UI", PROGRESS_HEADERS_FONT_SIZE, FontStyle.Regular);
            newProgressLabel.ForeColor = Color.White;

            // Styling the progress bar
            newProgressBar.Location = new Point(0, newProgressLabel.Location.Y + newProgressLabel.Height);
            newProgressBar.Width = pnlProgress.Width;
        }

        /// <summary>
        /// Minimizes/Maximizes progress panel
        /// </summary>
        private void ChangeProgressPanelSize()
        {
            // Change status and update location
            ProgressPanelMinimized = !ProgressPanelMinimized;
            pnlProgress.Location = new Point(pnlProgress.Location.X, GetResizeablePanelYPosition(ProgressPanelMinimized));

            // Update button
            if (ProgressPanelMinimized) 
            {
                ToolTips.SetToolTip(btnViewProgress, "Click here, or press 'ALT + G' to view game progress (boat health).");
                btnViewProgress.Text = "VIEW &GAME PROGRESS";   
            }
            else 
            {
                ToolTips.SetToolTip(btnViewProgress, "Click here, or press 'ALT + G' to hide game progress.");
                btnViewProgress.Text = "HIDE &GAME PROGRESS"; 
            }
        }

        #endregion

        #region Manual Controls Panel Dynamic Styling
        private void StyleManualControlsPositioning()
        {
            // Generic styling
            StyleResizeablePanel(pnlManualControls, btnViewManualControls);

            // X position is simply locked to th left side (0). Y position varies based on minimized value
            pnlManualControls.Location = new Point(0, GetResizeablePanelYPosition(ManualControlsPanelMinimized));

            // X Coordinates Entering
            int xPlacement = pnlManualControls.Width / 2 - nudManualXCoordinates.Width / 2;
            lblManualXCoordinatesHeader.Location = new Point(xPlacement, btnViewManualControls.Location.Y + btnViewManualControls.Height + MARGIN);
            nudManualXCoordinates.Location = new Point(xPlacement, lblManualXCoordinatesHeader.Location.Y + lblManualXCoordinatesHeader.Height );

            // Y Coordinates Entering
            lblManualYCoordinatesHeader.Location = new Point(xPlacement, nudManualXCoordinates.Location.Y + nudManualXCoordinates.Height + MARGIN * 2);
            nudManualYCoordinates.Location = new Point(xPlacement, lblManualYCoordinatesHeader.Location.Y + lblManualYCoordinatesHeader.Height);

            // Firing button
            btnManualFire.Location = new Point(pnlManualControls.Width / 2 - btnManualFire.Width / 2, 
                nudManualYCoordinates.Location.Y + nudManualYCoordinates.Height + MARGIN * 2);

        }

        /// <summary>
        /// Minimizes/Maximizes manual controls panel
        /// </summary>
        private void ChangeManualControlsPanelSize()
        {
            // Change status and update location
            ManualControlsPanelMinimized = !ManualControlsPanelMinimized;
            pnlManualControls.Location = new Point(pnlManualControls.Location.X, GetResizeablePanelYPosition(ManualControlsPanelMinimized));

            // Update button
            if (ManualControlsPanelMinimized) 
            {
                ToolTips.SetToolTip(btnViewManualControls, "For keyboard controls, click here or press 'ALT + K'.");
                btnViewManualControls.Text = "VIEW &KEYBOARD CONTROLS"; 
            }
            else 
            {
                ToolTips.SetToolTip(btnViewManualControls, "To hide keyboard controls, click here or press 'ALT + K'.");
                btnViewManualControls.Text = "HIDE &KEYBOARD CONTROLS"; 
            }
        }

        #endregion

        #region Resizable Panel Generic Styling

        /// <summary>
        /// Sets properties which both progress panel and manual controls panel should get
        /// </summary>
        /// <param name="pnlToStyle">The panel to style.</param>
        /// <param name="btnToStyle">The corresponding button.</param>
        private void StyleResizeablePanel(Panel pnlToStyle, Button btnToStyle)
        {
            // Set width so it fills space between game area and start/end of board array
            pnlToStyle.Width = pnlGameArea.Width - (CurrentGameState.BoardArray[0, CurrentGameState.BoardArray.GetLength(1) - 1].Location.X + MARGIN * 6);
            pnlToStyle.Height = pnlGameArea.Height;

            // Width of view button should match
            btnToStyle.Width = pnlToStyle.Width;
            btnToStyle.Location = new Point(0, 0);
        }

        /// <summary>
        /// Returns an integer value for resizeable panels based on a minimized paramater.
        /// </summary>
        /// <param name="IsMinimized"></param>
        /// <returns>Maximized panel Y position if false, else minimized</returns>
        private int GetResizeablePanelYPosition(bool isMinimized)
        {
            // If it should be minimized, the panel should be at the bottom of the game area.
            if (isMinimized) { return pnlGameArea.Height - MIMIMIZED_PANEL_HEIGHT; }

            // Otherwise, it should fill half the game area with some added margin
            else { return (pnlGameArea.Height / 2) - (MARGIN * 10); }
        }

        #endregion

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
