/*
 * Title: Tools
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-06
 * Purpose: Static class with helper methods for any program
 */

#region Namespaces Used
using System;
#endregion

#region Namespace Definition
namespace Assignment2
{
    #region Class Definition
    public static class Tools
    {
        #region Static variables and Constants
        private static Random random = new Random();
        #endregion

        #region Random generation
        /// <summary>
        /// Returns random integer within specified range.
        /// </summary>
        /// <param name="minimum">Minimum integer in range.</param>
        /// <param name="maximum">maximum integer in range.</param>
        /// <returns></returns>
        public static int GetRandomInt(int minimum, int maximum)
        {
            return random.Next(minimum, maximum);
        }
        #endregion

    }
    #endregion
}
#endregion
