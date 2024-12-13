/*
 * Title: User.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-13
 * Purpose: To provide a means of validating and keeping track of users by means of database access.
 * AI Used: AI was used for Insert(), Fill(), and Login() method.
*/

#region Namespaces Used

using Microsoft.Data.SqlClient;
using System.Data;

#endregion      

#region Namespace Definition

namespace FinalAssignment.Models
{
    /// <summary>
    /// This class describes a User model based on the one crated in the ProducerPal database.
    /// </summary>
    internal class User
    {
        #region Constants

        private const string DEFAULT_USERNAME = "No username.";
        private const string DEFAULT_EMAIL = "No email.";
        private const string DEFAULT_PASSWORD = "No password.";
        private static int[] USERNAME_LENGTH = { 3, 100};
        private static int[] PASSWORD_LENGTH = { 8, 100 };
        private static int[] EMAIL_LENGTH = { 5, 255 };

        #endregion

        #region Static Members

        /// <summary>
        /// A static list of all user's currently in memory.
        /// </summary>
        public static List<User> Users = new List<User>();

        /// <summary>
        /// Gets and sets the currently logged in user.
        /// </summary>
        public static User? CurrentUser { get; set; }

        #endregion

        #region Backing Members

        private int _userID;
        private string _username = DEFAULT_USERNAME;
        private string _email = DEFAULT_EMAIL;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets unique UserID for this user.
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set
            {
                if (_userID == value) { return; }
                if (!UserIDUnique(value))
                {
                    throw new Exception($"Duplicate user IDs!");
                }
                _userID = value;
            }
        }

