/*
 * Title: frmSplash.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose (Extra feature): Displays tips which the user can cycle through while they wait for notes to load into memory.
 *          
 * AI Use and Documentation: AI not used for this class.
*/


#region Namespaces Used

using System.Windows;
using System.Windows.Input;
using FinalAssignment.Models;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for frmSplash.xaml
    /// </summary>
    public partial class frmSplash : Window
    {
        #region Static Variables and Constants

        private static string[] LoadingStates = { "Loading", "Loading.", "Loading..", "Loading...", };
        private static string[] TIPS = { "You can play the keys of the production piano without populating your timeline...", 
                                         "The production area does not support chords.", 
                                         "Due to a slight packaging issue, the timeline does't allow 2 of the same notes."};
        private const int LOADING_STATE_INTERVALS = 250;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets and sets loaded bool. Note new keyword is included here not for instnatiation, rather to
        /// hide an inherited member.
        /// </summary>
        private new bool Loaded { get; set; }

        /// <summary>
        /// Gets and sets the frmMain instance to be shown on load finish.
        /// </summary>
        private frmMain frmParent { get; set; }

        /// <summary>
        /// Gets and sets the index of currently displayd tip.
        /// </summary>
        private int CurrentTip { get; set; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default constructor - Parses xaml and starts loading notes into memory.
        /// </summary>
        public frmSplash()
        {
            CurrentTip = 0;
            frmParent = new frmMain();
            InitializeComponent();
            BeginLoad();
        }

        /// <summary>
        /// Param constructor - Parses xaml and starts loading notes into memory, setting
        /// frmParent to the specified one.
        /// </summary>
        /// <param name="main">The form to open on load finish.</param>
        public frmSplash(frmMain main)
        {
            CurrentTip = 0;
            frmParent = main;
            InitializeComponent();
            BeginLoad();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Allows for window dragging while left mouse button is held down
        /// </summary>
        /// <param name="sender">This window.</param>
        /// <param name="e">Event Args.</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        /// <summary>
        /// Closes application.
        /// </summary>
        /// <param name="sender">btnCancel.</param>
        /// <param name="e">Event Args.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseWithParent();
        }


        /// <summary>
        /// Proceeds to open parent form.
        /// </summary>
        /// <param name="sender">btnProceed.</param>
        /// <param name="e">EventArgs.</param>
        private void btnProceed_Click(object sender, EventArgs e)
        {
            Proceed();
        }

        /// <summary>
        /// Updates tboTip to display previous tip.
        /// </summary>
        /// <param name="sender">btnScrollLeftTip</param>
        /// <param name="e">Event Args.</param>
        private void btnScrollLeftTip_Click(object sender, EventArgs e)
        {
            if (CurrentTip == 0) { CurrentTip = TIPS.Length - 1; }
            else { CurrentTip = CurrentTip - 1; }
            tboTip.Text = TIPS[CurrentTip];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">btnScrollRightTip</param>
        /// <param name="e">Event Args.</param>
        private void btnScrollRightTip_Click(object sender, EventArgs e)
        {
            if (CurrentTip == TIPS.Length - 1) { CurrentTip = 0; }
            else { CurrentTip = CurrentTip + 1; }
            tboTip.Text = TIPS[CurrentTip];
        }

        #endregion

        #region Loading

        /// <summary>
        /// Async update UI
        /// </summary>
        private async void BeginLoad()
        {
            // Begin asynchronously loading
            Load();

            // Keep UI updated until loaded finished
            while (!Loaded)
            {
                foreach (string loadingState in LoadingStates)
                {
                    // Update UI
                    tboLoadingProgress.Text = loadingState;

                    // Pass control back to main thread
                    await Task.Delay(250);

                    // Break for loop if loaded
                    if (Loaded) { break; }
                }
            }

            // Update to final loaded state
            tboLoadingProgress.Text = $"{Note.Parents.Count} notes loaded!";
            btnProceed.IsEnabled = true;
        }
        /// <summary>
        /// Async loads notes. Fake loads a little.
        /// </summary>
        private async void Load()
        {
            try
            {
                await Task.Run(new Action(Note.FillParents));
                await Task.Run(new Action(User.Fill));
                await Task.Run(new Action(Project.Fill));
                await Task.Delay(5000); 
                Loaded = true;
            }
            catch (Exception ex) { MessageBox.Show($"Error loading application: {ex.Message}"); }
            
        }

        #endregion

        #region Closing States

        /// <summary>
        /// Opens parent and closes this.
        /// </summary>
        private void Proceed()
        {
            frmParent.Show();
            Close();
        }

        /// <summary>
        /// Closes this form, as well as it's frmParent.
        /// </summary>
        private void CloseWithParent()
        {
            frmParent.Close();
            Close();
        }

        #endregion

    }
}

#endregion