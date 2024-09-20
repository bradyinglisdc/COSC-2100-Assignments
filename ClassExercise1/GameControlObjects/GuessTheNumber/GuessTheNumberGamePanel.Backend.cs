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
        #region Properties
        public int Attempts
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
            /*SubscribeEventHandlers();*/
        }
        #endregion

        #region Game Logic Setup Methods
        /// <summary>
        /// All default rules set here
        /// </summary>
        private void SetDefaultRules()
        {
            
        }
        #endregion
    }
    #endregion
}
#endregion
