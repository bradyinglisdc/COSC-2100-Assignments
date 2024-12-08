/*
 * Title: frmAddGame.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-08
 * Purpose: Allows user to add new games to the database
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Assignment5.DBAL;
using System.Windows;


#endregion

#region Namespace Definition

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for frmAddGame.xaml
    /// </summary>
    public partial class frmAddGame : Window
    {
        #region Constants 

        private static GridLength ERROR_GRID_HEIGHT = new GridLength(70);

        #endregion

        #region Constructor(s)

        public frmAddGame()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Closes this form if user confirms
        /// </summary>
        /// <param name="sender">btnCancel</param>
        /// <param name="e">Event args</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Exit();
        }

        /// <summary>
        /// Attempts to add a game based on form details
        /// </summary>
        /// <param name="sender">btnAddGame</param>
        /// <param name="e">Event args</param>
        private void btnAddGame_Click(object sender, EventArgs e)
        {
            AttemptAdd();
        }

        /// <summary>
        /// While user keeps left mouse down anywhere on window, DragMove() will allow them to move window
        /// with mouse.
        /// </summary>
        /// <param name="sender">Anywhere on window</param>
        /// <param name="e">Eventargs</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        #endregion

        #region Logic

        /// <summary>
        /// Attempts to add a game based on user entered form details.
        /// </summary>
        private void AttemptAdd()
        {
            try
            {
                Game game = new Game(tbxTitleEntry.Content, tbxGenreEntry.Content, tbxReleaseDateEntry.Content);
                game.Insert();
                ExitSuccess(game);
            }

            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Displays an error message
        /// </summary>
        /// <param name="error">The error to display</param>
        private void ShowError(string error)
        {
            // Expand error area
            ErrorRow.Height = ERROR_GRID_HEIGHT;

            // Display the error
            tboErrorText.Text = error;
            bdrErrorContainer.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays a message informing user of successful game add and returns success
        /// </summary>
        /// <param name="game">The game which was added.</param>
        private void ExitSuccess(Game game)
        {
            DialogResult = true;
            MessageBox.Show($"{game.Title} added successfully.");
            Close();
        }

        /// <summary>
        /// Prompts user before exiting
        /// </summary>
        private void Exit()
        {
            if (MessageBox.Show("Click 'Yes' to confirm cancel and discard game details", "Cancel game creation?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DialogResult = false;
                Close();
            }
        }

        #endregion
    }
}

#endregion