        /// <summary>
        /// Gets and sets an email for this user.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value) { return; }
                if (value.Length < EMAIL_LENGTH[0] || value.Length > EMAIL_LENGTH[1])
                {
                    throw new Exception($"Email must be between {EMAIL_LENGTH[0]} and {EMAIL_LENGTH[1]} characters.");
                }
                if (!EmailUnique(value))
                {
                    throw new Exception($"That email already exists in our database.");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Gets and sets a username for this user.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username == value) { return; }
                if (value.Length < USERNAME_LENGTH[0] || value.Length > USERNAME_LENGTH[1])
                {
                    throw new Exception($"Username must be between {USERNAME_LENGTH[0]} and {USERNAME_LENGTH[1]} characters.");
                }
                if (!UsernameUnique(value))
                {
                    throw new Exception($"That username is taken.");
                }
                _username = value;
            }
        }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default constructor - sets default values.
        /// </summary>
        public User()
        {
            _userID = GetUniqueUserID();
            _email = DEFAULT_EMAIL;
            _username = DEFAULT_USERNAME;
        }

        /// <summary>
        /// Parameterized constructor - sets specified values.
        /// </summary>
        /// <param name="userID">UserID to set.</param>
        /// <param name="username">Username to set.</param>
        /// <param name="email">Email to set.</param>
        public User(int userID, string username, string email)
        {
            _userID = userID;
            Email = email;
            Username = username;
        }

        /// <summary>
        /// Parameterized constructor - sets specified values with auto ID.
        /// </summary>
        /// <param name="username">Username to set.</param>
        /// <param name="email">Email to set.</param>
        public User(string username, string email)
        {
            _userID = GetUniqueUserID();
            Email = email;
            Username = username;
        }

        #endregion

        #region Static Methods - General

        /// <summary>
        /// Searces user's in memory for a unique UserID.
        /// </summary>
        private static int GetUniqueUserID()
        {
            // Generate a list of all IDs
            List<int> userIDs = new List<int>();
            foreach (User user in Users)
            {
                userIDs.Add(user.UserID);
            }

            // Loop until unique
            int userID = 0;
            while (userIDs.Contains(userID))
            {
                userID++;
            }
            return userID;
        }


        /// <summary>
        /// Searches for any conflicting userIDs.
        /// </summary>
        /// <param name="userID">The userID to search with.</param>
        /// <returns>True if userID is unique</returns>>
        private static bool UserIDUnique(int userID)
        {
            // Generate a list of all IDs
            List<int> userIDs = new List<int>();
            foreach (User user in Users)
            {
                userIDs.Add(user.UserID);
            }

            // Return negate of contains
            return !userIDs.Contains(userID);
        }

        /// <summary>
        /// Searches for any conflicting emails.
        /// </summary>
        /// <param name="email">The email to search with.</param>
        /// <returns>True if email is unique</returns>
        private static bool EmailUnique(string email)
        {
            // Generate a list of all Emails
            List<string> emails = new List<string>();
            foreach (User user in Users)
            {
                emails.Add(user.Email);
            }

            // Return negate of contains
            return !emails.Contains(email);
        }

        /// <summary>
        /// Searches for any conflicting usernams.
        /// </summary>
        /// <param name="username">The username to search with.</param>
        /// <returns>True if username is unique</returns>
        private static bool UsernameUnique(string username)
        {
            // Generate a list of all Usernames
            List<string> usernames = new List<string>();
            foreach (User user in Users)
            {
                usernames.Add(user.Username);
            }

            // Return negate of contains
            return !usernames.Contains(username);
        }

        /// <summary>
        /// Searches static list of user's and sends back if a match is found.
        /// </summary>
        /// <param name="username">The username to search with.</param>
        /// <returns>A user if found, otherwise null.</returns>
        public static User? GetByUsername(string username)
        {
            foreach (User user in Users)
            {
                if (user.Username== username) { return user; }
            }
            return null;
        }

        #endregion

        #region Static Methods - Database Access

        /// <summary>
        /// Logs this user in based on the provided password.
        /// 
        /// AI Used: Yes
        /// Prompt: "Create a static login method which uses Properties.Resources.QUERY_USER_CREDENTIALS, getting all user IDs with 
        /// matching username and passwords. Do not string concat, use @values. Simple check if one row was returned, if it was then set CurrentUser 
        /// to user and return the user, otherwise return null. Method takes an username and password."
        /// 
        /// Changes Made: GPT 4o was having a hard time following instructions and wanted to string concat, so I reprompted until it got it right.
        ///               I also added a check to add the logged in user to the list of users if they're not already there. Also added a check to
        ///               pull the user from memory such that their exisiting info can be used.
        /// </summary>
        /// <param name="username">The username to use to log the user in.</param>
        /// <param name="password">The password to use to log the user in.</param>
        /// <returns>A user if login was success, otherwise null.</returns>
        public static User? Login(string username, string password)
        {
            // SQL query string from resources
            string query = Properties.Resources.QUERY_USER_CREDENTIALS;

            // Grab the user
            User? userData = GetByUsername(username);
            User userToLogin = new User();

            // Ensure user exists
            if (userData != null) { userToLogin = userData; }

          
            // Removed inline connection string declaration
            /*string connectionString = "YourConnectionStringHere";*/

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNETION_STRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameterized query to prevent SQL injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if one row was returned
                            if (reader.HasRows && reader.Read())
                            {
                                userToLogin.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                userToLogin.Username = reader.GetString(reader.GetOrdinal("Username"));
                                userToLogin.Email = reader.GetString(reader.GetOrdinal("Email"));
                                CurrentUser = userToLogin;
      
                                // Added check to add user to list if not already
                                if (UserIDUnique(CurrentUser.UserID)) { Users.Add(CurrentUser); }

                                return CurrentUser; // Successful login
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Added throw instead of console write
                throw new Exception($"There was a problem logging you in: {ex.Message}");
            }

            return null; // Login failed
        }

        /// <summary>
        /// Fills static list of users.
        /// 
        /// AI Used: Yes
        /// Prompt: "Use Properties.Resources.QUERY_ALL_USERS string to fill a C# user classes static list of users. The query gets a 
        ///          'UserID, UserName, and Email', and should set properties 'UserID, Username, and Email'"
        /// Changed Made: Removed inline connection string declaration, and added exception throw instead of console write.
        /// </summary>
        public static void Fill()
        {
            // SQL query string from resources
            string query = Properties.Resources.QUERY_ALL_USERS;

            // Removed inline connection string declaration
            /*string connectionString = "YourConnectionStringHere";*/

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNETION_STRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Users.Add(new User
                                {
                                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Username = reader.GetString(reader.GetOrdinal("Username"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error pulling user data: {ex.Message}");
            }
        }


        #endregion

        #region Instance Methods - Database Access

        /// <summary>
        /// Inserts a this user into the database.
        /// 
        /// AI Used: Yes
        /// Prompt: "Create an insert method in C# for a user class which inserts all user properties to a stored procedure."
        /// Changes made: Removed additional params and changed exception handling, and add user to memory as well.
        ///               Added additional throws if the password is in unallowed range or user exists in memory.
        /// </summary>
        /// <param name="password">This user's password.</param>
        public void Insert(string password)
        {
            try
            {
                // Added throw if password check fails
                if (password.Length < PASSWORD_LENGTH[0] || password.Length > PASSWORD_LENGTH[1])
                {
                    throw new Exception($"Password must be between {PASSWORD_LENGTH[0]} and {PASSWORD_LENGTH[1]} characters.");
                }

                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNETION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spInsertUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Adding parameters to the stored procedure
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Password", password);

                        // Removed unwatned param
                        /*command.Parameters.AddWithValue("@Password", Password);*/

                        // Removed unwatned param
                        /*command.Parameters.AddWithValue("@DateCreated", DateCreated);*/

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Added throw instead of Console write
                throw new Exception($"{ex.Message}");
            }

            // Add the user to memory and log them in
            Users.Add(this);
            CurrentUser = this;
        }

        #endregion
    }
}

#endregion