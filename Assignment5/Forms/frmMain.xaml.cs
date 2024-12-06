/*
 * Title: frmMain.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: Provides the interaction logic for frmMain.xaml, allowing a user to create, view, update, and delete game reviews.
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Assignment5.DBAL;

#endregion


#region Namespace Definition

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        #region Constructor(s)

        /// <summary>
        /// Parses xaml and initialzes models and datagrids
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            InitializeSetup();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Called on game data grid selection change. Updates reviews data grid.
        /// </summary>
        /// <param name="sender">The game DataGrid</param>
        /// <param name="e">Event args</param>
        private void dgrdGames_SelectionChanged(object sender, EventArgs e)
        {
            RefreshReviews();
        }

        /// <summary>
        /// Called when user clicks btnCreateReview. Displays review writer.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">Event args.</param>
        private void btnCreateReview_Click(object sender, EventArgs e)
        {
            DisplayReviewWriter();
        }


        /// <summary>
        /// Called when user clicks btnCancelReview. Clears review text box and hides review writer.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">Event args.</param>
        private void btnCancelReview_Click(object sender, EventArgs e)
        {
            HideReviewWriter();
        }

        /// <summary>
        /// Called when btnDeleteReview is clicked. Deletes the selected review.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">Event args.</param>
        private void btnDeleteReview_Click(object sender, EventArgs e)
        {
            DeleteSelectedReview();
        }

        /// <summary>
        /// Inserts review into the database.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">Event args.</param>
        private void btnSubmitReview_Click(object sender, EventArgs e)
        {
            SubmitReview();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Loads all games and reviews into memory, then opens login form.
        /// </summary>
        private void InitializeSetup()
        {
            FillModels();
            Login();
            SetGrids();
        }

        /// <summary>
        /// Fills all games and reviews into memory.
        /// </summary>
        private void FillModels()
        {
            Game.FillGames();
            Review.FillReviews();
        }

        /// <summary>
        /// Hides this and opens a login form
        /// </summary>
        private void Login()
        {
            Hide();
            (new frmLogin(this)).Show();
        }

        /// <summary>
        /// Sets item sources for each grid.
        /// </summary>
        private void SetGrids()
        {
            // Set games data source, and all aproparitate columns
            dgrdGames.ItemsSource = Game.Games;
            clmGameTitle.Binding = new Binding("Title");
            clmGameGenre.Binding = new Binding("Genre");
            clmGameReleaseDate.Binding = new Binding("ReleaseDate");

            // Set reviews data source, and all appropeiate columns
            dgrdReviews.ItemsSource = Review.Reviews;
            clmReviewerName.Binding = new Binding("Reviewer");
            clmReviewerRating.Binding = new Binding("Rating");
            clmReviewerReview.Binding = new Binding("ReviewText");

            // Subscribed to index change event, then select the first index of games data grid, if it isn't empty
            dgrdGames.SelectionChanged += dgrdGames_SelectionChanged;
            if (!dgrdGames.Items.IsEmpty) { dgrdGames.SelectedIndex = 0; }
        }

        #endregion

        #region Logic

        /// <summary>
        /// Resets the items souce of dgrdReviews such that it is reflective of the currently selected game.
        /// Also sets review header to reflect selected game.
        /// </summary>
        private void RefreshReviews()
        {
            dgrdReviews.ItemsSource = Review.GetReviewsByGameID(((Game)dgrdGames.SelectedItem).GameID);
            tboReviewWriterHeader.Text = $"{((Game)dgrdGames.SelectedItem).Title} Review";
        }

        /// <summary>
        /// Displays review writer, allowing user to write a review for the currently selected game
        /// </summary>
        private void DisplayReviewWriter()
        {
            tbxReviewWriter.Visibility = Visibility.Visible;
            ReviewArea.Height = new GridLength(400);
        }

        /// <summary>
        /// Hides review writer, clearing the associated text box
        /// </summary>
        private void HideReviewWriter()
        {
            tbxReviewWriter.Text = string.Empty;
            tbxReviewWriter.Visibility = Visibility.Visible;
            ReviewArea.Height = new GridLength(50);
        }

        /// <summary>
        /// If a review is selected, the user is prompted before it is deleted.
        /// </summary>
        private void DeleteSelectedReview()
        {
            if (dgrdReviews.Items.IsEmpty || dgrdReviews.SelectedItem == null) { return; }
            Review.DeleteReview(((Review)dgrdReviews.SelectedItem).ReviewID);
            RefreshReviews();
        }

        /// <summary>
        /// Inserts the user's review into the database
        /// </summary>
        private void SubmitReview()
        {
            // If no user is logged in, do nothing
            if (User.CurrentUser == null) { return; }

            // Get the associated game and create a review
            Game reviewedGame = (Game)dgrdGames.SelectedItem;
            Review review = new Review()
            {
                GameID = reviewedGame.GameID,
                ReviewerID = User.CurrentUser.UserID,
                Rating = 5,
                ReviewText = tbxReviewWriter.Text,
                ReviewDate = DateTime.Now
            };

            // Submit the review and refresh reviews
            review.Insert();
            RefreshReviews();
        }

        #endregion
    }
}

#endregion