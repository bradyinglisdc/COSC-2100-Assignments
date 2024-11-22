/*
 * Title: SportLeaguesViewWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-21
 * Purpose: To provide an interface for user reading of a sportleagues data base.
 */

#region Namespaces Used

using System.Windows;
using System.Windows.Input;
using System.Data;

#endregion

#region Namepsace Definition

namespace ClassExercise3
{
    /// <summary>
    /// Contains all interaction logic for SportLeaguesViewWindow.xaml
    /// </summary>
    public partial class SportLeaguesViewWindow : Window
    {

        #region Instance Properties

        /// <summary>
        /// This data view represents the data of all players within the sportleagues database.
        /// It will be filtered each time a selected team changes.
        /// </summary>
        public DataView? PlayersInfoView { get; set; }

        /// <summary>
        /// This data view represents the data of all teams within the sportleagues database.
        /// </summary>
        public DataView? TeamsInfoView { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes all properties
        /// </summary>
        public SportLeaguesViewWindow()
        {
            // Fill the data views and set data context before xaml parse
            try
            {
                PlayersInfoView = DataFetcher.GetPlayersAsView();
                TeamsInfoView = DataFetcher.GetTeamsAsView();
            }

            catch (Exception ex) 
            { 
                MessageBox.Show($"Error reading from sport leagues database. Application will exit after this message is closed:\n\n {ex.Message}");
                Close();
            }
            DataContext = this;
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Sets cboTeamSelector index to first team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SportLeaguesView_Loaded(object sender, RoutedEventArgs e)
        {
            cboTeamSelector.SelectedIndex = cboTeamSelector.Items.Count >= 0 ? 0 : -1;
        }

        /// <summary>
        /// This method allows the custom title bar to drag the window when the
        /// left mouse button down event is triggered on it.
        /// </summary>
        /// <param name="sender">the title bar grid.</param>
        /// <param name="e">Event args</param>
        private void TitlebarGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        /// <param name="sender">The button which was clicked.</param>
        /// <param name="e">Event args</param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender">The button which was clicked.</param>
        /// <param name="e">Event args</param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Filters players data view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTeamSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FilterPlayers();
        }


        #endregion

        #region Setup

        /// <summary>
        /// Filters the players info data view based on the selected team
        /// </summary>
        private void FilterPlayers()
        {
            if (PlayersInfoView == null) { return; }
            PlayersInfoView.RowFilter = $"teamid = '{cboTeamSelector.SelectedValue}'";
        }

        #endregion
    }

}

#endregion