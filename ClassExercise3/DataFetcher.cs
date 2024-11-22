/*
 * Title: DataFetcher.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-22
 * Purpose: To provide static methods to pull and package data from the Sportleagues database
 */

#region Namespaces Used

using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

#endregion

#region Namespace Definition

namespace ClassExercise3
{
    /// <summary>
    /// Contains methods for fetching player data from sport leagues database, as well as packaging the pulled tables
    /// as data views such that they can be interpreted by data grids.
    /// </summary>
    public static class DataFetcher
    {
        #region Constants

        private const string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=Sportleagues;Integrated Security=True;TrustServerCertificate=True";
        private const string PLAYER_DATA_QUERY = "SELECT players.firstname, players.lastname, rosters.teamid, rosters.jerseynumber, players.regnumber, rosters.Isactive FROM players JOIN rosters ON players.playerid = rosters.playerid;";
        private const string TEAM_DATA_QUERY = "SELECT teamid, teamname FROM teams;";

        #endregion

        #region Data Retrieval 

        /// <summary>
        /// Establishes connection to Sportleagues database, uses PLAYER_DATA_QUERY as described above to join players and rosters table, 
        /// then converts the joined table to a data view and returns.
        /// </summary>
        /// <returns>playersInfo joined table as a data view</returns>
        public static DataView GetPlayersAsView()
        {
            // Return the joined players info table as a data view
            return GetQueryAsView(PLAYER_DATA_QUERY, "playersInfo");
        }

        /// <summary>
        /// Establishes connection to Sportleagues database, uses TEAM_DATA_QUERY as described above to grab teams data,
        /// then converts the table to a data view and returns.
        /// </summary>
        /// <returns></returns>
        public static DataView GetTeamsAsView()
        {
            // Return the teams table as a data view
            return GetQueryAsView(TEAM_DATA_QUERY, "teams");
        }

        /// <summary>
        /// Establishes connection to Sportleagues database, uses a provided query to create an adapter,
        /// then fills a dataset using the adapter and returns the result as a DataView
        /// </summary>
        /// <returns>A data view representing the result of a provided query on the Sportleagues database</returns>
        private static DataView GetQueryAsView(string query, string tableName)
        {
            // Connect to the database and run the query on an adapter
            SqlDataAdapter sportLeaguesTableAdapter = new SqlDataAdapter(query, CONNECTION_STRING);

            // Fill a new data set using the adapter
            DataSet sportLeaguesDataSet = new DataSet();
            sportLeaguesTableAdapter.Fill(sportLeaguesDataSet, tableName);

            // Get the joined table as a view and return
            return new DataView(sportLeaguesDataSet.Tables[tableName]);
        }

        #endregion
    }
}

#endregion
