/*
 * Title: ProfileViewerWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for Profile creation and searching
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
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
    /// This calss provides interaction logic for the profile viewer window
    /// </summary>
    public partial class ProfileViewerWindow : Window
    {

        #region Instance Properties

        /// <summary>
        /// The main menu associated with this window instance
        /// </summary>
        private MainMenuWindow MainMenu { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor simply instantiates and applies properties determined in the parsed xaml partial class.
        /// Since this default constructor would not take in a main menu window, it instantiates a new one
        /// </summary>
        public ProfileViewerWindow()
        {
            MainMenu = new MainMenuWindow();
            Profile.CreateAllProfiles(BasicFileIO.ReadDirectoryIntoByteArray($"{GenericSettings.ProfileOutputURL}"));
            InitializeComponent();
        }

        /// <summary>
        /// Keeps track of main menu by storing it as a member in case user decides to go back.
        /// </summary>
        /// <param name="mainMenu"></param>
        public ProfileViewerWindow(MainMenuWindow mainMenu)
        {
            MainMenu = mainMenu;
            InitializeComponent();
        }

        #endregion

        #region Event Handler Methods

        /// <summary>
        /// Calls ReturnToMainMenu()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ReturnToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMainMenu();
        }

        /// <summary>
        /// Calls EditSelectedProfile()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditSelectedProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMainMenu();
        }

        /// <summary>
        /// Calls CreateNewProfile()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void CreateNewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProfile();
        }
        #endregion

        #region Interaction Logic

        /// <summary>
        /// Unhides main menu window and closes this window
        /// </summary>
        private void ReturnToMainMenu()
        {
            MainMenu.Show();
            Close();
        }

        /// <summary>
        /// Closes this window, then instantiates and opens a new ProfileEditorWindow, calling the default constructor
        /// </summary>
        private void CreateNewProfile()
        {
            (new ProfileEditorWindow()).Show();
            Close();
        }

        #endregion


    }
}

#endregion