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
        /// Default constructor performs default instantiations, then displays profiles.
        /// </summary>
        public ProfileViewerWindow()
        {
            InitializeComponent();
            DisplayProfiles();
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

        #region Display Logic

        /// <summary>
        /// Iterates through profiles, displaying each.
        /// </summary>
        private void DisplayProfiles()
        {
            foreach (Profile profile in Profile.Profiles)
            {
                ProfileViewUserControl profileContainer = new ProfileViewUserControl();
                profileContainer.tboProfileName.Text = $"{profile.ProfileName}";
                profileContainer.tboStartupProfile.Text = profile.IsStartupProfile ? "Is startup profile" : "Not startup profile";
                profileContainer.tboInputDevice.Text = $"Input Device: {profile.InputDevice}";
                profileContainer.ToolTip = $"Click here to edit {profile.ProfileName}";
                ProfilesContainer.Children.Add(profileContainer);
            }
        }

        #endregion


    }
}

#endregion