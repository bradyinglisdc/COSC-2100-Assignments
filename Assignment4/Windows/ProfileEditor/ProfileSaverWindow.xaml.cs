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
        private Profile OldProfile { get; set; }

        /// <summary>
        /// The profile which the user wants to read from
        /// </summary>
        private Profile NewProfile { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Has a single constructor for quick profile saving.
        /// </summary>
        /// <param name="oldProfile">The un-edited profile in memory to be overwritten.</param>
        /// <param name="newProfile">The edited profile to read into the old one.</param>
        public ProfileSaverWindow(Profile oldProfile, Profile newProfile)
        {
            InitializeComponent();
            OldProfile = oldProfile;
            NewProfile = newProfile;
            tbxProfileName.Text = oldProfile.ProfileName;
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
        /// Checks if user wants to change name and updates name, then attempts to remove old 
        /// profile from memory and storage, adding the new one.
        /// </summary>
        private void AttemptProfileSave()
        {
            // If a change was made to profile name, check if the new name is available
            // and then remove the old file if needed.
            try
            {
                if (tbxProfileName.Text != OldProfile.ProfileName) 
                { 
                    NewProfile.ProfileName = tbxProfileName.Text;
                    ProfileLoader.DeleteProfile(NewProfile.ProfileName);
                }

                else { NewProfile.ProfileName = OldProfile.ProfileName; }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Remove old profile from memory
            Profile.Swap(NewProfile, OldProfile);
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
                ProfileLoader.SaveProfile(NewProfile);
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