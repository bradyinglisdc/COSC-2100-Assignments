/*
 * Title: frmMain.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-06
 * Purpose: To programatially call the methods which style the battleship game, subscribe
 * event handlers, and ensure positioning when the form resizes.
 */

#region Namespace Definition
namespace Assignment2
{
    /// <summary>
    /// This portion of the partial class is responsible
    /// for programatic styling of the controls, as well as
    /// subscribing event handlers where needed and providing 
    /// an access point to start the game.
    /// </summary>
    public partial class frmMain : Form
    {

        #region Properties

        // Game State
        public GameState CurrentGameState { get; set; }

        // Window Control
        private bool ProgressPanelMinimized { get; set; }
        private bool ManualControlsPanelMinimized { get; set; }

        #endregion

        /// <summary>
        /// Constructor calls setters, styles and subscribes event handlers for all controls.
        /// </summary>
        public frmMain()
        {
            #region Auto generated initialization method(s)

            InitializeComponent();

            #endregion

            #region Control and Game State Instantiation

            // Min/Maximize Panel Statuses
            ProgressPanelMinimized = false;
            ManualControlsPanelMinimized = false;

            // Header/game setup
            lblHeader = new Label();
            pnlGameSetup = new Panel();
            btnNewGame = new Button();
            btnExitApplication = new Button();
            /*btnRestartGame = new Button();*/

            // Game area
            pnlGameArea = new Panel();
            pbxBattleshipBackground = new PictureBox();

            #region Progress Panel Instantiation

            // The Panel
            pnlProgress = new Panel();
            btnViewProgress = new Button();

            // Panel Controls
            lblCarrierHealthHeader = new Label();
            pbrCarrierHealthIndicator = new ProgressBar();

            lblBattleshipHealthHeader = new Label();
            pbrBattleshipHealthIndicator = new ProgressBar();

            lblCruiserHealthHeader = new Label();
            pbrCruiserHealthIndicator = new ProgressBar();

            lblSubmarineHealthHeader = new Label();
            pbrSubmarineHealthIndicator = new ProgressBar();

            lblDestroyerHealthHeader = new Label();
            pbrDestroyerHealthIndicator = new ProgressBar();

            #endregion

            #region Manual Firing Instantiation
            
            pnlManualControls = new Panel();
            btnViewManualControls = new Button();
            lblManualXCoordinatesHeader = new Label();
            nudManualXCoordinates = new NumericUpDown();
            lblManualYCoordinatesHeader = new Label();
            nudManualYCoordinates = new NumericUpDown();
            btnManualFire = new Button();

            #endregion

            pbxMissilesFired = new PictureBox();
            lblMissilesFired = new Label();

            lblStartGamePrompt = new Label();

            ToolTips = new ToolTip();

            // Game State
            CurrentGameState = new GameState(ToolTips, new EventHandler(boardPosition_Click));

            #endregion

            #region Game Setup

            SetupControls();

            #endregion
        }

        #region Controls Setup

