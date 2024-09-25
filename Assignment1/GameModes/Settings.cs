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
        public const int MaximumNameLength = 30;

        public static string NameLengthError = $"Error - All player names must be from {MinimumNameLength} to {MaximumNameLength} characters in length, inclusive.";
        #endregion

        #region Game Settings/Setup
        public static string[] StartingBoard =
        {
            "###",
            "###",
            "###"
        };
        #endregion
    }
    #endregion
}
#endregion