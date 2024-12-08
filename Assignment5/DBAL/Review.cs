/*
 * Title: Review.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: To provide a data model and data base access layer for for Review data
*/

#region Namespaces Used 

using Microsoft.Data.SqlClient;

#endregion

#region Namespace Definition

namespace Assignment5.DBAL
{
    class Review
    {
        #region Constants

        private const int DEFAULT_GAME_ID = -1;
        private const int DEFAULT_REVIEWER_ID = -1;
        private const int DEFAULT_RATING = 0;
        private const string DEFAULT_REVIEW_TEXT = "No review data available.";
        private static DateTime DEFAULT_REVIEW_DATE = DateTime.Today;
        private const string DEFAULT_USER_NAME = "No Name";

        #endregion

        #region Private Backing Members

        private int _reviewID;

        #endregion

        #region Static Properties

        /// <summary>
        /// Static list of reviews, keeping latest database pull of reviews in memory
        /// </summary>
        public static List<Review> Reviews { get; set; } = new List<Review>();

        #endregion

        #region Instance Properties

        /// <summary>
        /// PK: Gets and sets this games reviewID, ensuring it is unqiue in memory
        /// </summary>
        public int ReviewID
        {
            get { return _reviewID; }
            set
            {
                if (GetReview(value) != null) { throw new Exception("ReviewID must be unique."); }
                _reviewID = value;
            }
        }

        /// <summary>
        /// FK: Gets and sets this reviews GameID
        /// </summary>
        public int? GameID { get; set; }

        /// <summary>
        /// FK: Gets and sets this reviews ReviewerID
        /// </summary>
        public int? ReviewerID { get; set; }

        /// <summary>
        /// Gets and sets this reviews rating
        /// </summary>
        public int? Rating { get; set; }

        /// <summary>
        /// Gets the formatted rating out of 10, as a string
        /// </summary>
        public string? FormattedRating
        {
            get
            {
                if (Rating == null) { return null; }
                return $"{Rating}/10";
            }
        }

        /// <summary>
        /// Gets and sets this reviews Review Text
        /// </summary>
        public string? ReviewText { get; set; }

        /// <summary>
        /// Gets and sets this reviews date
        /// </summary>
        public DateTime? ReviewDate { get; set; }
        
