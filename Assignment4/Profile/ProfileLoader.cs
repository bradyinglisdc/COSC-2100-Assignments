/*
 * Title: ProfileLoader.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-15
 * Purpose: Provides an interface between application windows and file IO operations
 */

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
                BasicFileIO.DeleteFile($"{GenericSettings.ProfileOutputDir}{profileName}");
            }

            catch (Exception ex)
            {
                throw new Exception($"Profile deletion error: {ex.Message}");
            }
        }

        #endregion

    }
}

#endregion