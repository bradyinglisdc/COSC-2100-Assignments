/*
 * Title: SplashScreenWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-15
 * Purpose: To provide a visual graphic while the program loads
 */

#region Namespaces Used

using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment4
{

    /// <summary>
    /// Provides interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {

        #region Instance Properties

        MainMenuWindow MainMenu{ get; set; }

        #endregion

        #region Constructors

        public SplashScreenWindow(MainMenuWindow mainMenu)
        {
            MainMenu = mainMenu;
            InitializeComponent();
            LoadApplication();
        }

        #endregion

        #region Main Logic

        /// <summary>
        /// Hides main menu, loads profiles, and
        /// then allows user to proceed to editor on load finish.
        /// </summary>
        private void LoadApplication()
        {
            MainMenu.Hide();

            try
            {
                ProfileLoader.LoadProfiles();
                UpdateUI();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred:\n{ex.Message}");
            }
            
        }

        /// <summary>
        /// Updates UI to indicate profiles were loaded
        /// </summary>
        private void UpdateUI()
        {
            tboProfileLoadIndicator.Text = $"Profiles Loaded: {Profile.Profiles.Count}";
            btnProceedToApplication.Visibility = Visibility.Visible;
        }

        #endregion

        #region Event Handler Methods

        private void btnProceedToApplication_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Show();
            Close();
        }

        #endregion
    }
}

#endregion