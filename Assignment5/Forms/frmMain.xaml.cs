/*
 * Title: frmMain.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: Provides the interaction logic for frmMain.xaml, allowing a user to create, view, update, and delete game reviews.
*/

#region Namespaces Used

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Data;
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
        #region Constants

        private const int ReviewWriterHiddenHeight = 50;
        private const int ReviewWriterShownHeight = 720;

        #endregion

        #region Private Backing Members

        private int _selectedStarIndex;

        #endregion

        #region Instance Properties
        
        /// <summary>
        /// Gets and sets the currently selected star's index, automatically taking care of styling.
        /// </summary>
        private int SelectedStarIndex
        {
            get { return _selectedStarIndex; }
            set
            {
                // If the selected star index is the same as current, set it to -1 (0/10)
                if (value == _selectedStarIndex) { _selectedStarIndex = -1; }
                else { _selectedStarIndex = value; }
                UpdateRating();
            }
        }

        #endregion


        #region Constructor(s)

        /// <summary>
        /// Parses xaml and initialzes models and datagrids, then sets default selected star.
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
            
        /// <summary>
        /// Called when a rating star is selected, indicating the user's rating for this game changed.
        /// Updates the currentely selected star.
        /// </summary>
        /// <param name="sender">The start image which was clicked.</param>
        /// <param name="e">Event args.</param>
        private void RatingChanged(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectedStarIndex = Grid.GetColumn((Image)sender);
        }

        /// <summary>
        /// If a user is logged in, status is updated.
        /// </summary>
        /// <param name="sender">This window.</param>
        /// <param name="e">Event args.</param>
        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            if (User.CurrentUser != null) { sbrItemCurrentStatus.Content = $"Logged in as {User.CurrentUser.ToString()}"; }
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
        /// Fills all games and reviews into memory; if there is a database issue a retry prompt is given.
        /// </summary>
        private void FillModels()
        {
            try
            {
                Game.FillGames();
                Review.FillReviews();
            }

            catch (Exception ex)
            {
                if (MessageBox.Show($"Error connecting to database. Would you like to try again?\n\n{ex.Message}", 
                    "Database Error", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    FillModels();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }

        }

        /// <summary>
        /// Hides this and opens a login form
        /// </summary>
        private void Login()
        {
            Hide();
            (new frmLogin(this)).ShowDialog();
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
            clmGameReleaseDate.Binding = new Binding("ReleaseDateFormatted");

            // Set reviews data source, and all appropriate columns
            dgrdReviews.ItemsSource = Review.Reviews;
            clmReviewerName.Binding = new Binding("Reviewer");
            clmReviewerRating.Binding = new Binding("FormattedRating");
            clmReviewDate.Binding = new Binding("ReviewDateFormatted");
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
            tboReviewWriterHeader.Text = $"{((Game)dgrdGames.SelectedItem).Title} | New Review";
        }

        /// <summary>
        /// Displays review writer, allowing user to write a review for the currently selected game
        /// </summary>
        private void DisplayReviewWriter()
        {
            bdrReviewContainer.Visibility = Visibility.Visible;
            ReviewArea.Height = new GridLength(ReviewWriterShownHeight);
        }

        /// <summary>
        /// Hides review writer, clearing the associated text box and review stars
        /// </summary>
        private void HideReviewWriter()
        {
            tbxReviewWriter.Content = string.Empty;
            SelectedStarIndex = -1;
            bdrReviewContainer.Visibility = Visibility.Hidden;
            ReviewArea.Height = new GridLength(ReviewWriterHiddenHeight);
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
                Rating = SelectedStarIndex + 1,
                ReviewText = tbxReviewWriter.Content,
                ReviewDate = DateTime.Now
            };

            // Try to submit the review, refresh reviews, and hide review writer.
            review.Insert();
            RefreshReviews();
            HideReviewWriter();
        }

        #endregion

        #region Rating Updates

        /// <summary>
        /// Updates the current rating based on the selected star index.
        /// </summary>
        private void UpdateRating()
        {
            // Update rating display
            tboRatingDisplay.Text = $"{SelectedStarIndex + 1}/10";


            // Update stars for each rating value
            foreach(Image star in grdRating.Children)
            {
                // If the index of a star is less than or equal to the last star's index, select it
                if (Grid.GetColumn(star) <= SelectedStarIndex)
                {
                    star.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedStar.png"));
                }

                // Otherwise, it is blank
                else
                {
                    star.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/UnselectedStar.png"));
                }
            }
        }

        #endregion

    }
}

#endregion