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

        // Game variables
        private GameState CurrentGameState { get; set; }

        #endregion

        /// <summary>
        /// Constructor calls setters, styles and subscribes event handlers for all controls.
        /// </summary>
        public frmMain()
        {
            #region Auto generated initialization method(s)

            InitializeComponent();

            #endregion

            #region Instantiation
            CurrentGameState = new GameState();

            lblHeader = new Label();
            pnlGameSetup = new Panel();
            btnNewGame = new Button();
            btnExitApplication = new Button();

            pnlGameArea = new Panel();
            lblStartGamePrompt = new Label();

/*            pnlMisslesFired = new Panel();
            lblMisslesFired = new Label();

            pnlProgress = new Panel();
            btnViewProgress = new Button();
*/
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

            // Game Area
            Controls.Add(pnlGameArea);
            pnlGameArea.Controls.Add(lblStartGamePrompt);

            // Missles Fired
/*            Controls.Add(pnlMisslesFired);
            pnlMisslesFired.Controls.Add(lblMisslesFired);

            // Progress Panel
            Controls.Add(pnlProgress);
            pnlProgress.Controls.Add(btnViewProgress);
*/
            #endregion

            #region Styling and Subscribing Event Handlers

            StyleControls();
            SubscribeEventHandlers();

            #endregion
        }

        /// <summary>
        /// Clears current board, then creates 2d array of labels representing game board, adds to Controls, styles.
        /// </summary>
        private void SetupGameBoard()
        {
            // Much faster to clear and add labels off screen
            Controls.Remove(pnlGameArea);
            pnlGameArea.Controls.Clear();
      
            // Grabs the board array and adds it to th
            foreach (Label boardPosition in CurrentGameState.BoardArray)
            {
                pnlGameArea.Controls.Add(boardPosition);
            }

            // Style labels
            StyleActiveGamePositioning();
        }

        private void SubscribeEventHandlers()
        {
            Resize += new EventHandler(frmMain_Resize);
            btnNewGame.Click += new EventHandler(btnNewGame_Click);
            btnExitApplication.Click += new EventHandler(btnExitApplication_Click);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object? sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Calls method to close the application after prompting user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitApplication_Click(object? sender, EventArgs e)
        {
            ExitApplication();
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
        /// Updates status of each label.
        /// </summary>
        private void UpdateBoard()
        {
            // Iterates through board array, updating status to match the board status found in BS class.
            for (int i = 0; i < CurrentGameState.BoardArray.GetLength(0); i++)
            {
                for (int  j = 0; j < CurrentGameState.BoardArray.GetLength(1); j++)
                {
                    if (BS.board[i, j] == BS.BoardStatus.Hit) 
                    { 
                        CurrentGameState.BoardArray[i, j].BackColor = Color.Red;
                        break;
                    }

                    if (BS.board[i, j] == BS.BoardStatus.Miss)
                    {
                        CurrentGameState.BoardArray[i, j].BackColor = Color.White;
                        break;
                    }

                    else
                    {
                        CurrentGameState.BoardArray[i, j].BackColor = Color.FromArgb(125, 10, 10, 10);
                    }
                }
            }
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
