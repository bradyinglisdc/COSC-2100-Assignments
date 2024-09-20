/*
 * Title: GuessTheNumberSettings
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This static class simply contains all default settings for the number guesser
 */

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace definition
namespace ClassExercise1
{
    #region Class definition
    public static class GuessTheNumberSettings
    {
        #region Difficulty Settings
        public const int MinimumGuess = 1;
        public const int EasyMode = 10;
        public const int MediumMode = 100;
        public const int HardMode = 1000;

        public const int EasyDifficultyIndex = 0;
        public const int MediumDifficultyIndex = 1;
        public const int HardDifficultyIndex = 2;
        #endregion

        #region Default/Starting Settings
        // General defaults
        public const int StartingAttempts = 0;
        public const int StartingDifficultyIndex = EasyDifficultyIndex;
        #endregion

        #region Output strings
        public const string GuessHigherOutput = " is too high!\n";
        public const string GuessLowerOutput = " is too low!\n";
        public const string GuessWinnerOutput = " is correct!\n";
        public const string GameStartedString = "Game started! Enter your guess.\n";
        #endregion
    }
    #endregion
}
#endregion