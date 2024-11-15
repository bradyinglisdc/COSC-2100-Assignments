/*
 * Title: Profile.Definition.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-12
 * Purpose: To provide an instantiatable partial Profile class containing settings corresponding to minecraft. This portion contains all property/variable
 * definitions, as well as constructors.
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{
    public partial class Profile : INotifyPropertyChanged
    {

        #region Property Changed Event

        /// <summary>
        /// Property changed event handler. Essentially, when a WPF binding is made to a Profile, an auto generated method
        /// is subscribed to this event, such that when a property changed event occurs the auto generated method checks 
        /// the property that was changed; and if it was the bound property it updates the display.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

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

        // Profile
        private string _profileName = GetUniqueName();
        private bool _isStartupProfile = GenericSettings.DefaultIsStartupProfile;

        // Movement
        private GenericSettings.InputDevice _inputDevice = GenericSettings.DefaultInputDevice;
        private bool _autoJumpOn = GenericSettings.DefaultAutoJumpOn;
        private int _mouseSensitivity = GenericSettings.DefaultMouseSensitivity;
        private int _controllerSensitivity = GenericSettings.DefaultControllerSensitivity;
        private bool _invertYAxisOn = GenericSettings.DefaultInvertYAxisOn;

        // Video
        private int _brightness = GenericSettings.DefaultBrightness;
        private bool _fancyGraphicsOn = GenericSettings.DefaultFancyGraphicsOn;
        private bool _vSyncOn = GenericSettings.DefaultVSyncOn;
        private bool _fullScreenOn = GenericSettings.DefaultFullscreenOn;
        private int _renderDistance = GenericSettings.DefaultRenderDistance;
        private int _fieldOfView = GenericSettings.DefaultFieldOfView;
        private bool _rayTracingOn = GenericSettings.DefaultRayTracingOn;
        private bool _upscalingOn = GenericSettings.DefaultUpscalingOn;

        // Audio
        private int _musicVolume = GenericSettings.DefaultMusicVolume;
        private int _soundVolume = GenericSettings.DefaultSoundVolume;

        // Interface
        private int _hudTransparency = GenericSettings.DefaultHUDTransparency;
        private bool _showCoordinatesOn = GenericSettings.DefaultShowCoordinatesOn;
        private GenericSettings.CameraPerspective _cameraPerspective = GenericSettings.DefaultCameraPerspective;

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
                OnPropertyChanged(nameof(ProfileName));
            }
        }

        /// <summary>
        /// Gets or sets the value of is startup profile for this profile. If another profile is currently the startup profile,
        /// this one will take priority and the old one will be set to false.
        /// </summary>
        public bool IsStartupProfile
        {
            get { return _isStartupProfile; }
            set
            {
                ClearStartupProfile();
                _isStartupProfile = value;
                OnPropertyChanged(nameof(IsStartupProfile));
            }
        }

        /// <summary>
        /// Gets or sets the settings of this profile instance as a byte array for efficient storage.
        /// </summary>
        public byte[]? PackagedSettings { get; private set; }

        #region Movement

        /// <summary>
        /// Gets or sets the input device for this profile instance.
        /// </summary>
        public GenericSettings.InputDevice InputDevice
        {
            get { return _inputDevice; }
            set
            {
                _inputDevice = value;
                OnPropertyChanged(nameof(InputDevice));
            }
        } 

        /// <summary>
        /// Gets or sets the auto jump value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool AutoJumpOn
        {
            get { return _autoJumpOn; }
            set
            {
                _autoJumpOn = value;
                OnPropertyChanged(nameof(AutoJumpOn));
            }
        }

        /// <summary>
        /// Gets and sets the sensitivity of the currently selected input device
        /// </summary>
        public int CurrentInputDeviceSensitivity
        {
            get
            {
                if (InputDevice == GenericSettings.InputDevice.Keyboard) { return MouseSensitivity; }
                return ControllerSensitivity;
            }
            set
            {
                if (InputDevice == GenericSettings.InputDevice.Keyboard) { MouseSensitivity = value; }
                else { ControllerSensitivity = value; }
                OnPropertyChanged(nameof(CurrentInputDeviceSensitivity));
            }
        }

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
                OnPropertyChanged(nameof(MouseSensitivity));
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
                OnPropertyChanged(nameof(ControllerSensitivity));
            }
        }

        /// <summary>
        /// Gets or sets the invert y axis value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool InvertYAxisOn
        {
            get { return _invertYAxisOn; }
            set
            {
                _invertYAxisOn = value;
                OnPropertyChanged(nameof(InvertYAxisOn));
            }
        }

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
                OnPropertyChanged(nameof(Brightness));
            }
        }

        /// <summary>
        /// Gets or sets the fancy graphics value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool FancyGraphicsOn
        {
            get { return _fancyGraphicsOn; }
            set
            {
                _fancyGraphicsOn = value;
                OnPropertyChanged(nameof(FancyGraphicsOn));
            }
        }

        /// <summary>
        /// Gets or sets the v sync value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool VSyncOn
        {
            get { return _vSyncOn; }
            set
            {
                _vSyncOn = value;
                OnPropertyChanged(nameof(VSyncOn));
            }
        }


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
                OnPropertyChanged(nameof(RenderDistance));
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
                OnPropertyChanged(nameof(FieldOfView));
            }
        }

        /// <summary>
        /// Gets or sets the ray tracing value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool RayTracingOn
        {
            get { return _rayTracingOn; }
            set
            {
                _rayTracingOn = value;
                OnPropertyChanged(nameof(RayTracingOn));
            }
        }

        /// <summary>
        /// Gets or sets the upscaling value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool UpscalingOn
        {
            get { return _upscalingOn; }
            set
            {
                _upscalingOn = value;
                OnPropertyChanged(nameof(UpscalingOn));
            }
        }

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
                OnPropertyChanged(nameof(MusicVolume));
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
                OnPropertyChanged(nameof(SoundVolume));
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
                OnPropertyChanged(nameof(HUDTransparency));
            }
        }

        /// <summary>
        /// Gets or sets the show coordinates value of this instance to true or false (true = on, false = off)
        /// </summary>
        public bool ShowCoordinatesOn
        {
            get { return _showCoordinatesOn; }
            set
            {
                _showCoordinatesOn = value;
                OnPropertyChanged(nameof(ShowCoordinatesOn));
            }
        }

        /// <summary>
        /// Gets or sets the camera perspective of this instance.
        /// </summary>
        public GenericSettings.CameraPerspective CameraPerspective
        {
            get { return _cameraPerspective; }
            set
            {
                OnPropertyChanged(nameof(CameraPerspective));
            }
        }


        #endregion

        #endregion

        #region Constructors 

        /// <summary>
        /// Default constructor - default values already set on object initialization, so this constructor just adds the instance to memory
        /// </summary>
        public Profile()
        {
            Profiles.Add(this);
        }
          
        /// <summary>
        /// Takes in a raw settings string encoded as a byte array to read from
        /// </summary>
        /// <param name="rawSettings">The settings string as a byte array formatted in dictionary format</param>
        public Profile(byte[] rawSettings)
        {
            CreateProfileFromString(rawSettings);
            Profiles.Add(this);
        }

        /// <summary>
        /// Takes in all setable settings and sets them accordingly.
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="isStartupProfile"></param>
        /// <param name="packagedSettings"></param>
        /// <param name="inputDevice"></param>
        /// <param name="autoJumpOn"></param>
        /// <param name="mouseSensitivity"></param>
        /// <param name="controllerSensitivity"></param>
        /// <param name="invertYAxisOn"></param>
        /// <param name="brightness"></param>
        /// <param name="fancyGraphicsOn"></param>
        /// <param name="vSyncOn"></param>
        /// <param name="renderDistance"></param>
        /// <param name="fieldOfView"></param>
        /// <param name="rayTracingOn"></param>
        /// <param name="upscalingOn"></param>
        /// <param name="musicVolume"></param>
        /// <param name="soundVolume"></param>
        /// <param name="hudTransparency"></param>
        /// <param name="showCoordinatesOn"></param>
        /// <param name="cameraPerspective"></param>
        public Profile(
            string profileName,
            bool isStartupProfile,
            byte[]? packagedSettings,
            GenericSettings.InputDevice inputDevice,
            bool autoJumpOn,
            int mouseSensitivity,
            int controllerSensitivity,
            bool invertYAxisOn,
            int brightness,
            bool fancyGraphicsOn,
            bool vSyncOn,
            int renderDistance,
            int fieldOfView,
            bool rayTracingOn,
            bool upscalingOn,
            int musicVolume,
            int soundVolume,
            int hudTransparency,
            bool showCoordinatesOn,
            GenericSettings.CameraPerspective cameraPerspective)
        {
            
            ProfileName = profileName;
            IsStartupProfile = isStartupProfile;
            PackagedSettings = packagedSettings;
            InputDevice = inputDevice;
            AutoJumpOn = autoJumpOn;

            MouseSensitivity = mouseSensitivity; 
            ControllerSensitivity = controllerSensitivity; 
            InvertYAxisOn = invertYAxisOn;

            Brightness = brightness;
            FancyGraphicsOn = fancyGraphicsOn;
            VSyncOn = vSyncOn;
            RenderDistance = renderDistance; 
            FieldOfView = fieldOfView; 
            RayTracingOn = rayTracingOn;
            UpscalingOn = upscalingOn;

            MusicVolume = musicVolume; 
            SoundVolume = soundVolume; 

            HUDTransparency = hudTransparency; 
            ShowCoordinatesOn = showCoordinatesOn;
            CameraPerspective = cameraPerspective;

            Profiles.Add(this);
        }

        #endregion

    }
}

#endregion