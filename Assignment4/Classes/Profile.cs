/*
 * Title: Profile.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-11
 * Purpose: To provide an instantiatable Profile class containing settings corresponding to minecraft.
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
    public class Profile
    {

        #region Static Properties/Variables

        /// <summary>
        /// Profiles will be read from permanent storage into this list, where they'll be stored in memory until explicity cleared
        /// </summary>
        public static List<Profile> Profiles = new List<Profile>();

        /// <summary>
        /// A number to be concatenated with GenericSettings.DefaultName and incremented by 1 for each unique name generation. 
        /// </summary>
        private static int AutoNameNumber = 0;

        #endregion

        #region Private Backing Members

        // Defaults initialized directly on class instantiation to minimize redundancy
        private string _profileName = GetUniqueName();
        private int _mouseSensitivity = GenericSettings.DefaultMouseSensitivity;
        private int _controllerSensitivity = GenericSettings.DefaultControllerSensitivity;
        private int _brightness = GenericSettings.DefaultBrightness;

        private int _renderDistance = GenericSettings.DefaultRenderDistance;
        private int _fieldOfView = GenericSettings.DefaultFieldOfView;
        private int _musicVolume = GenericSettings.DefaultMusicVolume;
        private int _soundVolume = GenericSettings.DefaultSoundVolume;

        private int _hudTransparency = GenericSettings.DefaultHUDTransparency;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets or sets the name of this profile instance. If the name already exists or is not within the allowed range, an exception is thrown.
        /// </summary>
        public string ProfileName
        {
            get { return _profileName; }
            set
            {
                if (FindProfileByName(value) != null)
                {
                    throw new Exception($"The name '{value} already exists.'");
                }

                else if (value.Length < GenericSettings.ProfileNameLengthRange[0] || value.Length > GenericSettings.ProfileNameLengthRange[1])
                {
                    throw new Exception($"Name length must be greater than or equal to {GenericSettings.ProfileNameLengthRange[0]} and less than or equal {GenericSettings.ProfileNameLengthRange[1]}.");
                }

                _profileName = value;
            }
        }

        #region Movement

        /// <summary>
        /// Gets or sets the input device for this profile instance.
        /// </summary>
        public GenericSettings.InputDevice InputDevice { get; set; } = GenericSettings.DefaultInputDevice;

        /// <summary>
        /// Gets or sets the auto jump value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool AutoJumpOn { get; set; } = GenericSettings.DefaultAutoJumpOn;

        /// <summary>
        /// Gets or sets the mouse sensitivity of this instance. If it is not within the allowed range, an exception is thrown.
        /// </summary>
        public int MouseSensitivity
        {
            get { return _mouseSensitivity; }
            set
            {
                if (value < GenericSettings.MouseSensitivityRange[0] || value > GenericSettings.MouseSensitivityRange[1])
                {
                    throw new Exception($"Mouse sensitivity must be greater than or equal to {GenericSettings.MouseSensitivityRange[0]} and less than or equal to {GenericSettings.MouseSensitivityRange[1]}.");
                }

                _mouseSensitivity = value;
            }
        }

        /// <summary>
        /// Gets or sets the controller sensitivity of this instance. If it is not within the allowed range, an exception is thrown.
        /// </summary>
        public int ControllerSensitivity
        {
            get { return _controllerSensitivity; }
            set
            {
                if (value < GenericSettings.ControllerSensitivityRange[0] || value > GenericSettings.ControllerSensitivityRange[1])
                {
                    throw new Exception($"Controller sensitivity must be greater than or equal to {GenericSettings.ControllerSensitivityRange[0]} and less than or equal to {GenericSettings.ControllerSensitivityRange[1]}.");
                }

                _mouseSensitivity = value;
            }
        }

        /// <summary>
        /// Gets or sets the invert y axis value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool InvertYAxisOn { get; set; } = GenericSettings.DefaultInvertYAxisOn;


        #endregion

        #region Video

        /// <summary>
        /// Gets or sets the brightness of this instance. If brightness is not within allowed range, exception is thrown.
        /// </summary>
        public int Brightness
        {
            get { return _brightness; }
            set
            {
                if (value < GenericSettings.BrightnessRange[0] || value > GenericSettings.BrightnessRange[1])
                {
                    throw new Exception($"Brightness must be greater than or equal to {GenericSettings.BrightnessRange[0]} and less than or equal {GenericSettings.BrightnessRange[1]}.");
                }

                _brightness = value;
            }
        }

        /// <summary>
        /// Gets or sets the fancy graphics value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool FancyGraphicsOn { get; set; } = GenericSettings.DefaultFancyGraphicsOn;

        /// <summary>
        /// Gets or sets the v sync value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool VSyncOn { get; set; } = GenericSettings.DefaulVSyncOn;


        /// <summary>
        /// Gets or sets the render distance of this instance. If render distance is not within allowed range, exception is thrown.
        /// </summary>
        public int RenderDistance
        {
            get { return _renderDistance; }
            set
            {
                if (value < GenericSettings.RenderDistanceRange[0] || value > GenericSettings.RenderDistanceRange[1])
                {
                    throw new Exception($"Render distance must be greater than or equal to {GenericSettings.RenderDistanceRange[0]} and less than or equal {GenericSettings.RenderDistanceRange[1]}.");
                }

                _renderDistance = value;
            }
        }


        /// <summary>
        /// Gets or sets the field of view of this instance. If field of view is not within allowed range, exception is thrown.
        /// </summary>
        public int FieldOfView
        {
            get { return _fieldOfView; }
            set
            {
                if (value < GenericSettings.FieldOfViewRange[0] || value > GenericSettings.FieldOfViewRange[1])
                {
                    throw new Exception($"Field of view must be greater than or equal to {GenericSettings.FieldOfViewRange[0]} and less than or equal {GenericSettings.FieldOfViewRange[1]}.");
                }

                _fieldOfView = value;
            }
        }

        /// <summary>
        /// Gets or sets the ray tracing value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool RayTracingOn { get; set; } = GenericSettings.DefaultRayTracingOn;

        /// <summary>
        /// Gets or sets the upscaling value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool UpscalingOn { get; set; } = GenericSettings.DefaultUpscalingOn;

        #endregion

        #region Audio
        
        /// <summary>
        /// Gets or sets the music volume of this instance. If music volume is not within allowed range, exception is thrown.
        /// </summary>
        public int MusicVolume
        {
            get { return _musicVolume; }
            set
            {
                if (value < GenericSettings.MusicVolumeRange[0] || value > GenericSettings.MusicVolumeRange[1])
                {
                    throw new Exception($"Music volume must be greater than or equal to {GenericSettings.MusicVolumeRange[0]} and less than or equal {GenericSettings.MusicVolumeRange[1]}.");
                }

                _musicVolume = value;
            }
        }

        /// <summary>
        /// Gets or sets the sound volume of this instance. If sound volume is not within allowed range, exception is thrown.
        /// </summary>
        public int SoundVolume
        {
            get { return _soundVolume; }
            set
            {
                if (value < GenericSettings.SoundVolumeRange[0] || value > GenericSettings.SoundVolumeRange[1])
                {
                    throw new Exception($"Sound volume must be greater than or equal to {GenericSettings.SoundVolumeRange[0]} and less than or equal {GenericSettings.SoundVolumeRange[1]}.");
                }

                _soundVolume = value;
            }
        }

        #endregion

        #region Interface

        /// <summary>
        /// Gets or sets the hud transparency of this instance. If transparency is not within allowed range, exception is thrown.
        /// </summary>
        public int HUDTransparency
        {
            get { return _hudTransparency; }
            set
            {
                if (value < GenericSettings.HUDTransparencyRange[0] || value > GenericSettings.HUDTransparencyRange[1])
                {
                    throw new Exception($"HUD transparency must be greater than or equal to {GenericSettings.HUDTransparencyRange[0]} and less than or equal {GenericSettings.HUDTransparencyRange[1]}.");
                }

                _hudTransparency = value;
            }
        }

        /// <summary>
        /// Gets or sets the show coordinates value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool ShowCoordinatesOn { get; set; } = GenericSettings.DefaultShowCoordinatesOn;

        /// <summary>
        /// Gets or sets the camera perspective of this instance.
        /// </summary>
        public GenericSettings.CameraPerspective CameraPerspective { get; set; } = GenericSettings.DefaultCameraPerspective;


        #endregion

        #endregion

        #region General Static Methods

        /// <summary>
        /// Attempts to generate a unique name, checks if name is taken, and loops until unique name is found.
        /// </summary>
        /// <returns></returns>
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

        #endregion



    }
}

#endregion