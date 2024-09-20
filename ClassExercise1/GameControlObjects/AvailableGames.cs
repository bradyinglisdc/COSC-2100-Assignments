/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This static class simply contains information about the available games.
 */

#region Namespaces Used
using System.Collections.Generic;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public static class AvailableGames
    {
        #region Game Information
        public static List<string> GameNames = new List<string>
        {
            "Guess The Number",
            "Ice Cream"
        };
        #endregion
    }
    #endregion
}
#endregion