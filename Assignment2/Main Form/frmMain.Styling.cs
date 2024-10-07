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

        private static Size FORM_MINIMUM_SIZE = new Size(720, 400);
        private static Size MAXIMUM_SETUP_PANEL_SIZE = new Size(0, 29);

        private static int MAXIMUM_BUTTON_FONT_SIZE = 25;
        private static int MINIMUM_BUTTON_FONT_SIZE = 8;

        private const int MARGIN = 10;

        #endregion

        #region Properties

        // Header
        private Label lblHeader { get; set; }
        private Panel pnlGameSetup { get; set; }
        private Button btnNewGame { get; set; }
        private Button btnExitApplication { get; set; }

        // Game area
        private Panel pnlGameArea { get; set; }
        private Label lblStartGamePrompt { get; set; }

        // Missles fired
        private Panel pnlMisslesFired { get; set; }
        private Label lblMisslesFired { get; set; }

        // Progress panel
        private Panel pnlProgress { get; set; }
        private Button btnViewProgress { get; set; }

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
            pnlGameSetup.BackColor = Color.FromArgb(50, 50, 50);

            // btnNewGame
            ToolTips.SetToolTip(btnNewGame, "Click here, or press 'Alt + N' to reset all progress and start a new game.");
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "&NEW GAME";
            btnNewGame.BackColor = Color.White;

            // btnExitApplication
            ToolTips.SetToolTip(btnExitApplication, "Click here, or press 'Alt + X' to exit application.");
            btnExitApplication.TabIndex = 1;
            btnExitApplication.Text = "E&XIT";
            btnExitApplication.BackColor = Color.White;

            #endregion

            #region pnlGameArea

            // Game area
            pnlGameArea.BackColor = Color.FromArgb(128, 255, 255, 255);

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
            btnNewGame.Size = new Size(ClientSize.Width / 9, pnlGameSetup.Height);
            btnNewGame.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // btnExitApplication
            btnExitApplication.Size = new Size(ClientSize.Width / 11, pnlGameSetup.Height);
            btnExitApplication.Font = new Font("Segoe UI", pnlGameSetup.Height / 3, FontStyle.Regular);

            // Button locations
            int controlCentre = pnlGameSetup.Width / 2 - (btnNewGame.Width + btnExitApplication.Width) / 2;
            btnNewGame.Location = new Point(controlCentre, 0);
            btnExitApplication.Location = new Point(btnNewGame.Location.X + btnNewGame.Width, 0);

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

            // Start game prompt
            lblStartGamePrompt.Size = new Size(ClientSize.Width, relativePosition / 25);
            lblStartGamePrompt.Font = new Font("Segoe UI", lblHeader.Height / 5, FontStyle.Regular);
            lblStartGamePrompt.Location = new Point(0, pnlGameArea.Height / 2 - lblStartGamePrompt.Height / 2);

            // Style game area based on game happening status
            if (CurrentGameState.GameHappening)
            {
                StyleActiveGame();
            }
            else
            {
                StyleNoActiveGame();
            }

            #endregion

        }

        /// <summary>
        /// Hides start game prompt and styles each label in array of labels for this game.
        /// </summary>
        private void StyleActiveGame()
        {

        }

        /// <summary>
        /// Displays prompt informing user there is no active game.
        /// </summary>
        private void StyleNoActiveGame()
        {
            lblStartGamePrompt.Visible = true;
        }




        #endregion

    }
}
#endregion
