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
                NumberToGuess = Tools.GetRandomNumber(1, DifficultyRange);
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
            // Set game default rules/settings
            SetDefaultRules();

            // Instantiate all controls on constructor call
            SetAllProperties();

            // Style each control
            StyleAllControls();

            // Subscribe event handler methods
            SubscribeEventHandlers();
        }
        #endregion

        #region Game Logic Setup Methods
        /// <summary>
        /// All default rules set here.
        /// </summary>
        private void SetDefaultRules()
        {
            Attempts = GuessTheNumberSettings.StartingAttempts;
            cbxDifficultySelection.SelectedIndex = GuessTheNumberSettings.StartingDifficultyIndex;
        }

        /// <summary>
        /// Subscribes every event handler needed for the game.
        /// </summary>
        private void SubscribeEventHandlers()
        {
            cbxDifficultySelection.SelectedIndexChanged += new EventHandler(cboDifficultySelection_SelectedIndexChanged);
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
        #endregion

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

            // Update random number apropriately

        }
        #endregion

    }
    #endregion
}
#endregion
