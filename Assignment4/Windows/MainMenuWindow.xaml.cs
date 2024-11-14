/*
 * Title: MainMenuWindow.xa,l.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-14
 * Purpose: To provide an interface to the user for viewing, editing and creating new minecraft setting profiles
 */

#region Namespaces Used

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        /// Default constructor simply instantiates and applies properties determined in the parsed xaml partial class
        /// </summary>
        public MainMenuWindow()
        {
            InitializeComponent();
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
        }

        /// <summary>
        /// Hides this window, then instnatiates and opens ProfileViewerWindow
        /// </summary>
        private void OpenProfileViewer()
        {
            Hide();
            (new ProfileViewerWindow()).Show();
        }

        #endregion


    }
}

#endregion