        /// <summary>
        /// Gets ReviewDate without time incusion, as a string
        /// </summary>
        public string? ReviewDateFormatted
        {
            get
            {
                // Since nullable date time (DateTime?) doesn't have formattable ToString method, cast it. 
                if (ReviewDate == null) { return null; }
                DateTime nonNullReviewDate = (DateTime)ReviewDate;

                // Return review date formatted dd-mm-yyyy as a string
                return nonNullReviewDate.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// Gets this reviewers name if they exist in the database as a user.
        /// </summary>
        public string Reviewer
        {
            get
            {
                if (ReviewerID == null) { return DEFAULT_USER_NAME; }
                return User.GetUserName((int)ReviewerID);
            }
        }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Instantiates a review with default values
        /// </summary>
        public Review()
        {
            ReviewID = GetNextUniqueID();
            GameID = DEFAULT_GAME_ID;
            ReviewerID = DEFAULT_REVIEWER_ID;
            Rating = DEFAULT_RATING;
            ReviewText = DEFAULT_REVIEW_TEXT;
            ReviewDate = DEFAULT_REVIEW_DATE;
            Reviews.Add(this);
        }

        /// <summary>
        /// Instantiates a 
        /// </summary>
        /// <param name="reviewID"></param>
        /// <param name="gameID"></param>
        /// <param name="reviewerID"></param>
        /// <param name="rating"></param>
        /// <param name="reviewText"></param>
        /// <param name="reviewDate"></param>
        public Review(int reviewID, int gameID, int reviewerID, int rating, string reviewText, DateTime? reviewDate)
        {
            ReviewID = reviewID;
            GameID = gameID;
            ReviewerID = reviewerID;
            Rating = rating;
            ReviewText = reviewText;
            ReviewDate = reviewDate;
            Reviews.Add(this);
        }

        #endregion

        #region Static Methods - Read

        /// <summary>
        /// Clears all reviews from memory, and re fills static list.
        /// </summary>
        public static void RefreshReviews()
        {
            Reviews.Clear();
            FillReviews();
        }

        /// <summary>
        /// Fills reviews static array with a new review for each in the database
        /// </summary>
        public static void FillReviews()
        {
            try
            {
                using (SqlConnection connection = DatabaseAccess.OpenConnection())
                {
                    ReadReviewsIntoMemory(DatabaseAccess.ExecuteQuery(connection, Properties.Resources.QUERY_ALL_REVIEWS));
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error retrieving reviews: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads a sqlDataReader into Reviews static array, instantiating a new review for each row.
        /// </summary>
        /// <param name="reviewReader">The review reader to read from.</param>
        private static void ReadReviewsIntoMemory(SqlDataReader reviewReader)
        {
            // Clear reviews, then read from reviewReader into list
            Reviews.Clear();
            try
            {
                while (reviewReader.Read())
                {
                    new Review((int)reviewReader["ReviewID"], (int)reviewReader["GameID"], (int)reviewReader["ReviewerID"],
                        (int)reviewReader["Rating"], (string)reviewReader["ReviewText"], (DateTime)reviewReader["ReviewDate"]);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error reading reviews into memory: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns a review with a matching reviewID in memory, if it exists.
        /// </summary>
        /// <param name="reviewID">The ID of the review to find.</param>
        /// <returns>The review to be returned, or null if not found.</returns>
        public static Review? GetReview(int reviewID)
        {
            // Return a match if it's found
            foreach (Review review in Reviews)
            {
                if (review.ReviewID == reviewID) { return review; }
            }
            return null;
        }

        /// <summary>
        /// Creates and returns sub-list of Reviews which match a GameID
        /// </summary>
        /// <param name="gameID">The gameID to find reviews for</param>
        /// <returns>A list of reviews for the specified game</returns>
        public static List<Review> GetReviewsByGameID(int gameID)
        {
            List<Review> gameReviews = new List<Review>();
            foreach (Review review in Reviews)
            {
                if (review.GameID == gameID) { gameReviews.Add(review); }
            }
            return gameReviews;
        }

        #endregion

        #region Static Methods - Delete

        /// <summary>
        /// Deletes the corresponding reciew from memory, and the database if it exists.
        /// </summary>
        /// <param name="reviewID">The ID of the review to delete.</param>
        public static void DeleteReview(int reviewID)
        {
            try
            {
                // Remove the review from memory
                Review? review = GetReview(reviewID);
                if (review != null) { Reviews.Remove(review); }

                // Remove from the database
                DatabaseAccess.DeleteRecord(Properties.Resources.SP_DELETE_REVIEW, "@reviewID", reviewID);
            }

            catch (Exception ex)
            {
                throw new Exception($"Error deleting review: {ex.Message}");
            }
        }

        #endregion

        #region Static Methods - General

        /// <summary>
        /// Finds unqiue id within memory.
        /// </summary>
        /// <returns>A unique review id</returns>
        private static int GetNextUniqueID()
        {
            // Get all reviewIDs
            List<int> reviewIDs = new List<int>();
            foreach (Review review in Reviews)
            {
                reviewIDs.Add(review.ReviewID);
            }

            // Loop until unique name found
            int reviewID = 0;
            while (reviewIDs.Contains(reviewID))
            {
                reviewID++;
            }
            return reviewID;
        }

        #endregion

        #region Instance Methods - Create

        /// <summary>
        /// Inserts this review into the database.
        /// </summary>
        public void Insert()
        {
            try
            {
                using (SqlCommand procedure = DatabaseAccess.CreateStoredProcedure(Properties.Resources.SP_INSERT_REVIEW))
                {
                    PackageProcedure(procedure);
                    DatabaseAccess.ExecuteNonQuery(procedure);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error inserting review into database: {ex.Message}");
            }

        }

        #endregion

        #region Instance Methods - Update

        /// <summary>
        /// Updates this review in the database
        /// </summary>
        public void Update()
        {
            try
            {
                using (SqlCommand procedure = DatabaseAccess.CreateStoredProcedure(Properties.Resources.SP_UPDATE_REVIEW))
                {
                    PackageProcedure(procedure);
                    DatabaseAccess.ExecuteNonQuery(procedure);
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error updating review in database: {ex.Message}");
            }

        }

        #endregion

        #region Instance Methods - General

        /// <summary>
        /// Takes an sql command of type stored procedure, and adds all paramaters to it based on this instance
        /// </summary>
        private void PackageProcedure(SqlCommand procedure)
        {
            procedure.Parameters.AddWithValue("@ReviewID", ReviewID);
            procedure.Parameters.AddWithValue("@GameID", GameID);
            procedure.Parameters.AddWithValue("@UserID", ReviewerID);
            procedure.Parameters.AddWithValue("@Rating", Rating);
            procedure.Parameters.AddWithValue("@ReviewText", ReviewText);
            procedure.Parameters.AddWithValue("@ReviewDate", ReviewDate);
        }

        #endregion

    }

}

#endregion
