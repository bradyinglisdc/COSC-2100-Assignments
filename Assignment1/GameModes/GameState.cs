/*
 * Title: GameState.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-25
 * Purpose: This class contains the information about a current game instance.
 * It will be instantiated when a game is successfully started.
*/

#region Namespaces Used
using System;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public class GameState
    {
        #region Backing Data Members
        private string _playerOneName;
        private string _playerTwoName;
        #endregion

        #region Properties
        /// <summary>
        /// Player one's name. Setter ensures name is valid before setting.
        /// </summary>
        public string PlayerOneName
        {
            get { return _playerOneName; }
            set
            {
                ValidateName(value);
                _playerOneName = value;
            }
        }

        /// <summary>
        /// Player two's name. Setter ensures name is valid before setting.
        /// </summary>
        public string PlayerTwoName
        {
            get { return _playerTwoName; }
            set
            {
                ValidateName(value);
                _playerTwoName = value;
            }
        }

        /// <summary>
        /// The game board, represented by a 2d char array:
        /// { "###", "###", "###" }.
        /// </summary>
        public char[,] CurrentBoard
        {
            get;
            set;
        }

        /// <summary>
        /// Index 0 represents Player 1's score,
        /// Index 1 represents Player 2's score,
        /// Index 2 represents draws.
        /// </summary>
        public int[] Scores
        {
            get;
            set;
        }

        /// <summary>
        /// True if it's player one's turn, false otherwise.
        /// </summary>
        public bool PlayerOneTurn
        {
            get;
            set;
        }

        /// <summary>
        /// True if the game is over
        /// </summary>
        public bool GameOver
        {
            get;
            set;
        }

        #endregion

        #region Constructor(s)
        /// <summary>
        /// Creates a new game state using the provided player names
        /// </summary>
        /// <param name="PlayerOneName">The first player's name</param>
        /// <param name="PlayerTwoName">The second player's name</param>
        public GameState(string playerOneName, string playerTwoName)
        {
            PlayerOneName = playerOneName;
            PlayerTwoName = playerTwoName;
            CurrentBoard = CreateBoard();
            Scores = new int[] { 0, 0, 0 };
            PlayerOneTurn = GetFirstTurn();
        }
        #endregion

        #region Validation and Helper Methods
        /// <summary>
        /// Creates a new char array board.
        /// </summary>
        /// <returns>The char array board</returns>
        private static char[,] CreateBoard()
        {
            char[,] newBoard = new char[Settings.BoardSize / 3, Settings.BoardSize / 3];
            for (int i = 0; i < newBoard.GetLength(0); i++)
            {
                for (int j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = Settings.StartingBoard[i, j];
                }
            }
            return newBoard;
        }

        /// <summary>
        /// Validates a player name based on the values defined in Settings.cs.
        /// Throws an error if the name is not within the correct range.
        /// </summary>
        /// <param name="name">The name to validate</param>
        public static void ValidateName(string name)
        {
            if (name.Replace(" ", "").Length > Settings.MaximumNameLength)
            {
                throw new Exception(Settings.NameLengthError);
            }
            else if (name.Replace(" ", "").Length < Settings.MinimumNameLength)
            {
                throw new Exception(Settings.NameLengthError);
            }
        }
        /// <summary>
        /// Randomly picks a number between 0 and 1. If 0, player 1 goes first,
        /// else player 2.
        /// </summary>
        /// <returns>True if player one goes first.</returns>
        public static bool GetFirstTurn()
        {
            // Grab random number between 0 and 1, return the result
            return (Tools.GetRandomNumber(0, 2) == 0) ? true : false;
        }
        #endregion

        /// <summary>
        /// Checks if there is a win/draw/none, returns result.
        /// </summary>
        /// <returns>PlayerOneWin/PlayerTwoWin/Draw/None</returns>
        public BoardState GetBoardState()
        {
            // Check for horizontal and vertical wins
            for (int i = 0; i < CurrentBoard.GetLength(0); i++)
            {
                // Player One (X)
                if ((CurrentBoard[i, 0] == 'X' && CurrentBoard[i, 1] == 'X' && CurrentBoard[i, 2] == 'X') ||
                    (CurrentBoard[0, i] == 'X' && CurrentBoard[1, i] == 'X' && CurrentBoard[2, i] == 'X'))
                {
                    GameOver = true;
                    return BoardState.Win;
                }

                // Player Two (O)
                else if ((CurrentBoard[i, 0] == 'O' && CurrentBoard[i, 1] == 'O' && CurrentBoard[i, 2] == 'O') ||
                    (CurrentBoard[0, i] == 'O' && CurrentBoard[1, i] == 'O' && CurrentBoard[2, i] == 'O'))
                {
                    GameOver = true;
                    return BoardState.Win;
                }
            }

            // Check for diagnol wins (Player X)
            if ((CurrentBoard[0, 0] == 'X' && CurrentBoard[1, 1] == 'X' && CurrentBoard[2, 2] == 'X') ||
                (CurrentBoard[0, 2] == 'X' && CurrentBoard[1, 1] == 'X' && CurrentBoard[2, 0] == 'X'))
            {
                GameOver = true;
                return BoardState.Win;
            }

            // Check for diagnol wins (Player O)
            else if ((CurrentBoard[0, 0] == 'O' && CurrentBoard[1, 1] == 'O' && CurrentBoard[2, 2] == 'O') ||
                (CurrentBoard[0, 2] == 'O' && CurrentBoard[1, 1] == 'O' && CurrentBoard[2, 0] == 'O'))
            {
                GameOver = true;
                return BoardState.Win;
            }

            // Check for draw
            if (CheckDraw())
            {
                GameOver = true;
                return BoardState.Draw;
            }

            return BoardState.None;
        }

        /// <summary>
        /// Checks for a draw by iterating through board array
        /// </summary>
        /// <returns></returns>
        private bool CheckDraw()
        {
            foreach (char character in CurrentBoard)
            {
                if (character == '#') { return false; }
            }
            return true;
        } 
    }
    #endregion
}
#endregion