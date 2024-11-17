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

        #region Instance Properties for animation

        /// <summary>
        /// First index is when to stop shrinking bouncing text, last index is 
        /// when to stop growing bouncing text
        /// </summary>
        private static int[] FontSizeRange = { 20, 23 };

        /// <summary>
        /// Becomes true when the when the window application begins
        /// </summary>
        private bool WindowAnimating { get; set; } = false;

        /// <summary>
        /// Should be set to true when low end of fontsizerange is reached, false when high end is reached
        /// </summary>
        private bool GrowFont { get; set; } = false;

        #endregion


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
        private void btnEditStartupProfile_Click(object sender, RoutedEventArgs e)
        {
            EditStartupProfile();
        }

        /// <summary>
        /// Calls OpenProfileViewer()
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void btnProfileViewer_Click(object sender, RoutedEventArgs e)
        {
            OpenProfileViewer();
        }

        /// <summary>
        /// Calls CloseProgram();
        /// </summary>
        /// <param name="sender">The button which was clicked</param>
        /// <param name="e">Event args</param>
        private void btnQuitApplication_Click(object sender, RoutedEventArgs e)
        {
            CloseProgram();
        }

        #endregion

        #region Initialization Logic

        /// <summary>
        /// Loads splash screen and all profiles if is first load, then starts animating bouncing text
        /// </summary>
        /// <param name="isFirstLoad">Determines if initialization should proceed.</param>
        private void InitializeApplication(bool isFirstLoad)
        {
            // Open splash screen to begin loading profiles
            if (isFirstLoad) { (new SplashScreenWindow(this)).ShowDialog(); }

            // Begin animation
            AnimateScreen();
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
        /// Hides this window, then instnatiates and opens ProfileEditorWindow with a profile to edit
        /// </summary>
        private void OpenProfileEditor(Profile profileToEdit)
        {
            (new ProfileEditorWindow(profileToEdit)).Show();
            Close();
        }

        /// <summary>
        /// Closes the program if user agrees to prompt.
        /// </summary>
        private void CloseProgram()
        {
            if (MessageBox.Show("Are you sure you want to exit the program?", "Exit Profile Editor?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        #region Animation

        /// <summary>
        /// Animates bouncing logo so it appears it's getting bigger then smaller
        /// </summary>
        private async void AnimateScreen()
        {
            // Will loop while window is open, using async Task.Delay to return control
            // back to the program in between animations
            WindowAnimating = true;
            while (WindowAnimating)
            {
                // Determine if font size should grow or shrink
                if (tboBouncingLogo.FontSize <= FontSizeRange[0]) { GrowFont = true; }
                else if (tboBouncingLogo.FontSize >= FontSizeRange[1]) { GrowFont = false; }

                // Animate the font size so it appears bouncing
                AnimateFont();

                // As to not loop infinitely, return control to the program. Basically,
                // this loop will execute every 75 milliseconds
                await Task.Delay(75);
            }
        }

        /// <summary>
        /// Grows font if GrowFont is true, else shrinks
        /// </summary>
        private void AnimateFont()
        {
            if (GrowFont) { tboBouncingLogo.FontSize += 1; }
            else { tboBouncingLogo.FontSize -= 1; }
        }

        #endregion

        #endregion

    }
}

#endregion