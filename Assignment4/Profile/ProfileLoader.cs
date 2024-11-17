/*
 * Title: ProfileLoader.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-15
 * Purpose: Provides an interface between application windows and file IO operations
 */

#region Namespaces Used

using System.Text;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;

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
        /// Packages a provided profile and proceeds to attempt to save it to permanent storage.
        /// Allows user to write to custom path.
        /// </summary>
        /// <param name="profileToSave">The profile to save.</param>
        /// <param name="useCustomPath">Should be set to true if user is saving to a custom file path</param>
        public static void SaveProfile(Profile profileToSave, bool useCustomPath)
        {
            // Get binary representation of profile settings. Return if no still null
            profileToSave.PackcageSettings();
            if (profileToSave.PackagedSettings == null) { return; }

            // Get the path to write to
            string path = SaveFileDialog("Save a settings file (*.settings) | *.settings", profileToSave.ProfileName);

            // Begin file write.
            try
            {
                BasicFileIO.WriteByteArrayIntoFile($"{path}", profileToSave.PackagedSettings);
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
            string selectedProfileDirectory = OpenFileDialog("Select a Settings file (*.settings)|*.settings");

            // Return if no directory was selected. Otherwise read the file into a string.
            if (selectedProfileDirectory == string.Empty) { return null; }

            try
            {
                string selectedProfile = Encoding.UTF8.GetString(BasicFileIO.ReadFileIntoByteArray(selectedProfileDirectory));

                // Create and return the profile
                return (new Profile(selectedProfile));
            }

            catch (Exception ex)
            {
                throw new Exception($"Profile read error: {ex.Message}");
            }
        }

        /// <summary>
        /// Opens a file dialog and returns the selected file directory or an empty string.
        /// </summary>
        /// <param name="filter">File filter in format: Display Text|File Extension pattern</param>
        /// <returns>The directory of the selected file or an empty string if none selected</returns>
        private static string OpenFileDialog(string filter)
        {
            // Instantiate and apply filter to open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;

            // Open dialog and return the directory if the user selected a file, otherwise return an empty string
            if (openFileDialog.ShowDialog() == true) { return openFileDialog.FileName; }
            return string.Empty;
        }


        /// <summary>
        /// Opens a save file dialog and returns the path which the user wants to write to
        /// </summary>
        /// <param name="filter">File filter in format: Display Text|File Extension pattern</param>
        /// <param name="fileName">Default file name</param>
        /// <returns>The path which the user wants to write to, or an empty string if none selected</returns>
        public static string SaveFileDialog(string filter, string fileName)
        {
            // Instantiate and apply filter to save file dialog + default title and name
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = filter,
                Title = $"Save {fileName}",
                FileName = fileName
            };

            // Open dialog and return the directory if the user selected a folder, otherwise return an empty string
            if (saveFileDialog.ShowDialog() == true) { return saveFileDialog.FileName; }
            return string.Empty;
        }

        #endregion

    }
}

#endregion