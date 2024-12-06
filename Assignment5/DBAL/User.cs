/*
 * Title: User.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: To provide a data model and data base access layer for for User data
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
    class User
    {
        #region Constants

        private const string DEFAULT_FIRST_NAME = "No known first name";
        private const string DEFAULT_LAST_NAME = "No known last name";
        private const string DEFAULT_EMAIL = "user@example.com";
        private const int DEFAULT_PASSKEY = 1000;

        private static int[] PASSKEY_BOUNDS = { 1000, 9999 };

        #endregion

        #region Private Backing Members

        private int _userID;

        #endregion

        #region Static Properties

        /// <summary>
        /// The currently logged in user
        /// </summary>
        public static User? CurrentUser { get; set; }

        #endregion

        #region Instance Properties

        /// <summary>
        /// PK: Gets and sets this game's userID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets and sets this user's first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets and sets this user's last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets and sets this user's email
        /// </summary>
        public string? Email { get; set; }

        /*Passkey is never stored in memory*/

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Instantiates a user with default values
        /// </summary>
        public User()
        {
            UserID = GetNextUniqueID();
            FirstName = DEFAULT_FIRST_NAME;
            LastName = DEFAULT_LAST_NAME;
            Email = DEFAULT_EMAIL;
        }

        /// <summary>
        /// Instantiates a user with specified values
        /// </summary>
        /// <param name="userID">This user's ID</param>
        /// <param name="firstName">This user's first name</param>
        /// <param name="lastName">This user's last name</param>
        /// <param name="email">This user's email</param>
        public User(int userID, string? firstName, string? lastName, string? email)
        {
            UserID = userID;
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        #endregion

        #region Static Methods - Read

        /// <summary>
        /// Attempts to log user in. If successful, the user will be returned and stored in CurrentUser.
        /// Else null will be returned
        /// </summary>
        /// <param name="email">This user's email</param>
        /// <param name="passkey">This user's passkey</param>
        /// <returns>The matching user if credentials match, else null</returns>
        public static User? GetUser(string email, string passkey)
        {
            // Ensure passkey is valid integer
            int validPass;
            try { validPass = ValidatePasskey(passkey); }
            catch (Exception ex) { throw new Exception($"Passkey Invalid: {ex.Message}"); }

            // Attempt to log the user in
            User? user = null;
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    // Get the reader
                    SqlCommand query = new SqlCommand();
                    query.Parameters.AddWithValue("@Email", email);
                    query.Parameters.AddWithValue("@Passkey", validPass);
                    query.CommandType = System.Data.CommandType.Text;
                    query.CommandText = $"{Properties.Resources.QUERY_USER_CREDENTIAL} Email = @Email AND Passkey = @Passkey";
                    SqlDataReader userReader = DatabaseAccess.ExecuteQuery(connection, query);

                    // Attempt to read the user
                    while (userReader.Read())
                    {
                        user = new User((int)userReader["UserID"], (string)userReader["FirstName"], (string)userReader["LastName"], (string)userReader["Email"]);
                    }
                }
                return user;
            }

            catch (Exception ex)
            {
                throw new Exception($"Database error: {ex.Message}");
            }
        }

        #endregion

        #region Static Methods - Delete

        /// <summary>
        /// Deletes the corresponding user from memory, and the database if it exists.
        /// </summary>
        /// <param name="userID">The ID of the user to delete.</param>
        public static void DeleteUser(int userID)
        {
            // If the user to delete is not loggged in, throw an error
            if (CurrentUser == null || userID != CurrentUser.UserID)
            {
                throw new Exception("You do not have access to delete that user.");
            }

            // Try and delete the user
            try
            {
                // Remove the user from memory
                CurrentUser = null;

                // Remove from the database
                DatabaseAccess.DeleteRecord(Properties.Resources.SP_DELETE_USER, "@userID", userID);
            }

            catch (Exception ex)
            {
                throw new Exception($"Error deleting user: {ex.Message}");
            }
        }

        #endregion

        #region Static Methods - General

        /// <summary>
        /// Finds unqiue id within database.
        /// </summary>
        /// <returns>A unique user id</returns>
        private static int GetNextUniqueID()
        {
            // Get all userIDs
            List<int> userIDs;
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    SqlDataReader userIDReader = DatabaseAccess.ExecuteQuery(connection, Properties.Resources.QUERY_ALL_USER_ID);
                    userIDs = ReadUserIDsIntoList(userIDReader);
      
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error finding unique user ID: {ex.Message}");
            }
 
            // Loop until unique id found
            int userID = 0;
            while (userIDs.Contains(userID))
            {
                userID++;
            }
            return userID;
        }

        /// <summary>
        /// Reads the value of each user ID in a reader into a list, then returns the list
        /// </summary>
        /// <param name="userIDReader">The reader to read from</param>
        /// <returns>A list of user IDs</returns>
        private static List<int> ReadUserIDsIntoList(SqlDataReader userIDReader)
        {
            List<int> userIDs = new List<int>();
            while (userIDReader.Read())
            {
                userIDs.Add((int)userIDReader["UserID"]);
            }
            return userIDs;
        }

        /// <summary>
        /// Attempts to data validate a passkey.
        /// </summary>
        /// <param name="passkey"></param>
        /// <returns></returns>
        private static int ValidatePasskey(string passkey)
        {
            try
            {
                int validatedPasskey = int.Parse(passkey);
                if (validatedPasskey < PASSKEY_BOUNDS[0] || validatedPasskey > PASSKEY_BOUNDS[1]) { throw new Exception($"Passkey must be between {PASSKEY_BOUNDS[0]} and {PASSKEY_BOUNDS[0]}."); }
                return validatedPasskey;
            }

            catch (Exception)
            {
                throw new Exception("Passkey must be an integer.");
            }



        }

        #endregion

        #region Instance Methods - Create

        /// <summary>
        /// Inserts this user into the database. Note a passkey is recieved from the user such that it is never stored in memory.
        /// </summary>
        public void Insert(string passkey)
        {
            try
            {
                int validPasskey = ValidatePasskey(passkey);
                using (SqlCommand procedure = DatabaseAccess.CreateStoredProcedure(Properties.Resources.SP_INSERT_USER))
                {
                    PackageProcedure(procedure, validPasskey);
                    DatabaseAccess.ExecuteNonQuery(procedure);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"{FirstName}, there was an error saving your account: {ex.Message}");
            }

        }

        #endregion

        #region Instance Methods - Update

        /// <summary>
        /// Updates this game in the database. Note a passkey is recieved from the user such that it is never stored in memory.
        /// </summary>
        public void Update(string passkey)
        {
            try
            {
                int validPasskey = ValidatePasskey(passkey);
                using (SqlCommand procedure = DatabaseAccess.CreateStoredProcedure(Properties.Resources.SP_UPDATE_USER))
                {
                    PackageProcedure(procedure, validPasskey);
                    DatabaseAccess.ExecuteNonQuery(procedure);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"{FirstName}, there was an error updating your account: {ex.Message}");
            }
        }

        #endregion

        #region Instance Methods - General

        /// <summary>
        /// Takes an sql command of type stored procedure, and adds all paramaters to it based on this instance
        /// </summary>
        private void PackageProcedure(SqlCommand procedure, int passkey)
        {
            procedure.Parameters.AddWithValue("@UserID", UserID);
            procedure.Parameters.AddWithValue("@FirstName", FirstName);
            procedure.Parameters.AddWithValue("@LastName", LastName);
            procedure.Parameters.AddWithValue("@Email", Email);
            procedure.Parameters.AddWithValue("@Passkey", passkey);
        }

        #endregion
    }
}

#endregion
