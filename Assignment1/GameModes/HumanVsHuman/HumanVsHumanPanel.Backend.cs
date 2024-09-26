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
            InstantiateControls();
            SubscribeEventHandlers();
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
            this.Controls.Add(lblCurrentPlayerHeader);
            this.Controls.Add(btnPlayAgain);
            pnlGameBoard = new BoardPanel();
            pnlGameInfo = new GameInfoPanel(BoundGameState);
        }
        #endregion

        #region Game Logic Methods
        /// <summary>
        /// Checks for win/draw state then updates current player label header.
        /// If there is a win, it belongs to the previous turn player.
        /// </summary>
        public void UpdateCurrentPlayerLabel()
        {
            // Get the board state
            string labelText = BoundGameState.PlayerOneTurn ? $"{BoundGameState.PlayerOneName}'s turn!" : $"{BoundGameState.PlayerTwoName}'s turn!";
            BoardState boardState = BoundGameState.GetBoardState();
            
            // Check and update text based on result
            // The previous player will be the winner, so these commands appear swapped.
            if (boardState == BoardState.Win && BoundGameState.PlayerOneTurn) 
            { 
                labelText = $"{BoundGameState.PlayerTwoName} Won!";
                EndGame();
                
            }
            else if (boardState == BoardState.Win) 
            { 
                labelText = $"{BoundGameState.PlayerOneName} Won!";
                EndGame();
            }
            else if (boardState == BoardState.Draw) 
            {
                labelText = "Draw!";
                EndGame();
            }
            
            // change the label text
            lblCurrentPlayerHeader.Text = labelText;
        }

        /// <summary>
        /// Updates board state and UI
        /// </summary>
        public void UpdateCurrentState(Label gridPosition)
        {
            // Return if board has not been instantiated
            if (pnlGameBoard == null) { return; }

            // Add mark to the grid, X or O based on current turn
            AddMark(gridPosition);

            // Update the current player label then change turn
            BoundGameState.PlayerOneTurn = !BoundGameState.PlayerOneTurn;
            UpdateCurrentPlayerLabel();
        }

        /// <summary>
        /// Just adds X or O to a grid position and updates GameState grid.
        /// </summary>
        /// <param name="gridPosition">Position to add mark on</param>
        private void AddMark(Label gridPosition)
        {
            // Update UI
            if (BoundGameState.PlayerOneTurn) { gridPosition.Text = "X"; }
            else { gridPosition.Text = "O"; }
            pnlGameBoard.ToolTips.SetToolTip(gridPosition, $"This square has an {gridPosition.Text} on it already, choose another square.");

            // Updates back-end game board tracker
            UpdateGameBoard();
        }

        /// <summary>
        /// Updates backend to reflect game grid held within pnlGameBoard
        /// </summary>
        private void UpdateGameBoard()
        {
            // Just return if the board does not exist
            if (pnlGameBoard == null) { return; }

            // Otherwise iterate through game grid, update state accordingly
            for (int i = 0; i < pnlGameBoard.GameGrid.GetLength(0); i++)
            {
                for (int j = 0; j < pnlGameBoard.GameGrid.GetLength(1); j++)
                {
                    // Check if an X or O is marked in the label, update state accordingly
                    if (pnlGameBoard.GameGrid[i, j].Text == "X") { BoundGameState.CurrentBoard[i, j] = 'X'; }
                    else if (pnlGameBoard.GameGrid[i, j].Text == "O") { BoundGameState.CurrentBoard[i, j] = 'O'; }
                }
            }
        }
        #endregion

        #region Clean Up Methods
        /// <summary>
        /// Disables board and prompts to play again
        /// </summary>
        private void EndGame()
        {
            pnlGameBoard.DisableBoard();
            btnPlayAgain.Visible = true;
        }
        #endregion
    }
    #endregion
}
#endregion