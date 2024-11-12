/*
 * Title: GenericSettings.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-11
 * Purpose: To provide a static class containing setting names and default setting values for any given instance of the Profile.cs class.
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
    /// A static class providing setting names and default setting values for any given instance of the Profile.cs class.
    /// </summary>
    public static class GenericSettings
    {
        #region Movement

        /// <summary>
        /// Enum representing the 3 input devices: Keyboard, Controller, and Touch
        /// </summary>
        public enum InputDevice
        {
            Keyboard,
            Controller,
            Touch
        }

        // Player movement defaults
        public const InputDevice DefaultInputDevice = InputDevice.Keyboard;
        public const bool DefaultAutoJump = true;
        public const int DefaultMouseSensitivity = 50;
        public const int DefaultControllerSensitivity = 50;
        public const bool DefaultInvertYAxis = false;

        // Player movement ranges
        public static int[] MouseSensitivityRange = { 30, 70 };
        public static int[] ControllerSensitivityRange = { 30, 70 };

        #endregion

        #region Video

        // Video defaults
        public const int DefaultBrightness = 50;
        public const bool DefaultFancyGraphics = true;
        public const bool DefaulVSync = true;
        public const bool DefaultFullscreen = false;
        public const int DefaultRenderDistance = 16;
        public const int DefaultFieldOfView = 64;
        public const bool DefaultRayTracing = false;
        public const bool DefaultUpscaling = false;

        // Video ranges
        public static int[] BrightnessRange = { 0, 100 };
        public static int[] RenderDistanceRange = { 4, 128 };
        public static int[] FiledOfViewRange = { 60, 90 };

        #endregion

        #region Audio

        // Audio defaults
        public const int DefaultMusicVolume = 100;
        public const int DefaultSoundVolume = 100;

        // Audio ranges
        public static int[] MusicVolumeRange = { 0, 100 };
        public static int[] SoundVolumeRange = { 0, 100 };

        #endregion

        #region Interface

        /// <summary>
        /// Enum representing the camera perspectives: First-person, Third-person front, and Third-person back
        /// </summary>
        public enum CameraPerspective
        {
            FirstPerson,
            ThirdPersonFront,
            ThirdPersonBack
        }

        // Interface defaults
        public const int DefaultHUDTransparency = 100;
        public const bool DefaultShowCoordinates = false;
        public const CameraPerspective DefaultCameraPerspective = CameraPerspective.FirstPerson;

        // Interface ranges
        public static int[] HUDTransparencyRange = { 25, 100 };

        #endregion

        #region General

        public const bool DefaultIsStartupProfile = false;

        #endregion

    }
}

#endregion