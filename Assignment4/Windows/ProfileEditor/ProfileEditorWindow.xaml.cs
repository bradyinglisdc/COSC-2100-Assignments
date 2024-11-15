/*
 * Title: ProfileEditorWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for profile editing
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        #endregion

        #region Event Handler Methods

        /// <summary>
        /// Initializes values to be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// Switches input device in memory and updates slider to reflect new device sensitiviy.
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ChangeInputDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            EditedProfile.SwitchInputDevice();
            UpdateSensitivitySlider();
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
        /// Updates currently selecyed device's sensitivity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SensitivitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateSensitivity();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Sets all properties which need to be added manually
        /// </summary>
        private void Initialize()
        {
            UpdateSensitivitySlider();
        }

        #endregion

        #region Interaction Logic

        /// <summary>
        /// Sets the value of the sensitivity slider to the current input device's sensitivity
        /// </summary>
        private void UpdateSensitivitySlider()
        {
            SensitivitySlider.Value = EditedProfile.CurrentInputDeviceSensitivity;
        }


        private void UpdateSensitivity()
        {
            if (EditedProfile != null) { EditedProfile.CurrentInputDeviceSensitivity = (int)SensitivitySlider.Value; }
        }


        #endregion
    }
}

#endregion
