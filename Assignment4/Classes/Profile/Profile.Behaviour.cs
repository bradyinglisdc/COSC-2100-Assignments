/*
 * Title: Profile.Behaviour.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-11
 * Purpose: To provide an instantiatable partial Profile class containing settings corresponding to minecraft. This portion contains all methods
 * related to the class.
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region Instance Methods - Profile Writing

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

        #region Instance Methods - Profile Reading

        /// <summary>
        /// Interprets a formatted string as a dictionary then initializes properties.
        /// </summary>
        /// <param name="rawSettings">A formatted string with Profile settings in format: "SettingName: SettingValue, Setting2Name: Setting2Value"</param>
        private void CreateProfileFromString(string rawSettings)
        {
            // Separate each setting into a key value pair.
            string[] settingKeyValuePairs = rawSettings.Split(',');

            // Create a dictionary of settings
            Dictionary<string, string> settingDictionary = CreateProfileDictionary(settingKeyValuePairs);

            // Attempt to create the profile. If a parse exceptin is thrown, data was not formatted correctly

            try
            {
                CreateProfileFromDictionary(settingDictionary);
            }

            catch
            {
                throw new Exception("Incorrect settings format recieved.");
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
                string settingName = keyValuePair.Split(':')[0];
                string settingValue = keyValuePair.Split(": ")[1];
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

        #region General Static Methods

        /// <summary>
        /// Attempts to generate a unique name, checks if name is taken, and loops until unique name is found.
        /// </summary>
        /// <returns>A unique name.</returns>
        public static string GetUniqueName()
        {
            string uniqueName = $"GenericSettings.DefaultProfileName + {AutoNameNumber++}";

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
        /// Stores string cast of each Profile instance as an array of bytes for more secure storage.
        /// After this method is called, all Profile settings are ready to be written to a file.
        /// </summary>
        public static void PackageAllSettings()
        {
            // Iterate through all profiles, building a combined string where each profile is separated by '|'.
            string allSettings = string.Empty;
            foreach (Profile profile in Profiles)
            {
                allSettings += profile.ToString() + '|';
            }
            PackagedProfiles = Encoding.UTF8.GetBytes(allSettings);
        }

        /// <summary>
        /// Stores all procided profiles in static list within class.
        /// </summary>
        /// <param name="profilesByteArray">A byte array of all the profiles to store</param>
        public static void SetAllProfiles(byte[] profilesByteArray)
        {
            // Encode byte array back to string, then instantiate a Profile for each Profile
            string unpackagedProfiles = Encoding.UTF8.GetString(profilesByteArray);

            foreach (string rawSetting in unpackagedProfiles.Split('|'))
            {
                Profile profile = new Profile(rawSetting);
            }
        }

        #endregion

    }
}

#endregion