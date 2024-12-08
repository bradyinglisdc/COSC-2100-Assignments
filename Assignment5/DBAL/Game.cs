/*
 * Title: Game.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: To provide a data model and data base access layer for for Game data
*/

#region Namespaces Used 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Media;

#endregion

#region Namespace Definition

namespace Assignment5.DBAL
{
    class Game
    {
        #region Constants

        private const string DEFAULT_TITLE = "No known title";
        private const string DEFAULT_GENRE = "No known genre";
        private static DateTime DEFAULT_RELEASE_DATE = DateTime.Today;

        #endregion

        #region Private Backing Members

        private int _gameID;

        #endregion

        #region Static Properties

        /// <summary>
        /// Static list of games, keeping latest database pull of games in memory
        /// </summary>
        public static List<Game> Games { get; set; } = new List<Game>();

        #endregion

        #region Instance Properties

        /// <summary>
        /// PK: Gets and sets this games gameID, ensuring it is unique in memory
        /// </summary>
        public int GameID
        {
            get { return _gameID; }
            set
            {
                if (GetGame(value) != null) { throw new Exception("GameID must be unique."); }
                _gameID = value;
            }
        }

        /// <summary>
        /// Gets and sets this games title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets and sets this games genre
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Gets and sets this games release date
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets ReleaseDate without time incusion, as a string
        /// </summary>
        public string? ReleaseDateFormatted
        {
            get
            {
                // Since nullable date time (DateTime?) doesn't have formattable ToString method, cast it. 
                if (ReleaseDate == null) { return null; }
                DateTime nonNullReleaseDate = (DateTime)ReleaseDate;

                // Return review date formatted dd-mm-yyyy as a string
                return nonNullReleaseDate.ToString("yyyy-MM-dd");
            }
        }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Instantiates a game with default values
        /// </summary>
        public Game()
        {
            GameID = GetNextUniqueID();
            Title = DEFAULT_TITLE;
            Genre = DEFAULT_GENRE;
            ReleaseDate = DEFAULT_RELEASE_DATE;
            Games.Add(this);
        }

        /// <summary>
        /// Instantiates a game with specified values.
        /// </summary>
        /// <param name="gameID">A game's primary key.</param>
        /// <param name="title">A game's title.</param>
        /// <param name="genre">A game's genre.</param>
        /// <param name="releaseDate">A game's release date</param>
        public Game(int gameID, string? title, string? genre, DateTime? releaseDate)
        {
            GameID = gameID;
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
            Games.Add(this);
        }

        #endregion

        #region Static Methods - Read

        /// <summary>
        /// Clears all games from memory, and re fills static list.
        /// </summary>
        public static void RefreshGames()
        {
            Games.Clear();
            FillGames();
        }

        /// <summary>
        /// Fills Games static array with a new game for each in the database
        /// </summary>
        public static void FillGames()
        {
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    ReadGamesIntoMemory(DatabaseAccess.ExecuteQuery(connection, Properties.Resources.QUERY_ALL_GAMES));
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error retrieving games: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads a sqlDataReader into Games static array, instantiating a new game for each row.
        /// </summary>
        /// <param name="gameReader">The game reader to read from.</param>
        private static void ReadGamesIntoMemory(SqlDataReader gameReader)
        {
            try
            {
                while (gameReader.Read())
                {
                    new Game((int)gameReader["GameID"], (string)gameReader["Title"], (string)gameReader["Genre"], (DateTime)gameReader["ReleaseDate"]);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error reading games into memory: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns a game with a matching gameID in memory, if it exists.
        /// </summary>
        /// <param name="gameID">The ID of the game to find.</param>
        /// <returns>The game to be returned, or null if not found.</returns>
        public static Game? GetGame(int gameID)
        {
            // Return a match if it's found
            foreach (Game game in Games)
            {
                if (game.GameID == gameID) { return game; }
            }
            return null;
        }

        #endregion

        #region Static Methods - Delete

        /// <summary>
        /// Deletes the corresponding game from memory, and the database if it exists.
        /// </summary>
        /// <param name="gameID">The ID of the game to delete.</param>
        public static void DeleteGame(int gameID)
        {
            try
            {
                // Remove the game from memory
                Game? game = GetGame(gameID);
                if (game != null) { Games.Remove(game); }

                // Remove from the database
                DatabaseAccess.DeleteRecord(Properties.Resources.SP_DELETE_GAME, "@gameID", gameID);
            }

            catch (Exception ex)
            {
                throw new Exception($"Error deleting game: {ex.Message}");
            }
        }

        #endregion

        #region Static Methods - General

        /// <summary>
        /// Finds unqiue id within memory.
        /// </summary>
        /// <returns>A unique game id</returns>
        private static int GetNextUniqueID()
        {
            // Get all gameIDs
            List<int> gameIDs = new List<int>();
            foreach (Game game in Games)
            {
                gameIDs.Add(game.GameID);
            }

            // Loop until unique name found
            int gameID = 0;
            while (gameIDs.Contains(gameID))
            {
                gameID++;
            }
            return gameID;
        }

        #endregion

        #region Instance Methods - Create

        /// <summary>
        /// Inserts this game into the database.
        /// </summary>
        public void Insert()
        {
            try
            {
                using (SqlCommand procedure = DatabaseAccess.CreateStoredProcedure(Properties.Resources.SP_INSERT_GAME))
                {
                    PackageProcedure(procedure);
                    DatabaseAccess.ExecuteNonQuery(procedure);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error inserting {Title} into database: {ex.Message}");
            }

        }

        #endregion

        #region Instance Methods - Update

        /// <summary>
        /// Updates this game in the database
        /// </summary>
        public void Update()
        {
            try
            {
                using (SqlCommand procedure = DatabaseAccess.CreateStoredProcedure(Properties.Resources.SP_UPDATE_GAME))
                {
                    PackageProcedure(procedure);
                    DatabaseAccess.ExecuteNonQuery(procedure);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error updating {Title} in database: {ex.Message}");
            }
        }

        #endregion

        #region Instance Methods - General

        /// <summary>
        /// Takes an sql command of type stored procedure, and adds all paramaters to it based on this instance
        /// </summary>
        private void PackageProcedure(SqlCommand procedure)
        {
            procedure.Parameters.AddWithValue("@GameID", GameID);
            procedure.Parameters.AddWithValue("@Title", Title);
            procedure.Parameters.AddWithValue("@Genre", Genre);
            procedure.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
        }

        #endregion
    }
}

#endregion
