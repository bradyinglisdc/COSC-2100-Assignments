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
        private GameState CurrentGameState { get; set; }

        // Window Control
        private bool ProgressPanelMinimized { get; set; }

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

            // Game State
            CurrentGameState = new GameState();

            // Min/Maximize Panel Statuses
            ProgressPanelMinimized = false;

            // Header/game setup
            lblHeader = new Label();
            pnlGameSetup = new Panel();
            btnNewGame = new Button();
            btnExitApplication = new Button();
            btnRestartGame = new Button();

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

            pbxMisslesFired = new PictureBox();
            lblMisslesFired = new Label();

            lblStartGamePrompt = new Label();

            ToolTips = new ToolTip();

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
            pnlGameSetup.Controls.Add(btnRestartGame);

            // Game Area
            Controls.Add(pnlGameArea);
            pnlGameArea.Controls.Add(pbxBattleshipBackground);
            pnlGameArea.Controls.Add(lblStartGamePrompt);

            // Missle Tracking
            pnlGameArea.Controls.Add(pbxMisslesFired);
            pbxMisslesFired.Controls.Add(lblMisslesFired);

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
        }

        #endregion

        #region Event Handlers

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
        /// Starts a nw game after prompting the user.
        /// </summary>
        /// <param name="sender">New game button.</param>
        /// <param name="e">Any arguments added.</param>
        private void btnNewGame_Click(object? sender, EventArgs e)
        {
            StartGame();
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
        /// Calls method to fire a missle at boardPosition's coordinates.
        /// </summary>
        /// <param name="sender">The boardPosition label.</param>
        /// <param name="e">Any arguments added.</param>
        private void boardPosition_Click(object? sender, EventArgs e)
        {
            // Ensure sender is label before explicit cast
            if (!(sender is Label)) { return; }
            FireMissle((Label)sender);
        }

        /// <summary>
        /// Minimizes/Maximizes progress panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewProgress_Click(object? sender, EventArgs e)
        {
            ChangeProgressPanelSize();
        }

        #endregion

        #region Game Logic

        /// <summary>
        /// Prompts user to select difficulty before starting game.
        /// </summary>
        private void StartGame()
        {
            // Removes start game prompt - it should never need to appear again.
            pnlGameArea.Controls.Remove(lblStartGamePrompt); 

            // Resets game state and board state
            CurrentGameState.Reset();

            // Sets up game area
            SetupGameBoard();
        }

        /// <summary>
        /// Clears current board, then completely re styles/adds new one.
        /// </summary>
        private void SetupGameBoard()
        {          
            // Remove labels
            foreach (Label boardPosition in CurrentGameState.BoardArray) { pnlGameArea.Controls.Remove(boardPosition); }
            
            // Add and re-style labels, set default board up
            SetDefaultBoard();
            SetMissleTracker();
            SetGameProgress();
            StyleActiveGamePositioning();
        }

        /// <summary>
        /// Adds each label (BoardPositions) to pnlGameArea, as well as some default properties
        /// that should only be set once when the game is started, as well as event handlers.
        /// </summary>
        private void SetDefaultBoard()
        {
            // Iterates through board array, updating status to default
            foreach (Label boardPosition in CurrentGameState.BoardArray) 
            {
                ToolTips.SetToolTip(boardPosition, $"Click here to fire a missle!");
                boardPosition.Click += new EventHandler(boardPosition_Click);
                boardPosition.BackColor = Color.FromArgb(255, 10, 10, 10);
                boardPosition.MaximumSize = new Size(MAXIMUM_BOARD_POSITION_SIZE, MAXIMUM_BOARD_POSITION_SIZE);

                pnlGameArea.Controls.Add(boardPosition);
                boardPosition.BringToFront();
            }
        }

        /// <summary>
        /// Ensures missle tracker is in front of all controls,
        /// then updates it's label to display missles fired.
        /// </summary>
        private void SetMissleTracker()
        {
            pbxMisslesFired.BringToFront();
            UpdateMisslesFiredLabel();
        }

        /// <summary>
        /// Ensures game progress is in front of all controls,
        /// then updates it's children to display game progress.
        /// </summary>
        private void SetGameProgress()
        {
            pnlProgress.BringToFront();
            UpdateGameProgress();
        }

        /// <summary>
        /// Updates front end to reflect boat hits.
        /// </summary>
        private void UpdateGameProgress()
        {
            UpdateProgressControlGroup(lblCarrierHealthHeader, pbrCarrierHealthIndicator, CurrentGameState.CarrierHealth, BS.Boats.Carrier);
            UpdateProgressControlGroup(lblBattleshipHealthHeader, pbrBattleshipHealthIndicator, CurrentGameState.BattleshipHealth, BS.Boats.Battleship);
            UpdateProgressControlGroup(lblCruiserHealthHeader, pbrCruiserHealthIndicator, CurrentGameState.CruiserHealth, BS.Boats.Cruiser);
            UpdateProgressControlGroup(lblSubmarineHealthHeader, pbrSubmarineHealthIndicator, CurrentGameState.SubmarineHealth, BS.Boats.Submarine);
            UpdateProgressControlGroup(lblDestroyerHealthHeader, pbrDestroyerHealthIndicator, CurrentGameState.DestroyerHealth, BS.Boats.Destroyer);
        }

        /// <summary>
        /// Updates a label and progress based on the health of a given ship.
        /// </summary>
        /// <param name="boatHeader">The boat type and hit progress.</param>
        /// <param name="boatProgress">The destruction progress bar.</param>
        /// <param name="boatHealth">The boat's remainining health.</param>
        /// <param name="boatType">The boat type.</param>
        private void UpdateProgressControlGroup(Label boatHeader, ProgressBar boatProgress, int boatHealth, BS.Boats boatType)
        {
            double boatSize = BS.GetBoatSize(boatType);
            double health = boatHealth;
            boatHeader.Text = $"{boatType.ToString()} ({boatSize - boatHealth}/{boatSize} Hits)";

            // Avoid dividing by 0
            if (boatSize - boatHealth == 0 ) { boatProgress.Value = 0; }
            else { boatProgress.Value = (int)( ((boatSize - health) / boatSize) * 100.0); }
        }

        /// <summary>
        /// Gets the coordinates of the label to fire on, then proceeds to attempt to fire.
        /// Updates board in case of hit or miss.
        /// </summary>
        private void FireMissle(Label boardPosition)
        {
            boardPosition.Click -= boardPosition_Click;
            int[] positionCoordinates = GetLabelCoordinates(boardPosition);

            BS.CheckForHit(positionCoordinates, CurrentGameState);
            UpdateBoardPosition(positionCoordinates);
            UpdateMisslesFiredLabel();
            UpdateGameProgress();
        }

        /// <summary>
        /// Visually updates a board position based on the given coordinates.
        /// </summary>
        /// <param name="coordinates">Label to update.</param>
        private void UpdateBoardPosition(int[] coordinates)
        {
            if (BS.board[coordinates[0] + 1, coordinates[1] + 1] == BS.BoardStatus.Hit)
            {
                CurrentGameState.BoardArray[coordinates[0], coordinates[1]].BackColor = Color.Red;
                ToolTips.SetToolTip(CurrentGameState.BoardArray[coordinates[0], coordinates[1]], $"You struck a ship here!");
                return;
            }

            CurrentGameState.BoardArray[coordinates[0], coordinates[1]].BackColor = Color.White;
            ToolTips.SetToolTip(CurrentGameState.BoardArray[coordinates[0], coordinates[1]], $"You missed here!");
        }

        /// <summary>
        /// Searches through board array, grabs the x and y (or rather y and x) coordinates of 
        /// the board position, returns as integer array.
        /// </summary>
        /// <param name="boardPosition">The label which needs coordinates.</param>
        /// <returns></returns>
        private int[] GetLabelCoordinates(Label boardPosition)
        {
            int[] coordinates = { 0, 0 };

            for (int i = 0; i < CurrentGameState.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGameState.BoardArray.GetLength(1); j++)
                {
                    if (CurrentGameState.BoardArray[i, j] == boardPosition)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        /// <summary>
        /// Updates missles fired labale to accurately reflect user's turns.
        /// </summary>
        private void UpdateMisslesFiredLabel()
        {
            lblMisslesFired.Text = $"MISSLES FIRED: {CurrentGameState.MisslesFired}\nBOATS SUNK: {CurrentGameState.GetBoatsSunk()}";
        }
        
        #endregion

        #region Cleanup Methods

        /// <summary>
        /// Closes the form if the user agrees to the prompt.
        /// </summary>
        private void ExitApplication()
        {
            if (MessageBox.Show("Are you sure you want to exit the application? None of your game data will save.", "Exit Battleship?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
#endregion
