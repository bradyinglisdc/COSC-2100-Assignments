/*
 * Title: ProfileViewerWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for Profile creation and searching
 */

#region Namespaces Used

using System.Windows;
using System.Windows.Input;

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
        private void btnReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMainMenu();
        }

        /// <summary>
        /// Calls CreateNewProfile()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void btnCreateNewProfile_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProfile();
        }

        /// <summary>
        /// Opens a new profile editor and closes this window.
        /// </summary>
        /// <param name="sender">The profile container which was clicked</param>
        /// <param name="e">Event args</param>
        private void ProfileContainer_Click(object sender, MouseButtonEventArgs e)
        {
            EditSelectedProfile(sender);
        }

        /// <summary>
        /// Calls OpenExistingProfile()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void btnEditExistingProfile_Click(object sender, RoutedEventArgs e)
        {
            OpenExistingProfile();
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

        /// <summary>
        /// Closes this window, then instantiates and opensa new ProfileEditorWindow, calling the paramaterized constructor
        /// </summary>
        /// <param name="profileContainer">The profile container which was clicked</param>
        private void EditSelectedProfile(object profileContainer)
        {
            // Cast the container to a profile view, and grab the profile name text block property 
            string profileName = ((ProfileViewUserControl)profileContainer).tboProfileName.Text;

            // Grab the matching profile based on the name, ensure it isn't null
            Profile? matchingProfile = Profile.FindProfileByName(profileName);

            // Instantiate and open a profile editor window, closing this window
            EditExistingProfile(matchingProfile);
        }

        /// <summary>
        /// Opens a new OpenFileDialog, filters by .settings files, gets user selected file
        /// directory, then opens profile editor after reading the file.
        /// </summary>
        private void OpenExistingProfile()
        {
            try
            {
                Profile? profileToOpen = ProfileLoader.GetExistingProfile();
                EditExistingProfile(profileToOpen);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Edits a 
        /// </summary>
        /// <param name="profileToEdit"></param>
        private void EditExistingProfile(Profile? profileToEdit)
        {
            // Just return if the profile is null
            if (profileToEdit == null) { return; }

            // Instantiate the editor window and close this window
            (new ProfileEditorWindow(profileToEdit)).Show();
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
                profileContainer.MouseLeftButtonDown += new MouseButtonEventHandler(ProfileContainer_Click);
                ProfilesContainer.Children.Add(profileContainer);
            }
        }

        #endregion
    }
}

#endregion