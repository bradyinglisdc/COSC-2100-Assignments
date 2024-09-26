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
                _playerOneName = value;
            }
        }

        /// <summary>
        /// The game board, represented by a 2d string array:
        /// { "###", "###", "###" }.
        /// </summary>
        public string[] CurrentBoard
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
            CurrentBoard = Settings.StartingBoard;
            Scores = new int[] { 0, 0, 0 };
            PlayerOneTurn = GetFirstTurn();
        }
        #endregion

        #region Validation and Helper Methods
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

    }
    #endregion
}
#endregion