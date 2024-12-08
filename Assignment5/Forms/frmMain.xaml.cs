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
using System.Windows.Input;

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
        private const int ReviewWriterShownHeight = 750;

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

        /// <summary>
        /// While user keeps left mouse down anywhere on window, DragMove() will allow them to move window
        /// with mouse.
        /// </summary>
        /// <param name="sender">The title bar/menu area</param>
        /// <param name="e">Eventargs</param>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        /// <summary>
        /// Closes window and application
        /// </summary>
        /// <param name="sender">btnExit</param>
        /// <param name="e">Event args</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (dgrdGames.SelectedItem != null &&
                MessageBox.Show($"Click 'yes' to confirm exit.",
                "Proceed with exit?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Minimizes window
        /// </summary>
        /// <param name="sender">btnMinimize</param>
        /// <param name="e">Event args</param>
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Refreshes users, games, and reviews
        /// </summary>
        /// <param name="sender">btnRefresh</param>
        /// <param name="e">Event args</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        /// <summary>
        /// Opens frmAddGame as dialog
        /// </summary>
        /// <param name="sender">mnuItmAddGame</param>
        /// <param name="e">Event args</param>
        private void mnuItmAddGame_Click(object sender, RoutedEventArgs e)
        {
            if ((new frmAddGame()).ShowDialog() == true) { RefreshGames(); }
        }

        /// <summary>
        /// Prompts user before attempting to delete selected game
        /// </summary>
        /// <param name="sender">mnuItmDeleteGame</param>
        /// <param name="e">Event args</param>
        private void mnuItmDeleteGame_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdGames.SelectedItem != null && 
                MessageBox.Show($"Click 'yes' to confirm deletion of {((Game)dgrdGames.SelectedItem).Title}",
                "Proceed with deletion?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteGame();
            } 
        }


        /// <summary>
        /// Logs out current user and opens frmLogin()
        /// </summary>
        /// <param name="sender">mnItmLogout</param>
        /// <param name="e">Event args</param>
        private void mnuItmLogout_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdGames.SelectedItem != null &&
                MessageBox.Show($"Click 'yes' to confirm logout.",
                "Proceed with logout?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Logout();
            }
        }

        #endregion

        #region Setup

        /// <summary>
        /// Loads all users, games and reviews into memory, then opens login form.
        /// </summary>
        private void InitializeSetup()
        {
            FillModels();
            Login();
            SetGrids();
        }

        /// <summary>
        /// Fills all users, games and reviews into memory; if there is a database issue a retry prompt is given.
        /// </summary>
        private void FillModels()
        {
            try
            {
                User.FillUsers();
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
            dgrdGames.ItemsSource = Game.CurrentGames;
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
        /// Resets the items source of dgrdReviews such that it is reflective of the currently selected game.
        /// Also sets review header to reflect selected game.
        /// </summary>
        private void RefreshReviews()
        {
            if (dgrdGames.SelectedIndex < 0) { return; }
            try
            {
                dgrdReviews.ItemsSource = Review.GetReviewsByGameID(((Game)dgrdGames.SelectedItem).GameID);
                tboReviewWriterHeader.Text = $"{((Game)dgrdGames.SelectedItem).Title} | New Review";
            }
            catch (Exception ex) { MessageBox.Show($"Error refreshing reviews: {ex.Message}"); }
        }

        /// <summary>
        /// Resets games items source of dgrdGames so it is reflective of currently
        /// stored games in memory
        /// </summary>
        private void RefreshGames()
        {
            dgrdGames.ItemsSource = Game.CurrentGames;
        }

        /// <summary>
        /// Refills all models from database, then refreshes datagrids
        /// </summary>
        private void RefreshAll()
        {
            FillModels();
            RefreshGames();
            RefreshReviews();
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
            try
            {
                Review.DeleteReview(((Review)dgrdReviews.SelectedItem).ReviewID);
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting review: {ex.Message}"); }
            
            RefreshReviews();
        }
        
        /// <summary>
        /// Attempts to delete the currently selected game
        /// </summary>
        private void DeleteGame()
        {
            try 
            { 
                Game.DeleteGame(((Game)dgrdGames.SelectedItem).GameID);
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting game: {ex.Message}"); }
            RefreshGames();
        }

        /// <summary>
        /// Inserts the user's review into the database
        /// </summary>
        private void SubmitReview()
        {
            // If no user is logged in, do nothing
            if (User.CurrentUser == null) { return; }

            try
            {
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
            }
            catch (Exception ex) { MessageBox.Show($"Error submitting review: {ex.Message}"); }

            RefreshReviews();
            HideReviewWriter();
        }

        /// <summary>
        /// Logs out current user and returns to frmLogin
        /// </summary>
        private void Logout()
        {
            User.CurrentUser = null;
            Hide();
            (new frmLogin(this)).ShowDialog();
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