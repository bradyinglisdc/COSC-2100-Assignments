﻿/*
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
                _playerOneName = value.Trim();
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
                _playerTwoName = value.Trim();
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

        /// <summary>
        /// Either easy or hard
        /// </summary>
        public Difficulty Difficulty
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

        /// <summary>
        /// Creates a new game state using the provided player names, with a difficulty added.
        /// </summary>
        /// <param name="PlayerOneName">The first player's name</param>
        /// <param name="PlayerTwoName">The second player's name</param>
        /// <param name="difficulty">The AI difficulty</param>
        public GameState(string playerOneName, string playerTwoName, Difficulty difficulty)
        {
            Difficulty = difficulty;
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

        /// <summary>
        /// Returns a 2d char array representation of a board based on some existing board
        /// and some coordinates.
        /// </summary>
        /// <param name="boardToUpdate">The board where the move should be made.</param>
        /// <param name="coordinates">The coordinates of the move.</param>
        /// <param name="moveMark">The mark to place on the move (preferrably either x or o)</param>
        /// <returns></returns>
        public static char[,] UpdateBoard(char[,] boardToUpdate, int[] coordinates, char moveMark)
        {
            char[,] updatedBoard = new char[3, 3];
            for (int i = 0; i < boardToUpdate.GetLength(0); i++)
            {
                for (int j = 0; j < boardToUpdate.GetLength(1); j++)
                {
                    // Place the marker if the coordinates match
                    if (i == coordinates[0] && j == coordinates[1])
                    {
                        updatedBoard[i, j] = moveMark;
                    }

                    // Otherwise, simply copy the old 2d array
                    else
                    {
                        updatedBoard[i, j] = boardToUpdate[i, j];
                    }

                }
            }
            return updatedBoard;
        }

        /// <summary>
        /// Searches through a board and returns it's state (win/draw/none).
        /// </summary>
        /// <param name="boardToCheck">The board to search through.</param>
        /// <returns></returns>
        public static BoardState GetBoardState(char[,] boardToCheck)
        {
            // Check for horizontal and vertical wins
            for (int i = 0; i < boardToCheck.GetLength(0); i++)
            {
                // Player One (X)
                if ((boardToCheck[i, 0] == 'X' && boardToCheck[i, 1] == 'X' && boardToCheck[i, 2] == 'X') ||
                    (boardToCheck[0, i] == 'X' && boardToCheck[1, i] == 'X' && boardToCheck[2, i] == 'X'))
                {
                    return BoardState.Win;
                }

                // Player Two (O)
                else if ((boardToCheck[i, 0] == 'O' && boardToCheck[i, 1] == 'O' && boardToCheck[i, 2] == 'O') ||
                    (boardToCheck[0, i] == 'O' && boardToCheck[1, i] == 'O' && boardToCheck[2, i] == 'O'))
                {
                    return BoardState.Win;
                }
            }

            // Check for diagnol wins (Player X)
            if ((boardToCheck[0, 0] == 'X' && boardToCheck[1, 1] == 'X' && boardToCheck[2, 2] == 'X') ||
                (boardToCheck[0, 2] == 'X' && boardToCheck[1, 1] == 'X' && boardToCheck[2, 0] == 'X'))
            {
                return BoardState.Win;
            }

            // Check for diagnol wins (Player O)
            else if ((boardToCheck[0, 0] == 'O' && boardToCheck[1, 1] == 'O' && boardToCheck[2, 2] == 'O') ||
                (boardToCheck[0, 2] == 'O' && boardToCheck[1, 1] == 'O' && boardToCheck[2, 0] == 'O'))
            {
                return BoardState.Win;
            }

            // Check for draw
            if (CheckDraw(boardToCheck))
            {
                return BoardState.Draw;
            }
            return BoardState.None;
        }

        /// <summary>
        /// Checks for a draw by iterating through board array.
        /// </summary>
        /// <param name="boardToCheck">The board to search through</param>
        /// <returns></returns>
        private static bool CheckDraw(char[,] boardToCheck)
        {
            foreach (char character in boardToCheck)
            {
                if (character == '#') { return false; }
            }
            return true;
        }

        #endregion

        #region Game State Info Methods
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
                    Scores[0]++;
                    return BoardState.Win;
                }

                // Player Two (O)
                else if ((CurrentBoard[i, 0] == 'O' && CurrentBoard[i, 1] == 'O' && CurrentBoard[i, 2] == 'O') ||
                    (CurrentBoard[0, i] == 'O' && CurrentBoard[1, i] == 'O' && CurrentBoard[2, i] == 'O'))
                {
                    GameOver = true;
                    Scores[1]++;
                    return BoardState.Win;
                }
            }

            // Check for diagnol wins (Player X)
            if ((CurrentBoard[0, 0] == 'X' && CurrentBoard[1, 1] == 'X' && CurrentBoard[2, 2] == 'X') ||
                (CurrentBoard[0, 2] == 'X' && CurrentBoard[1, 1] == 'X' && CurrentBoard[2, 0] == 'X'))
            {
                GameOver = true;
                Scores[0]++;
                return BoardState.Win;
            }

            // Check for diagnol wins (Player O)
            else if ((CurrentBoard[0, 0] == 'O' && CurrentBoard[1, 1] == 'O' && CurrentBoard[2, 2] == 'O') ||
                (CurrentBoard[0, 2] == 'O' && CurrentBoard[1, 1] == 'O' && CurrentBoard[2, 0] == 'O'))
            {
                GameOver = true;
                Scores[1]++;
                return BoardState.Win;
            }

            // Check for draw
            if (CheckDraw(CurrentBoard))
            {
                GameOver = true;
                Scores[2]++;
                return BoardState.Draw;
            }

            return BoardState.None;
        }
        #endregion

        #region Game State Changing Methods
        /// <summary>
        /// Resets board so user's can continue to play.
        /// </summary>
        public void ResetBoard()
        {
            for (int i = 0; i < CurrentBoard.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentBoard.GetLength(1); j++)
                {
                    if (CurrentBoard[i,j] != '#') { CurrentBoard[i, j] = '#'; }
                }
            }
            GameOver = false;
        }
        #endregion

        #region AI related methods
        public int[] GetAITurn()
        {
            if (Difficulty == Difficulty.Easy) { return GetEasyModeMove(); }
            return GetHardModeMove();
        }

        /// <summary>
        /// Simply picks the next available move in the array (it's easy mode).
        /// </summary>
        /// <returns>Integer array of -1, -1 if no available move, else integer array of move coordinates</returns>
        private int[] GetEasyModeMove()
        {
            int[] coordinates = { -1, -1 };
            for (int i = 0; i < CurrentBoard.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentBoard.GetLength(1); j++)
                {
                    if (CurrentBoard[i,j] == '#')
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
        /// Searches through every combination of moves and picks the move which is preceeded 
        /// by the highest number of win states.
        /// </summary>
        /// <returns>Integer array of -1, -1 if no available move, else integer array of move coordinates</returns>
        private int[] GetHardModeMove()
        {
            return TicTacToeAI.FindBestMove(CurrentBoard, !PlayerOneTurn);
        }
        #endregion

    }
    #endregion
}
#endregion