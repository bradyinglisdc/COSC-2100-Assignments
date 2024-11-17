/*
 * Title: ProfileEditorWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for profile editing
 */

#region Namespaces Used

using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{
    /// <summary>
    /// Provides Interaction logic for ProfileEditorWindow
    /// </summary>
    public partial class ProfileEditorWindow : Window
    {

        #region Instance Properties

        /// <summary>
        /// Initial setting properties will be pulled from here. Changes made to settings will instantly 
        /// be stored in memory via EditedProfile, and if the user chooses to save, BoundProfile will become EditedProfile.
        /// </summary>
        public Profile BoundProfile { get; set; }

        /// <summary>
        /// A profile to store setting changes in memory.
        /// </summary>
        public Profile EditedProfile { get; set; }

        private bool ReturnToMenuOnExit { get; set; } = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor instantiates a new default profile
        /// </summary>
        public ProfileEditorWindow()
        {
            InitializeComponent();
            DataContext = this;
            BoundProfile = new Profile();
            EditedProfile = new Profile();
        }

        /// <summary>
        /// Parameterizerd constructor instantiates an existing profile
        /// </summary>
        /// <param name="profileToBind">The profile which the user will edit.</param>
        public ProfileEditorWindow(Profile profileToBind)
        {
            InitializeComponent();
            DataContext = this;
            BoundProfile = profileToBind;
            EditedProfile = Profile.InstantiateClone(BoundProfile);
            ReturnToMenuOnExit = true;
        }


        #endregion

        #region Event Handler Methods

        #region Options Button Clicks

        /// <summary>
        /// Switches input device in memory and hides sensitivity slider if touch is selected
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeInputDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.SwitchInputDevice();
            SensitivityContainer.Visibility = EditedProfile.InputDevice == GenericSettings.InputDevice.Touch ? Visibility.Hidden : Visibility.Visible;
        }

        /// <summary>
        /// Switches auto jump in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeAutoJumpButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.AutoJumpOn = !EditedProfile.AutoJumpOn;
        }

        /// <summary>
        /// Switches y axis in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void InvertYAxisButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.InvertYAxisOn = !EditedProfile.InvertYAxisOn;
        }

        /// <summary>
        /// Switches fancy graphics in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeFancyGraphicsButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.FancyGraphicsOn = !EditedProfile.FancyGraphicsOn;
        }

        /// <summary>
        /// Switches v sync in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeVSyncButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.VSyncOn = !EditedProfile.VSyncOn;
        }

        /// <summary>
        /// Switches fullscreen in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeFullscreenButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.FullscreenOn = !EditedProfile.FullscreenOn;
        }

        /// <summary>
        /// Switches ray tracing in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeRayTracingButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.RayTracingOn = !EditedProfile.RayTracingOn;
        }

        /// <summary>
        /// Switches up scaling in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeUpscalingButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.UpscalingOn = !EditedProfile.UpscalingOn;
        }

        /// <summary>
        /// Switches show coordinates in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeShowCoordinatesButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.ShowCoordinatesOn = !EditedProfile.ShowCoordinatesOn;
        }

        /// <summary>
        /// Switches camera perspective in memory.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeCameraPerspectiveButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.SwitchCameraPerspective();
        }

        #endregion

        #region Save/Discard Button Clicks

        /// <summary>
        /// Calls SaveProfile()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveProfile();
        }

        #endregion

        #region Interaction Logic
        
        /// <summary>
        /// Prompts user to edit profile name,
        /// then saves profile.
        /// </summary>
        private void SaveProfile()
        {
            (new ProfileSaverWindow(BoundProfile, EditedProfile, this)).ShowDialog();
        }

        /// <summary>
        /// Prompts user to confirm discard,
        /// then discards returns to profile view or menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiscardChanges_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to discard changes and return to profile browser?", $"Discard changes to profile: {BoundProfile.ProfileName}?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CloseWindow();
            }
        }

        /// <summary>
        /// Closes and returns to profile view or menu depending on ReturnToMenuOnExit property
        /// </summary>
        private void CloseWindow()
        {
            if (ReturnToMenuOnExit) { (new MainMenuWindow(false)).Show(); }
            else { (new ProfileViewerWindow()).Show(); }
            Close();
        }

        #endregion

        #endregion


    }
}

#endregion
