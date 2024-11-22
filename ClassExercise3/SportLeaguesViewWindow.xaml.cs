#region Namespaces Used

using ClassExercise3.DataSets;
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

        private SportLeaguesDataSet? SportLeaguesDataSet { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Simply calls InitializeComponent() to pars
        /// </summary>
        public SportLeaguesViewWindow()
        {
            InitializeComponent();
        }

        #endregion


        #region Event Handlers

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
        /// Calls LoadSportLeagues()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SportLeaguesViewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSportLeagues();
        }


        /// <summary>
        /// Update data grid on every team change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTeamSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Instantiates data set and adapters, then uses adapters
        /// to pull data from database.
        /// </summary>
        private void LoadSportLeagues()
        {
            // Instantiate the sport leagues data set
            SportLeaguesDataSet = new SportLeaguesDataSet();

            // Instantiate an adapter for teams, players, and rosters
            DataSets.SportLeaguesDataSetTableAdapters.teamsTableAdapter teamsTableAdapter = new DataSets.SportLeaguesDataSetTableAdapters.teamsTableAdapter();
            DataSets.SportLeaguesDataSetTableAdapters.playersInfoTableAdapter playersInfoTableAdapter = new DataSets.SportLeaguesDataSetTableAdapters.playersInfoTableAdapter();

            // Fill the data tables
            teamsTableAdapter.Fill(SportLeaguesDataSet.teams);
            playersInfoTableAdapter.Fill(SportLeaguesDataSet.playersInfo);

            // Set combo box and data grid up
            SetupControls();
        }


        /// <summary>
        /// Sets up initial position of cboTeamSelector, then updates data grid
        /// </summary>
        private void SetupControls()
        {
            // Ensure the data set was instantiaeted
            if (SportLeaguesDataSet == null) { return; }

            // Set combo box the source
            cboTeamSelector.ItemsSource = SportLeaguesDataSet.teams.DefaultView;

            // Setup display member and selected value
            cboTeamSelector.DisplayMemberPath = "teamname";
            cboTeamSelector.SelectedValuePath = "teamid";
            cboTeamSelector.SelectedIndex = 0;

            // Set initial binding, then update the data grid
            PlayerDataGrid.ItemsSource = SportLeaguesDataSet.playersInfo.DefaultView;
            UpdateDataGrid();
        }

        /// <summary>
        /// Updates data grid to display player names, jersey number, registration number,
        /// and if they are active or not based on the selected team
        /// </summary>
        private void UpdateDataGrid()
        {
            // Ensure the data set was instantiaeted
            if (SportLeaguesDataSet == null) { return; }

            // Convert players info data table to data view and filter based on selected team
            DataView selectedTeamDataView = new DataView(SportLeaguesDataSet.playersInfo);
            selectedTeamDataView.RowFilter = $"teamid = '{cboTeamSelector.SelectedValue}'";

            // Apply the filter
            PlayerDataGrid.ItemsSource = selectedTeamDataView;

        }


        #endregion
    }

}

#endregion