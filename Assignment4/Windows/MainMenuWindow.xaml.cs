/*
 * Title: MainMenuWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for viewing, editing and creating new minecraft setting profiles
 */

#region Namespaces Used

using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{
    /// <summary>
    /// Provides interaction logic for the main menu of this program. Allows user 
    /// to choose to edit existing profiles or exit the application.
    /// </summary>
    public partial class MainMenuWindow : Window
    {

        #region Constructors

        /// <summary>
        /// Default constructor simply instantiates and applies properties determined in the parsed xaml partial class,
        /// then loads splash screen along with all profiles.
        /// </summary>
        public MainMenuWindow()
        {
            InitializeComponent();
            InitializeApplication(true);
        }

        /// <summary>
        /// Loads splash screen and all profiles if specified.
        /// </summary>
        /// <param name="isFirstLoad">If true, first-time setup runs.</param>
        public MainMenuWindow(bool isFirstLoad)
        {
            InitializeComponent();
            InitializeApplication(isFirstLoad);
        }


        #endregion

        #region Event Handler Methods

        /// <summary>
        /// Calls EditStartupProfile()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void EditStartupProfileButton_Click(object sender, RoutedEventArgs e)
        {
            EditStartupProfile();
        }

        /// <summary>
        /// Calls OpenProfileViewer()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void ProfileViewerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenProfileViewer();
        }

        #endregion

        #region Interaction Logic

        /// <summary>
        /// Determines if a startup profile exists. If it does, hide this window and instantiate and open profile editor with that Profile,
        /// otherwise display a message informing the user of no startup profile
        /// </summary>
        private void EditStartupProfile()
        {
            Profile? startupProfile = Profile.GetStartupProfile();
            
            if (startupProfile == null)
            {
                MessageBox.Show("No startup profile is currently set. Click 'Profile Editor' to create/set one.");
                return;
            }
            OpenProfileEditor(startupProfile);
        }

        /// <summary>
        /// Hides this window, then instnatiates and opens ProfileViewerWindow
        /// </summary>
        private void OpenProfileViewer()
        {
            (new ProfileViewerWindow()).Show();
            Close();
        }

        /// <summary>
        /// Hides this window, then instnatiates and opens ProfileEditorWindow
        /// </summary>
        private void OpenProfileEditor(Profile profileToEdit)
        {
            (new ProfileEditorWindow(profileToEdit)).Show();
            Close();
        }

        #endregion

        #region Initialization Logic

        /// <summary>
        /// Loads splash screen and all profiles if is first load
        /// </summary>
        /// <param name="isFirstLoad">Determines if initialization should proceed.</param>
        private void InitializeApplication(bool isFirstLoad)
        {
            if (isFirstLoad) { (new SplashScreenWindow(this)).ShowDialog(); }
        }

        #endregion


    }
}

#endregion