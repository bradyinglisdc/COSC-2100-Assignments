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

        /// <summary>
        /// The main form to be unhidden when this window finishes load
        /// </summary>
        private MainMenuWindow MainMenu{ get; set; }

        /// <summary>
        /// A bool which determines if the profiles have finished loading
        /// </summary>
        private bool IsLoading { get; set; }

        /// <summary>
        /// To be used to index LoadProgressIndicators
        /// </summary>
        private int LoadProgressIndex { get; set; } = 0;

        /// <summary>
        /// State of profile load indicators, to be iterated through
        /// </summary>
        private string[] LoadProgressIndicators { get; } = { ".", "..", "..." };

        #endregion

        #region Constructors

        public SplashScreenWindow(MainMenuWindow mainMenu)
        {
            IsLoading = true;
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
                UpdateLoadingIndicator();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred:\n{ex.Message}");
                Close();
            }
            
        }

        /// <summary>
        /// Updates UI to indicate profiles were loaded. Waits 5 seconds to simulate load.
        /// </summary>
        private async void UpdateUI()
        {
            await Task.Delay(5000);
            IsLoading = false;
            tboProfileLoadIndicator.Text = $"Profiles Loaded: {Profile.Profiles.Count}";
            btnProceedToApplication.IsEnabled = true;
        }

        /// <summary>
        /// Updates loading indicator if the program is still loading.
        /// </summary>
        private async void UpdateLoadingIndicator()
        {
            // Update loading indicator, but use await to keep UI from bugging
            while (IsLoading)
            {
                // This will exit the method and proceed in 500 milliseconds
                await Task.Delay(500);

                // In case the load was complete while the delay was happening, do not update ui
                if (!IsLoading) { break; }
                GetNextLoadIndicator();
            }
        }

        /// <summary>
        /// Iterates to next load indicator and applies to UI
        /// </summary>
        private void GetNextLoadIndicator()
        {
            tboProfileLoadIndicator.Text = tboProfileLoadIndicator.Text.Replace(".", "") + LoadProgressIndicators[LoadProgressIndex++];
            if (LoadProgressIndex > 2) { LoadProgressIndex = 0; }
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