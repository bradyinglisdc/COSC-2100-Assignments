/*
 * Title: ProfileLoader.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-15
 * Purpose: Provides an interface between application windows and file IO operations
 */

#region Namespaces Used

using System.Text;

#endregion

#region Namespace Definition

namespace Assignment4
{

    /// <summary>
    /// Provides static methods for the purpose of interfacing application windows with the class 'BasicFileIO.cs'
    /// </summary>
    public static class ProfileLoader
    {

        #region Static Methods

        /// <summary>
        /// Loads all profiles into memory.
        /// </summary>
        public static void LoadProfiles()
        {
            try
            {
                byte[] rawProfileSettings = BasicFileIO.ReadDirectoryIntoByteArray(GenericSettings.ProfileOutputDir);
                Profile.CreateAllProfiles(rawProfileSettings);
            }

            catch (Exception ex)
            {
                throw new Exception($"Error loading files into memory: {ex.Message}");
            }
        }

        /// <summary>
        /// Packages a provided profile and proceeds to attempt to save it to permanent storage.
        /// </summary>
        /// <param name="profileToSave">The profile to save.</param>
        public static void SaveProfile(Profile profileToSave)
        {
            // Get binary representation of profile settings. Return if no still null
            profileToSave.PackcageSettings();
            if (profileToSave.PackagedSettings == null) { return; }

            // Begin file write.
            try
            {
                BasicFileIO.WriteByteArrayIntoFile($"{GenericSettings.ProfileOutputDir}{profileToSave.ProfileName}.settings", profileToSave.PackagedSettings);
            }

            catch (Exception ex)
            {
                throw new Exception($"Profile write error: {ex.Message}");
            }
        }

        /// <summary>
        /// Attempt to delete the specified profile
        /// </summary>
        public static void DeleteProfile(string profileName)
        {
            try
            {
                BasicFileIO.DeleteFile($"{GenericSettings.ProfileOutputDir}{profileName}.settings");
            }

            catch (Exception ex)
            {
                throw new Exception($"Profile deletion error: {ex.Message}");
            }
        }

        /// <summary>
        /// Opens a new OpenFileDialog, filters by .settings files, gets user selected file
        /// directory, then returns the matching file or null.
        /// </summary>
        /// <returns>A user selected .settings file as a Profile, or null if no selection.</returns>
        public static Profile? GetExistingProfile()
        {
            // Open the dialog and get the selected directory 
            string selectedProfileDirectory = BasicFileIO.OpenFileDialog("Select a Settings file (.settings)|*.settings");

            // Return if no directory was selected. Otherwise read the file into a string.
            if (selectedProfileDirectory == string.Empty) { return null; }
            string selectedProfile = Encoding.UTF8.GetString(BasicFileIO.ReadFileIntoByteArray(selectedProfileDirectory));

            // Create and return the profile
            return(new Profile(selectedProfile));
        }

        #endregion

    }
}

#endregion