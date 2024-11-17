/*
 * Title: Profile.Behaviour.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-11
 * Purpose: To provide an instantiatable partial Profile class containing settings corresponding to minecraft. This portion contains all methods
 * related to the class.
 */

#region Namespaces Used

using System.ComponentModel;
using System.Text;
using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{
    /// <summary>
    /// An instance of this class will contain basic minecraft settings loaded from a text file.
    /// The class also contains various static and instance file IO methods for reading and writing settings.
    /// </summary>
    public partial class Profile
    {

        #region Instance Methods - Profile Writing Preparation

        /// <summary>
        /// Returns the string representation of this instance.
        /// </summary>
        /// <returns>The string representation of this instance</returns>
        public override string ToString()
        {
            return $"""
                ProfileName: {ProfileName}, 
                IsStartupProfile: {IsStartupProfile}, 
                InputDevice: {InputDevice}, 
                AutoJumpOn: {AutoJumpOn}, 
                MouseSensitivity: {MouseSensitivity}, 
                ControllerSensitivity: {ControllerSensitivity}, 
                InvertYAxisOn: {InvertYAxisOn}, 
                Brightness: {Brightness}, 
                FancyGraphicsOn: {FancyGraphicsOn}, 
                VSyncOn: {VSyncOn}, 
                RenderDistance: {RenderDistance}, 
                FieldOfView: {FieldOfView}, 
                RayTracingOn: {RayTracingOn}, 
                UpscalingOn: {UpscalingOn}, 
                MusicVolume: {MusicVolume}, 
                SoundVolume: {SoundVolume}, 
                HUDTransparency: {HUDTransparency}, 
                ShowCoordinatesOn: {ShowCoordinatesOn}, 
                CameraPerspective: {CameraPerspective}
                """;
        }

        /// <summary>
        /// Stores string cast of this instance as an array of bytes for more secure storage.
        /// After this method is called, this Profile's settings are ready to be written to a file.
        /// </summary>
        public void PackcageSettings()
        {
            PackagedSettings = Encoding.UTF8.GetBytes(ToString());
        }

        #endregion

        #region Instance Methods - Profile Reading Preparation

        /// <summary>
        /// Interprets a formatted string as a dictionary then initializes properties.
        /// </summary>
        /// <param name="rawSettings">A formatted string with,
        /// representing Profile settings in format: "SettingName: SettingValue, Setting2Name: Setting2Value"</param>
        private void CreateProfileFromString(string rawSettings)
        {
            // Separate each setting into a key value pair.
            string[] settingKeyValuePairs = rawSettings.Split(',');

            // Create a dictionary of settings
            Dictionary<string, string> settingDictionary = CreateProfileDictionary(settingKeyValuePairs);

            // Attempt to create the profile. If a parse exception is thrown, data was not formatted correctly
            try
            {
                CreateProfileFromDictionary(settingDictionary);
            }

            catch
            {
                throw new Exception("Incorrect settings format or already existing profile name recieved.");
            }

        }

        /// <summary>
        /// Creates a dictionary of profile settings based on a formatted string array of key value pairs..
        /// </summary>
        /// <param name="settingKeyValuePairs">A key value pair as a string (settingName: settingValue, setting2Name: setting2Value)</param>
        /// <returns></returns>
        public Dictionary<string, string> CreateProfileDictionary(string[] settingKeyValuePairs)
        {
            // A dictionary from which values will be read to. Applies default values at first.
            Dictionary<string, string> settingDictionary = new Dictionary<string, string>()
            {
                { "ProfileName", ProfileName },
                { "IsStartupProfile", IsStartupProfile.ToString() },
                { "InputDevice", InputDevice.ToString() },
                { "AutoJumpOn", AutoJumpOn.ToString() },
                { "MouseSensitivity", MouseSensitivity.ToString() },
                { "ControllerSensitivity", ControllerSensitivity.ToString() },
                { "InvertYAxisOn", InvertYAxisOn.ToString() },
                { "Brightness", Brightness.ToString() },
                { "FancyGraphicsOn", FancyGraphicsOn.ToString() },
                { "VSyncOn", VSyncOn.ToString() },
                { "RenderDistance", RenderDistance.ToString() },
                { "FieldOfView", FieldOfView.ToString() },
                { "RayTracingOn", RayTracingOn.ToString() },
                { "UpscalingOn", UpscalingOn.ToString() },
                { "MusicVolume", MusicVolume.ToString() },
                { "SoundVolume", SoundVolume.ToString() },
                { "HUDTransparency", HUDTransparency.ToString() },
                { "ShowCoordinatesOn", ShowCoordinatesOn.ToString() },
                { "CameraPerspective", CameraPerspective.ToString() }
            };

            // Iterate through each key value pair, storing each in the dictionary
            foreach (string keyValuePair in settingKeyValuePairs)
            {
                if (keyValuePair.Split(": ").Length < 2) { break; }
                string settingName = keyValuePair.Split(": ")[0].Trim();
                string settingValue = keyValuePair.Split(": ")[1].Trim();
                settingDictionary[settingName] = settingValue;
            }
            
            return settingDictionary;
        }

        /// <summary>
        /// Initializes this instance's properties based of a provided dictionary
        /// </summary>
        /// <param name="settingDictionary">The dictionary to pull settings from.</param>
        private void CreateProfileFromDictionary(Dictionary<string, string> settingDictionary)
        {
            ProfileName = settingDictionary["ProfileName"];
            InputDevice = (GenericSettings.InputDevice)Enum.Parse(typeof(GenericSettings.InputDevice), settingDictionary["InputDevice"]);
            AutoJumpOn = bool.Parse(settingDictionary["AutoJumpOn"]);
            MouseSensitivity = int.Parse(settingDictionary["MouseSensitivity"]);
            ControllerSensitivity = int.Parse(settingDictionary["ControllerSensitivity"]);
            InvertYAxisOn = bool.Parse(settingDictionary["InvertYAxisOn"]);

            Brightness = int.Parse(settingDictionary["Brightness"]);
            FancyGraphicsOn = bool.Parse(settingDictionary["FancyGraphicsOn"]);
            VSyncOn = bool.Parse(settingDictionary["VSyncOn"]);
            RenderDistance = int.Parse(settingDictionary["RenderDistance"]);
            FieldOfView = int.Parse(settingDictionary["FieldOfView"]);
            RayTracingOn = bool.Parse(settingDictionary["RayTracingOn"]);
            UpscalingOn = bool.Parse(settingDictionary["UpscalingOn"]);

            MusicVolume = int.Parse(settingDictionary["MusicVolume"]);
            SoundVolume = int.Parse(settingDictionary["SoundVolume"]);

            HUDTransparency = int.Parse(settingDictionary["HUDTransparency"]);
            ShowCoordinatesOn = bool.Parse(settingDictionary["ShowCoordinatesOn"]);
            ShowCoordinatesOn = bool.Parse(settingDictionary["ShowCoordinatesOn"]);
            CameraPerspective = (GenericSettings.CameraPerspective)Enum.Parse(typeof(GenericSettings.CameraPerspective), settingDictionary["CameraPerspective"]);
        }

        #endregion

        #region Instance Methods - General

        /// <summary>
        /// Invokes propety changed event if it isn't null (meaning if it has any methods subscribed to it).
        /// The name of the property as a string is passed in as an event arg, such that it can be determined easily
        /// which property was changed
        /// </summary>
        /// <param name="propertyName">The name of the property which was changed as a string</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Switches to the next input device based on the enum definition
        /// </summary>
        public void SwitchInputDevice()
        {
            if (InputDevice == GenericSettings.InputDevice.Keyboard) { InputDevice = GenericSettings.InputDevice.Controller; }
            else if (InputDevice == GenericSettings.InputDevice.Controller) { InputDevice = GenericSettings.InputDevice.Touch; }
            else { InputDevice = GenericSettings.InputDevice.Keyboard; }
        }

        /// <summary>
        /// Switches to the next camera perspective based on the enum definition
        /// </summary>
        public void SwitchCameraPerspective()
        {
            if (CameraPerspective == GenericSettings.CameraPerspective.FirstPerson) { CameraPerspective = GenericSettings.CameraPerspective.ThirdPersonBack; }
            else if (CameraPerspective == GenericSettings.CameraPerspective.ThirdPersonBack) { CameraPerspective = GenericSettings.CameraPerspective.ThirdPersonFront; }
            else { CameraPerspective = GenericSettings.CameraPerspective.FirstPerson; }
        }

        /// <summary>
        /// Copies all properties of the provided profile into this instance - except for the name
        /// </summary>
        /// <param name="profileToCloneFrom">The profile to pull properties from.</param>
        public void Clone(Profile profileToCloneFrom)
        {
            InputDevice = profileToCloneFrom.InputDevice;
            AutoJumpOn = profileToCloneFrom.AutoJumpOn;
            MouseSensitivity = profileToCloneFrom.MouseSensitivity;
            ControllerSensitivity = profileToCloneFrom.ControllerSensitivity;
            InvertYAxisOn = profileToCloneFrom.InvertYAxisOn;
            
            Brightness = profileToCloneFrom.Brightness;
            FancyGraphicsOn = profileToCloneFrom.FancyGraphicsOn;
            VSyncOn = profileToCloneFrom.VSyncOn;
            FullscreenOn = profileToCloneFrom.FullscreenOn;
            RenderDistance = profileToCloneFrom.RenderDistance;
            FieldOfView = profileToCloneFrom.FieldOfView;
            RayTracingOn = profileToCloneFrom.RayTracingOn;
            UpscalingOn = profileToCloneFrom.UpscalingOn;
            
            MusicVolume = profileToCloneFrom.MusicVolume;
            SoundVolume = profileToCloneFrom.SoundVolume;
           
            HUDTransparency = profileToCloneFrom.HUDTransparency;
            ShowCoordinatesOn = profileToCloneFrom.ShowCoordinatesOn;
            CameraPerspective = profileToCloneFrom.CameraPerspective;
        }

        #endregion

        #region Static Methods - Read Preperation

        /// <summary>
        /// Taks a byte array of profiles. Each profile should be separated by a '|'.
        /// Each setting should be separated by a ','.
        /// And each key value pair should be separated by a ': '
        /// </summary>
        /// <param name="rawProfiles">The profile array to read from.</param>
        public static void CreateAllProfiles(byte[] rawProfiles)
        {
            // Separate each profile by |
            string profilesAsString = Encoding.UTF8.GetString(rawProfiles);
            string[] separatedProfiles = profilesAsString.Split('|');

            // Instantiate all profiles. Break on last array index.
            foreach (string rawSetting in separatedProfiles)
            {
                if (rawSetting == string.Empty) { break; }
                new Profile(rawSetting);
            }

        }

        #endregion

        #region General Static Methods

        /// <summary>
        /// Attempts to generate a unique name, checks if name is taken, and loops until unique name is found.
        /// </summary>
        /// <returns>A unique name.</returns>
        public static string GetUniqueName()
        {
            string uniqueName = $"{GenericSettings.DefaultProfileName} {AutoNameNumber++}";

            // Loop until name is unique, then return it.
            while (FindProfileByName(uniqueName) != null) { uniqueName = $"GenericSettings.DefaultProfileName + {AutoNameNumber++}"; }
            return uniqueName;
        }

        /// <summary>
        /// Takes in a name then searches static list of all profiles in memory by that name for a match.
        /// </summary>
        /// <param name="name">The name to find a profile by.</param>
        /// <returns>The matching profile if it's found, otherwise null.</returns>
        public static Profile? FindProfileByName(string name)
        {
            foreach (Profile profile in Profiles)
            {
                if (profile.ProfileName == name) { return profile; }
            }
            return null;
        }

        /// <summary>
        /// Deletes a file from memory corresponding to the provided name if it exists in memory.
        /// </summary>
        /// <param name="name">The file to delete</param>
        public static void DeleteProfileByName(string name)
        {
            Profile? profileToDelete = FindProfileByName(name);
            if (profileToDelete != null) { }
        }

        /// <summary>
        /// Sets any profile with IsStartupProfile true to false
        /// </summary>
        private static void ClearStartupProfile()
        {
            foreach (Profile profile in Profiles)
            {
                if (profile.IsStartupProfile == true) { profile._isStartupProfile = false; }
            }
        }

        /// <summary>
        /// Searches through static list of profiles for the first startup profile.
        /// </summary>
        /// <returns>A Profile with IsStartUpProfile set to true if one exists, null if there is none.</returns>
        public static Profile? GetStartupProfile()
        {
            foreach (Profile profile in Profiles)
            {
                if (profile.IsStartupProfile == true) { return profile; }
            }
            return null;
        }

        /// <summary>
        /// Removes and replaces a set of profiles from the static list
        /// </summary>
        /// <param name="profileToAdd">The profile to add to the list</param>
        /// <param name="profileToReplace">The profile to remove from the list</param>
        public static void Swap(Profile profileToAdd, Profile profileToReplace)
        {
            Profiles.Remove(profileToReplace);
            Profiles.Add(profileToAdd);
        }

        /// <summary>
        /// Returns a new profile instance with the provided instances properties
        /// </summary>
        /// <param name="profileToCloneFrom">The profile to pull properties from</param>
        /// <returns>The profile as a clone</returns>
        public static Profile InstantiateClone(Profile profileToCloneFrom)
        {
            Profile clonedProfile = new Profile();
            clonedProfile.Clone(profileToCloneFrom);
            return clonedProfile;
        }

        #endregion

    }
}

#endregion