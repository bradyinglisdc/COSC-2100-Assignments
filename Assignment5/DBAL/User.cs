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
using System.Net.Mail;
using System.Data;
using Microsoft.IdentityModel.Tokens;

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
        private string? _firstName;
        private string? _lastName;
        private string? _email;

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets amd sets static list of users for quick refrence to user information.
        /// </summary>
        public static List<User> Users { get; set; } = new List<User>();

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
        public string? FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == string.Empty) { throw new Exception("First name must not be blank."); }
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets and sets this user's last name
        /// </summary>
        public string? LastName
        {
            get { return _lastName; }
            set
            {
                if (value == string.Empty) { throw new Exception("Last name must not be blank."); }
                _lastName = value;
            }
        }

        /// <summary>
        /// Gets and sets this user's email
        /// </summary>
        public string? Email
        {
            get { return _email; }
            set
            {
                // Email validation - null is fine
                if (value == null) 
                { 
                    _email = value; 
                    return; 
                }

                // Empty email throws error
                if (value == string.Empty) { throw new Exception("Email must not be empty."); }

                // Invalid format throws error
                try { new MailAddress(value); }
                catch { throw new Exception("Email must be in format: user@example.com."); }

                _email = value.ToLower(); ;
            }
        }

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
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        /// <summary>
        /// Instantiates a user with auto pk
        /// </summary>
        /// <param name="firstName">This user's first name</param>
        /// <param name="lastName">This user's last name</param>
        /// <param name="email">This user's email</param>
        public User(string? firstName, string? lastName, string? email)
        {
            UserID = GetNextUniqueID();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        #endregion

        #region Static Methods - Create

        /// <summary>
        /// Attemts to create a new user. If successful, the user will be returned and stored in CurrentUser (if login is true)
        /// Else null will be returned
        /// </summary>
        /// <param name="email">The chosen email.</param>
        /// <param name="passkey">The chosen passkey.</param>
        /// <param name="login">True if user should be logged in.</param>
        /// <returns></returns>
        public static User? CreateUser(string firstName, string lastName, string email, string passkey, bool login)
        {
            try
            {
                // Ensure user doesn't already exist by that email
                if (UserExists(email)) { throw new Exception("User already exists by that email."); }

                // Attempt to create and insert the new user
                User newUser = new User(firstName, lastName, email);
                newUser.Insert(passkey);

                // Log the user in if specified
                if (login) { CurrentUser = newUser; }
                return newUser;
            }

            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }

        }

        #endregion

        #region Static Methods - Read

        /// <summary>
        /// Fills static User list so that all non-sensitive user data can be easily accessed.
        /// </summary>
        public static void FillUsers()
        {
            // Clear reviews, then read from reviewReader into list
            Users.Clear();
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    // Define query
                    SqlCommand query = new SqlCommand()
                    {
                        CommandType = CommandType.Text,
                        CommandText = Properties.Resources.QUERY_ALL_USER_CREDENTIALS
                    };

                    // Run query and read users
                    SqlDataReader userReader = DatabaseAccess.ExecuteQuery(connection, query);
                    while (userReader.Read()) { Users.Add(new User((int)userReader["UserID"], (string)userReader["FirstName"], (string)userReader["LastName"], (string)userReader["Email"])); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to load users: {ex.Message}");
            }
        }

        /// <summary>
        /// Attempts to log user in. If successful, the user will be returned and stored in CurrentUser (if login is true)
        /// Else null will be returned
        /// </summary>
        /// <param name="email">A user's email</param>
        /// <param name="passkey">A user's passkey</param>
        /// <param name="login">True if user should be logged in</param>
        /// <returns>The matching user if credentials match, else null</returns>
        public static User? GetUser(string email, string passkey, bool login)
        {
            // Ensure non empty email
            if (email.IsNullOrEmpty()) { throw new Exception("Email must not be empty."); }

            // Ensure passkey is valid integer
            int validPass;
            try { validPass = ValidatePasskey(passkey); }
            catch (Exception) { throw new Exception($"Passkey must be integer between {PASSKEY_BOUNDS[0]} and {PASSKEY_BOUNDS[1]}."); }

            // Attempt to log the user in
            User? user = null;
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    // Get the reader
                    SqlCommand query = new SqlCommand()
                    {
                        CommandType = CommandType.Text,
                        CommandText = $"{Properties.Resources.QUERY_USER_CREDENTIAL} Email = @Email AND Passkey = @Passkey"
                    };
                    query.Parameters.AddWithValue("@Email", email);
                    query.Parameters.AddWithValue("@Passkey", validPass);
                    SqlDataReader userReader = DatabaseAccess.ExecuteQuery(connection, query);

                    // Attempt to read the user - this loop will not execute if invalid credentials recieved, as no data will exist
                    while (userReader.Read())
                    {
                        user = new User((int)userReader["UserID"], (string)userReader["FirstName"], (string)userReader["LastName"], (string)userReader["Email"]);
                    }
                }

                // Add user to list of users if not in already, and login user if specified
                if (user != null && !Users.Contains(user)) { Users.Add(user); }
                if (login) { CurrentUser = user; } 
                return user;
            }

            catch (Exception ex)
            {
                throw new Exception($"Database error: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Searches memory for a corresponding userID and pulls the first name and last name as a single string.
        /// </summary>
        /// <param name="userID">The userID to pull a name from.</param>
        /// <returns>The first name of the user</returns>
        public static string GetUserName(int userID)
        {
            // Check if a user exists in memory by that userID
            string userName = "No Name";
            foreach (User user in Users)
            {
                if (user.UserID == userID) { return $"{user.FirstName} {user.LastName}"; }
            }

            return userName;
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
        /// Attempts to data validate a passkey, throws error if can't parse or  invalid bounds.
        /// </summary>
        /// <param name="passkey"></param>
        /// <returns>The validated passkey</returns>
        private static int ValidatePasskey(string passkey)
        {
            try
            {
                int validatedPasskey = int.Parse(passkey);
                if (validatedPasskey < PASSKEY_BOUNDS[0] || validatedPasskey > PASSKEY_BOUNDS[1]) { throw new Exception(); }
                return validatedPasskey;
            }

            catch
            {
                throw new Exception($"Passkey must be between {PASSKEY_BOUNDS[0]} and {PASSKEY_BOUNDS[1]}.");
            }
        }

        /// <summary>
        /// Returns true if user exists by a given email.
        /// </summary>
        /// <param name="email">The email to search for.</param>
        /// <returns>True if user exists by that email.</returns>
        private static bool UserExists(string email)
        {
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    // Setup the command
                    SqlCommand query = new SqlCommand()
                    {
                        CommandText = Properties.Resources.QUERY_EXISTING_USERS,
                        CommandType = CommandType.Text
                    };
                    query.Parameters.AddWithValue("@Email", email);

                    // If the reader can be read, there is at least one user by that email.
                    SqlDataReader userReader = DatabaseAccess.ExecuteQuery(connection, query);
                    while (userReader.Read())
                    {
                        if ((int)userReader["UserCount"] > 0) { return true; }
                    }
                }
                return false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw new Exception($"Database error. {ex.Message}");
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
                throw new Exception($"{ex.Message}");
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

        /// <summary>
        /// Returns this user's full name and email address
        /// </summary>
        /// <returns>This user's full name and email address</returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Email})";
        }

        #endregion
    }
}

#endregion
