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
using System.Windows.Forms;
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
        public GameState BoundGameState
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
            // Instantiate a fresh game state - constructor randomly chooses first turn
            BoundGameState = new GameState(txtPlayerOneNameInput.Text, txtPlayerTwoNameInput.Text);

            // Instantiate and style a new board area
            SetupBoardArea();
        }

        /// <summary>
        /// Removes setup controls and adds board controls.
        /// </summary>
        private void SetupBoardArea()
        {
            this.Controls.Remove(pnlGameSetup);
            pnlGameBoard = new BoardPanel();
        }
        #endregion

    }
    #endregion
}
#endregion