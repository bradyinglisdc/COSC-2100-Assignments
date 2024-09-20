/*
 * Title: GuessTheNumberGamePanel Backend
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This class contains the back-end design for the guess the number game.
 * It is a child of the Panel class to promote modularity within the main form's logic.
 * 
 * Essentially, this class serves as a premade panel for quickly and cleany instantiating
 * new instances of the Guess The Number Game.
 * 
 * This portion of the partial class contains the backend/logic for the game.
 * The fronttend/UI is contained within the first partial definition of this class (GuessTheNumberGamePanel.Frontend.cs).
 */

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

# region Namespac Definition
namespace ClassExercise1
{
    #region Class definition
    public partial class GuessTheNumberGamePanel
    {
        #region Backing Members
        private int _difficultyRange;
        #endregion

        #region Properties
        public int Attempts
        {
            get;
            set;
        }
        public int DifficultyRange
        {
            get { return _difficultyRange; }
            set
            {
                // Setter updates difficulty range and gens number within that range
                _difficultyRange = value;
                NumberToGuess = Tools.GetRandomNumber(GuessTheNumberSettings.MinimumGuess, DifficultyRange);
            }
        }
        public int NumberToGuess
        {
            get;
            set;
        }

        #endregion

        #region Constructor(s)
        public GuessTheNumberGamePanel()
        {
            // Instantiate all controls on constructor call
            SetAllProperties();

            // Style each control
            StyleAllControls();

            // Subscribe event handler methods
            SubscribeEventHandlers();

            // Set game default rules/settings
            SetDefaultRules();
        }
        #endregion

        #region Game Logic Setup Methods
        /// <summary>
        /// All default rules set here.
        /// </summary>
        private void SetDefaultRules()
        {
            // Attempts and difficulty
            Attempts = GuessTheNumberSettings.StartingAttempts;
            cbxDifficultySelection.SelectedIndex = GuessTheNumberSettings.StartingDifficultyIndex; // Triggers index change
        }

        /// <summary>
        /// Subscribes every event handler needed for the game.
        /// </summary>
        private void SubscribeEventHandlers()
        {
            cbxDifficultySelection.SelectedIndexChanged += new EventHandler(cboDifficultySelection_SelectedIndexChanged);
            btnBegin.Click += new EventHandler(btnBegin_Clicked);
            btnSubmitGuess.Click += new EventHandler(btnSubmitGuess_Clicked);
            btnPlayAgain.Click += new EventHandler(btnPlayAgain_Clicked);
            btnExitGame.Click += new EventHandler(btnExitGame_Clicked);
        }
        #endregion

        #region Event Handler Methods
        /// <summary>
        /// Method is called on difficulty index change.
        /// Will be called when initial change is made to setup, thus setting
        /// the starting difficulty to the one described in GuessTheNumberSettings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDifficultySelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDifficulty();
        }

        /// <summary>
        /// Method is called when begin button is pressed.
        /// Starts game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBegin_Clicked(object sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Method is called when submit guess button is pressed. Checks guess.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitGuess_Clicked(object sender, EventArgs e)
        {
            CheckGuess();
        }

        /// <summary>
        /// Method is called when play again button is clicked.
        /// Just instantiate a new instance of the panel.
        /// </summary>
        private void btnPlayAgain_Clicked(object sender, EventArgs e)
        {
            // Grab parent, call change game method on it.
            frmMain parent = (frmMain)Parent;
            parent.ChangeGame(GameName);
        }
        #endregion

        /// <summary>
        /// Method is called when exit game button is clicked.
        /// Removes this game insance from form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        private void btnExitGame_Clicked(object sender, EventArgs e)
        {
            CloseGame();
        }

        #region General logic methods
        /// <summary>
        /// Changes difficuly based off cboDifficultySelection's current index
        /// </summary>
        private void ChangeDifficulty()
        {
            // Check index against index's described in settings
            switch (cbxDifficultySelection.SelectedIndex)
            {
                case 0:
                    ChangeDifficulty(GuessTheNumberSettings.EasyMode);
                    break;
                case 1:
                    ChangeDifficulty(GuessTheNumberSettings.MediumMode);
                    break;
                default:
                    ChangeDifficulty(GuessTheNumberSettings.HardMode);
                    break;
            }
        }

        /// <summary>
        /// Changes difficulty settings based on the range parameter.
        /// </summary>
        /// <param name="range">Range user will guess within</param>
        private void ChangeDifficulty(int range)
        {
            // Update max label apropriately
            lblMaximumGuess.Text = range.ToString();

            // Update difficulty range
            DifficultyRange = range;
        }
        #endregion

        /// <summary>
        /// Verifies user wants to close, then closes.
        /// </summary>
        private void CloseGame()
        {
            // Close after msg box prompt to user returns true
            if (MessageBox.Show("Exit game? Your progress will be lost", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Parent.Controls.Remove(this);
            }
        }

        #region Main Logic
        /// <summary>
        /// Starts the game, allowing user to attempt to guess number
        /// </summary>
        private void StartGame()
        {
            // Show play area and set difficulty
            pnlPlayArea.Show();
            nudUserGuess.Maximum = DifficultyRange;

            // Disable begin button
            btnBegin.Enabled = false;

            // Change output to inform user game start
            lblGuessOutput.Text = GuessTheNumberSettings.GameStartedString;
        }
        
        /// <summary>
        /// Checks user guess against number to guess.
        /// Tells them when to guess higher, or lower, or a win condition happens.
        /// </summary>
        private void CheckGuess()
        {
            // Incriment attempts
            Attempts++;
            
            // Check for win condition
            if (nudUserGuess.Value > NumberToGuess) { lblGuessOutput.Text = nudUserGuess.Value + GuessTheNumberSettings.GuessHigherOutput + lblGuessOutput.Text; }
            else if (nudUserGuess.Value < NumberToGuess) { lblGuessOutput.Text = nudUserGuess.Value + GuessTheNumberSettings.GuessLowerOutput + lblGuessOutput.Text; }
            else
            {
                // On win condition, disable additional guessing and prompt user to play again.
                lblGuessOutput.Text = nudUserGuess.Value + GuessTheNumberSettings.GuessWinnerOutput + $"It took you {Attempts} attempts.\n";
                btnPlayAgain.Show();
                btnSubmitGuess.Enabled = false;
                nudUserGuess.Enabled = false;
                cbxDifficultySelection.Enabled = false;
            }

            // Update attempts on label on screen
            lblAttempts.Text = $"Attempts: {Attempts}";
        }

        #endregion

    }
    #endregion
}
#endregion