        /// <summary>
        /// Adds controls to the form, styles them, and adds event handlers where needed
        /// </summary>
        private void SetupControls()
        {
            #region Adding Controls to Parents

            /* Controls are added in order of top to bottom appearence on the form */

            // Header
            Controls.Add(lblHeader);
            Controls.Add(pnlGameSetup);
            pnlGameSetup.Controls.Add(btnNewGame);
            pnlGameSetup.Controls.Add(btnExitApplication);
            /*pnlGameSetup.Controls.Add(btnRestartGame);*/

            // Game Area
            Controls.Add(pnlGameArea);
            pnlGameArea.Controls.Add(pbxBattleshipBackground);
            pnlGameArea.Controls.Add(lblStartGamePrompt);

            // Missle Tracking
            pnlGameArea.Controls.Add(pbxMissilesFired);
            pbxMissilesFired.Controls.Add(lblMissilesFired);

            // Game Progress
            pnlGameArea.Controls.Add(pnlProgress);
            pnlProgress.Controls.Add(btnViewProgress);

            pnlProgress.Controls.Add(lblCarrierHealthHeader);
            pnlProgress.Controls.Add(pbrCarrierHealthIndicator);

            pnlProgress.Controls.Add(lblBattleshipHealthHeader);
            pnlProgress.Controls.Add(pbrBattleshipHealthIndicator);

            pnlProgress.Controls.Add(lblCruiserHealthHeader);
            pnlProgress.Controls.Add(pbrCruiserHealthIndicator);

            pnlProgress.Controls.Add(lblSubmarineHealthHeader);
            pnlProgress.Controls.Add(pbrSubmarineHealthIndicator);

            pnlProgress.Controls.Add(lblDestroyerHealthHeader);
            pnlProgress.Controls.Add(pbrDestroyerHealthIndicator);

            // Manual Firing
            pnlGameArea.Controls.Add(pnlManualControls);
            pnlManualControls.Controls.Add(btnViewManualControls);

            pnlManualControls.Controls.Add(lblManualXCoordinatesHeader);
            pnlManualControls.Controls.Add(nudManualXCoordinates);

            pnlManualControls.Controls.Add(lblManualYCoordinatesHeader);
            pnlManualControls.Controls.Add(nudManualYCoordinates);

            pnlManualControls.Controls.Add(btnManualFire);

            #endregion

            #region Styling and Subscribing Event Handlers

            StyleControls();
            SubscribeEventHandlers();

            #endregion
        }

        private void SubscribeEventHandlers()
        {
            Resize += new EventHandler(frmMain_Resize);
            btnNewGame.Click += new EventHandler(btnNewGame_Click);
            btnExitApplication.Click += new EventHandler(btnExitApplication_Click);
            btnViewProgress.Click += new EventHandler(btnViewProgress_Click);
            btnViewManualControls.Click += new EventHandler(btnViewManualControls_Click);
            btnManualFire.Click += new EventHandler(btnManualFire_Click);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Starts a new game after prompting the user.
        /// </summary>
        /// <param name="sender">New game button.</param>
        /// <param name="e">Any arguments added.</param>
        private void btnNewGame_Click(object? sender, EventArgs e)
        {
            if (CurrentGameState.GameHappening && MessageBox.Show("Are you sure you want to start a new game? All of your progress" +
                "will be lost.", "Start New Game?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            StartGame();
        }

        /// <summary>
        /// To be subscribed to each board position in the game board.
        /// Simply updates progress panels and checks for a win.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boardPosition_Click(object? sender, EventArgs e)
        {
            UpdateProgress();
        }

        /// <summary>
        /// Fires at the specified manual coordinates.
        /// </summary>
        /// <param name="sender">The manual firing button.</param>
        /// <param name="e">Any arguments added.</param>
        private void btnManualFire_Click(object? sender, EventArgs e)
        {
            // Simply fire on the entered coordinates. Coordinates are swapped to allign with 2d array.
            int[] coordinates = { (int)nudManualYCoordinates.Value - 1, (int)nudManualXCoordinates.Value - 1 };
            CurrentGameState.FireOnCoordinates(coordinates);
            UpdateProgress();
        }


        /// <summary>
        /// When form resizes, restyle controls positioning/sizing for proper formatting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object? sender, EventArgs e)
        {
            StylePositioning();
        }

        /// <summary>
        /// Calls method to close the application after prompting user.
        /// </summary>
        /// <param name="sender">Exit application button.</param>
        /// <param name="e">Any arguments added.</param>
        private void btnExitApplication_Click(object? sender, EventArgs e)
        {
            ExitApplication();
        }

        /// <summary>
        /// Minimizes/Maximizes progress panel.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Any arguments added.</param>
        private void btnViewProgress_Click(object? sender, EventArgs e)
        {
            // Just return if senderis not a Control
            if (!(sender is Control)) { return; }
            ((Control)sender).Focus();
            ChangeProgressPanelSize();
        }

        /// <summary>
        /// Minimimzes/Maximizes manual controls panel.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Any arguments added.</param>
        private void btnViewManualControls_Click(object? sender, EventArgs e)
        {
            // Just return if senderis not a Control
            if (!(sender is Control)) { return; }
            ((Control)sender).Focus();
            ChangeManualControlsPanelSize();
        }

        #endregion

    }
}
#endregion
