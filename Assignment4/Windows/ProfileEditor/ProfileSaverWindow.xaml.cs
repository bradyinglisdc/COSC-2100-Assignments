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
        /// The profile which the user wants to overwrite
        /// </summary>
        private Profile ProfileToWriteTo { get; set; }

        /// <summary>
        /// The profile which the user wants to read from
        /// </summary>
        private Profile ProfileToReadFrom { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Has a single constructor for quick profile saving.
        /// </summary>
        /// <param name="profileToWriteTo">The un-edited profile in memory to be overwritten.</param>
        /// <param name="profileToReadFrom">The edited profile to read into the old one.</param>
        public ProfileSaverWindow(Profile profileToWriteTo, Profile profileToReadFrom)
        {
            InitializeComponent();
            ProfileToWriteTo = profileToWriteTo;
            ProfileToReadFrom = profileToReadFrom;
            tbxProfileName.Text = profileToWriteTo.ProfileName;
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
        /// Sets old profile to reference new profile. Attempts to add to memory list to check for uniqueness.
        /// If no errors, proceeds to attempt file write.
        /// </summary>
        private void AttemptProfileSave()
        {
            // Attempt to set the name if it was edited; basically if a change was made to profile name, check if the new name is available
            try
            {
                if (tbxProfileName.Text != ProfileToWriteTo.ProfileName) { ProfileToReadFrom.ProfileName = tbxProfileName.Text; }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Remove and overwrite the current reference from the profile list and add the new one, then attempt file write
            ProfileToWriteTo = ProfileToReadFrom;
            Profile.Swap(ProfileToWriteTo, ProfileToReadFrom);
            FinalSave();
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
                ProfileLoader.SaveProfile(ProfileToWriteTo);
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