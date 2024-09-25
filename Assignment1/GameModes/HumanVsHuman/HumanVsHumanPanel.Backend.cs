/*
 * Title: HumanVsHumanPanel.Backend.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-25
 * Purpose: This panel contains the back-end logic for the HumanVsHuman tic tac toe game.
 * Front-end logic is found within the HumanVsHumanPanel.cs file.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public partial class HumanVsHumanPanel
    {
        #region Properties
        /// <summary>
        /// The gamestate bound to this game instance - to be instantiated on each new game.
        /// </summary>
        private GameState BoundGameState
        {
            get;
            set;
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Calls parent constructor, instantiates setup controls and adds appropriate event handlers
        /// </summary>
        public HumanVsHumanPanel() : base()
        {
            InstantiateSetupControls();
            SubscribeSetupEventHandlers();
        }
        #endregion

        #region Game Setup Methods
        /// <summary>
        /// All actual game logic starts here.
        /// This method instantiates, styles and subscribes event handler methods
        /// to all game controls, randomly chooses a first turn, and allows the game
        /// to begin.
        /// </summary>
        private void StartGame()
        {
            // Get the first turn
            bool playerOneGoesFirst = GameState.GetFirstTurn();

            // Instantiate a fresh game state based on the first turn (this will swap player 1 and 2 if needed)
            if (playerOneGoesFirst) { BoundGameState = new GameState(txtPlayerOneNameInput.Text, txtPlayerTwoNameInput.Text); }
            else { BoundGameState = new GameState(txtPlayerTwoNameInput.Text, txtPlayerOneNameInput.Text); }

            // Set the current turn to player one
            BoundGameState.PlayerOneTurn = true;

            // Instantiate and style a new board area
            SetupBoardArea();

        }

        /// <summary>
        /// Removes setup controls and adds board controls.
        /// </summary>
        private void SetupBoardArea()
        {
            this.Controls.Remove(pnlGameSetup);
        }
        #endregion

    }
    #endregion
}
#endregion