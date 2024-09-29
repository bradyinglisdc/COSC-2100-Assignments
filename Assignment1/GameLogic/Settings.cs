/*
 * Title: Settings.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-25
 * Purpose: This static class contains general settings that will apply to each game
*/

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public static class Settings
    {
        #region Name Lengths + Name Length Error Messages
        public const int MinimumNameLength = 2;
        public const int MaximumNameLength = 15;

        public static string NameLengthError = $"Error - All player names must be from {MinimumNameLength} to {MaximumNameLength} characters in length, inclusive.";
        #endregion

        #region Game Settings/Setup
        public static char[,] StartingBoard =
        {
            { '#','#','#' },
            { '#','#','#' },
            { '#','#','#' },
        };
        public const int BoardSize = 9;
        #endregion

        #region Game Info Panel Settings
        // Focus change
        public const string MinmizeInfoPanelToolTip = "Click here, or press Alt + S to minimize scorecard.";
        public const string MaximizeInfoPanelToolTip = "Click here, or press Alt + S to maximize scorecard.";
        public const string MinmizeInfoPanelPrompt = "Hide &Scorecard";
        public const string MaximizeInfoPanelPrompt = "View &Scorecard";
        #endregion
    }
    #endregion
}
#endregion