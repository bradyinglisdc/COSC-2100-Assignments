/*
 * Title: Search.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-17
 * Purpose: To provide a static class with basic search algorithms
 */

#region Namespace Definition

namespace Assignment4
{

    /// <summary>
    /// Provides basic search algorithm methods
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// Searches through a list of type string, returning a list of type
        /// int where each index value represents the number of matching characters at that index.
        /// </summary>
        /// <param name="elements">The elements to search through</param>
        /// <param name="searchKey">String to search list with</param>
        /// <returns>A list of type int where each index value represents the number of matching characters at that index</returns>
        public static List<int> GetMatchRankings(List<string> elements, string searchKey)
        {
            // Will be set to 0 at each element iteration, and iterated up by 1 for each matching character in that element
            int currentCharMatchCount = 0;
            List<int> matchRankings = new List<int>(elements.Count);

            // Iterate through elements
            foreach (string element in elements)
            {
                // Iterate through element chars, adding one to char match count for each match
                for (int i = 0; i < element.Length; i++)
                {
                    if (searchKey.Length > i && element[i] == searchKey[i]) 
                    {
                        currentCharMatchCount += 1;
                    }
                }
                
                // Add the current match character count to the ranknings
                matchRankings.Add(currentCharMatchCount);

                // Reset current char count
                currentCharMatchCount = 0;
            }
            return matchRankings;
        }
    }
}

#endregion