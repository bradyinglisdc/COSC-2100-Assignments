/*
 * Title: ProfileViewerWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for Profile creation and searching
 */

#region Namespaces Used

using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{
    /// <summary>
    /// This calss provides interaction logic for the profile viewer window
    /// </summary>
    public partial class ProfileViewerWindow : Window
    {

        #region Constructors

        /// <summary>
        /// Default constructor simply instantiates and applies properties determined in the parsed xaml partial class.
        /// </summary>
        public ProfileViewerWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler Methods

        /// <summary>
        /// Calls ReturnToMainMenu()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ReturnToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMainMenu();
        }

        /// <summary>
        /// Calls EditSelectedProfile()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditSelectedProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMainMenu();
        }

        /// <summary>
        /// Calls CreateNewProfile()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void CreateNewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProfile();
        }
        #endregion

        #region Interaction Logic

        /// <summary>
        /// Opens main menu window and closes this window
        /// </summary>
        private void ReturnToMainMenu()
        {
            (new MainMenuWindow(false)).Show();
            Close();
        }

        /// <summary>
        /// Closes this window, then instantiates and opens a new ProfileEditorWindow, calling the default constructor
        /// </summary>
        private void CreateNewProfile()
        {
            (new ProfileEditorWindow()).Show();
            Close();
        }

        #endregion


    }
}

#endregion