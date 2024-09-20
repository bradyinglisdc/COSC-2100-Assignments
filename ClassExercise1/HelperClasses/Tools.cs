/*
 * Title: Tools
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: Static class with helper methods for any program
 */

#region Namespaces Used
using System;
#endregion

#region Namespace Definition
namespace ClassExercise1
{

    #region Class Definition
    public static class Tools
    {
        #region Static variables and Constants
        private static Random random = new Random();
        #endregion

        #region Random generation
        /// <summary>
        /// Returns random number within specified range.
        /// </summary>
        /// <param name="minimum">Minimum number in range.</param>
        /// <param name="maximum">maximum number in range.</param>
        /// <returns></returns>
        public static int GetRandomNumber(int minimum, int maximum)
        {
            return random.Next(minimum, maximum);
        }
        #endregion

    }
    #endregion
}
#endregion
