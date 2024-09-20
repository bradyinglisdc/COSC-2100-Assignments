/*
 * Title: AvailableGames
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This static class simply contains information about the available games.
 * 
 * This class is designed such that to add new games, all that needs to be done is:
 * 
 * 1. A game panel class should be created which inherits GenericGamePanel (eg. MyNewGamePanel : GenericGamePanel)
 * 2. The new game panel class should have it's GameName property set by end of it's constructor call
 * 3. The type should be added to the list of Type's (Games) below.
 */

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public static class AvailableGames
    {
        #region Game Information

        /// <summary>
        /// A list containing each game type available to play
        /// </summary>
        public static List<Type> Games = new List<Type>
        {
            typeof(GuessTheNumberGamePanel),
            typeof(IceCreamGamePanel)
        };
        #endregion

        #region General Methods
        /// <summary>
        /// Searches through static list of game types and returns true if the
        /// game is found.
        /// </summary>
        /// <param name="name">Name of game type to find.</param>
        /// <returns></returns>
        public static bool ContainsGameByName(string name)
        {
            // Iterate through list of types for a matching name.
            // Instance of the type are created to get the name property.
            foreach (Type gameType in Games)
            {
                // Create the temp instance by casting an instance of the generic object type to
                // generic game panel type
                GenericGamePanel tempInstance = (GenericGamePanel)Activator.CreateInstance(gameType);

                // If there is a match, return true
                if (name == tempInstance.GameName) { return true; }

            }

            // Return false if no match found
            return false;
        }

        /// <summary>
        /// Returns the Type of class at the specified name.
        /// </summary>
        /// <param name="name">The Name property of the GenericGamePanel.</param>
        /// <returns></returns>
        public static Type GetTypeByName(string name)
        {
            // Iterate through list of types for a matching name.
            // Instance of the type are created to get the name property.
            foreach (Type gameType in Games)
            {
                // Create the instance by casting an instance of the generic object type to
                // generic game panel type
                GenericGamePanel gameInstance = (GenericGamePanel)Activator.CreateInstance(gameType);

                // If there is a match, return the Type
                if (name == gameInstance.GameName) { return gameType; }
            }

            // Return null otherwise
            return null;
        }
        #endregion
    }
    #endregion
}
#endregion