/*
 * Title: ProfileSaverWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide a way of naming and saving profiles
 */

#region Namespaces Used

using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{
    /// <summary>
    /// Provides Interaction logic for ProfileSaverWindow.xaml
    /// </summary>
    public partial class ProfileSaverWindow : Window
    {

        #region Instance Properties

        /// <summary>
        /// The profile which will be saved
        /// </summary>
        private Profile CurrentProfile { get; set; }

        /// <summary>
        /// The profile to pull changes from
        /// </summary>
        private Profile AlteredProfile { get; set; }

        /// <summary>
        /// Reference to the editor window which this window was opened from - closes this window when save complete.
        /// </summary>
        private ProfileEditorWindow EditorWindow { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Has a single constructor for quick profile saving.
        /// </summary>
        /// <param name="currentProfile">The un-edited profile in memory.</param>
        /// <param name="alteredProfile">The edited profile to read into the old one.</param>
        public ProfileSaverWindow(Profile currentProfile, Profile alteredProfile, ProfileEditorWindow editorWindow)
        {
            InitializeComponent();
            CurrentProfile = currentProfile;
            AlteredProfile = alteredProfile;
            EditorWindow = editorWindow;
            tbxProfileName.Text = currentProfile.ProfileName;
            DataContext = this;
        }

        #endregion

        #region Event Handler Methods
        
        /// <summary>
        /// Attempts to save file to storage
        /// </summary>
        /// <param name="sender">The button which was clicked.</param>
        /// <param name="e">Event args</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AttemptProfileSave();
        }

        /// <summary>
        /// Just closes the window
        /// </summary>
        /// <param name="sender">The button which was clicked.</param>
        /// <param name="e">Event args</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region Interaction Logic

        /// <summary>
        /// Deletes file corresponding to the current profile name if it exists, such that
        /// when a user edits an existing profile, the previous file is not lost.
        /// Next, changes are saved to memory and then storage.
        /// </summary>
        private void AttemptProfileSave()
        {
            // Delete profile file from storage if it's name matches CurrentProfile.ProfileName.. It will be recreated.
            ProfileLoader.DeleteProfile(CurrentProfile.ProfileName);

            // Save name to memory. Display message if name already exists
            try { CurrentProfile.ProfileName = tbxProfileName.Text; }
            catch (Exception ex){ MessageBox.Show($"Error updating profile name:\n{ex.Message}"); }

            // Save all other changes in memory
            if (!Profile.Profiles.Contains(CurrentProfile)) { Profile.Profiles.Add(CurrentProfile); }
            CurrentProfile.Clone(AlteredProfile);
            CurrentProfile.IsStartupProfile = cbxIsStartupProfile.IsChecked == true;

            // Save all profile changes to storage
            FinalSave();

            // Return to viewer
            (new ProfileViewerWindow()).Show();
            EditorWindow.Close();
            Close();
        }


        /// <summary>
        /// Attempts to write ProfileToWriteTo to a file using ProfileLoader.cs. ProfileToWriteTo should
        /// be reference to ProfileToReadFrom before this method is called.
        /// </summary>
        private void FinalSave()
        {

            // Attempt to write to storage
            try
            {
                ProfileLoader.SaveProfile(CurrentProfile);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred saving profile. Profile will not be saved to pemanent storage.\nError: {ex.Message}");
                return;
            }
        }

        #endregion

    }
}

#endregion