/*
 * Title: GamePanel.Backend.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-25
 * Purpose: This panel contains the back-end logic for the tic tac toe game.
 * Front-end logic is found within the GamePanel.cs file.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public partial class GamePanel : GenericGamePanel
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
        /// Starts a human vs human or, human vs AI game -
        /// Calls parent constructor, instantiates setup controls and adds appropriate event handlers.
        /// </summary>
        /// <param name="startAIGame">True if AI game should be started.</param>
        public GamePanel(bool startAIGame) : base()
        {
            IsAIGame = startAIGame;
            InstantiateControls();
            SubscribeEventHandlers();
        }
        #endregion

        #region Game Setup Methods
        /// <summary>
        /// All actual game logic for HumanVsHuman starts here.
        /// This method instantiates, styles and subscribes event handler methods
        /// to all game controls, randomly chooses a first turn, and allows the game
        /// to begin.
        /// </summary>
        private void StartGame()
        {
            // Instantiate a fresh game state - constructor randomly chooses first turn. Adds difficulty
            // if it is an AI game.
            if (!IsAIGame) { BoundGameState = new GameState(txtPlayerOneNameInput.Text, txtPlayerTwoNameInput.Text); }
            else
            {
                Difficulty difficulty = rbtnDifficultyEasy.Checked ? Difficulty.Easy : Difficulty.Hard;
                BoundGameState = new GameState(txtPlayerOneNameInput.Text, txtPlayerTwoNameInput.Text, difficulty);
            }

            // Instantiate and style a new board area
            SetupBoardArea();
        }

        /// <summary>
        /// Removes setup controls and adds board controls.
        /// </summary>
        private void SetupBoardArea()
        {
            if (this.Controls.Contains(pnlGameSetup)) { this.Controls.Remove(pnlGameSetup); }

            this.Controls.Add(lblCurrentPlayerHeader);
            this.Controls.Add(btnPlayAgain);
            
            UpdateCurrentPlayerLabel();
            pnlGameBoard = new BoardPanel();
            pnlGameInfo = new GameInfoPanel(BoundGameState);

            // If this is a human vs ai game and it is the ai's turn, get it's move
            if (IsAIGame && !BoundGameState.PlayerOneTurn)
            {
                GetAITurn(); 
            }
        }
        #endregion

        #region Game Logic Methods
        /// <summary>
        /// Updates board state and UI
        /// </summary>
        public void UpdateCurrentState(Label gridPosition)
        {
            // Return if board has not been instantiated
            if (pnlGameBoard == null) { return; }

            // Add mark to the grid, X or O based on current turn
            AddMark(gridPosition);

            // Change turn and update the current player label
            BoundGameState.PlayerOneTurn = !BoundGameState.PlayerOneTurn;
            UpdateCurrentPlayerLabel();

            // If it is an AI game and it is the AI's turn, get it's move
            if (!BoundGameState.GameOver && IsAIGame && !BoundGameState.PlayerOneTurn) { GetAITurn(); }
        }


        /// <summary>
        /// Checks for win/draw state then updates current player label header.
        /// If there is an end state, the game will be ended.
        /// If there is a win, it belongs to the previous turn player. 
        /// </summary>
        public void UpdateCurrentPlayerLabel()
        {
            // Get the board state
            string labelText = BoundGameState.PlayerOneTurn ? $"{BoundGameState.PlayerOneName} (X)'s turn!" : $"{BoundGameState.PlayerTwoName} (O)'s turn!";
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

        #region AI Specific Methods
        /// <summary>
        /// Searches through the board state and locates an appropriate move
        /// for the AI based on difficulty, then sends to the board panel to make the move.
        /// </summary>
        private void GetAITurn()
        {
            // Get AI move based on difficulty
            int[] moveCoordinates = BoundGameState.GetAITurn();
            pnlGameBoard.ClickGridPosition(moveCoordinates);
        }

        #endregion


        #region Cleanup/Restart Methods
        /// <summary>
        /// Starts the game with already existing player names/game state.
        /// Essentially just resets game state and updates UI.
        /// </summary>
        public void ResetGame()
        {
            // Instantiate a fresh game state with the names
            BoundGameState = new GameState(BoundGameState.PlayerOneName, BoundGameState.PlayerTwoName);

            // Instantiate and style a new board area, removing the old one
            this.Controls.Remove(lblCurrentPlayerHeader);
            this.Controls.Remove(btnPlayAgain);
            this.Controls.Remove(pnlGameBoard);
            this.Controls.Remove(pnlGameInfo);
            SetupBoardArea();
        }

        /// <summary>
        /// Just resets board's backend representation and frontend representation.
        /// </summary>
        private void ResetBoard()
        {
            // Ensure board exists
            if (pnlGameBoard == null) { return; }

            // Instantiate new game board
            Controls.Remove(pnlGameBoard);
            pnlGameBoard = new BoardPanel();

            // Clear backend board representation and update label
            BoundGameState.ResetBoard();
            UpdateCurrentPlayerLabel();
            btnPlayAgain.Visible = false;

            // If it is an AI game and it is the AI's turn, get it's move
            if (IsAIGame && !BoundGameState.PlayerOneTurn) { GetAITurn(); }
        }

        /// <summary>
        /// Disables board, updates score UI, and prompts user to play again.
        /// </summary>
        private void EndGame()
        {
            pnlGameBoard.DisableBoard();
            btnPlayAgain.Visible = true;
            pnlGameInfo.UpdateScores();
        }
        #endregion
    }
    #endregion
}
#endregion