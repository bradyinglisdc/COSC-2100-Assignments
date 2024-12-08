/*
 * Title: frmLogin.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-04
 * Purpose: Provides the interaction logic for frmLogin.xaml, allowing a user to login and find their associated data.
*/

#region Namespaces Used

using Assignment5.DBAL;
using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        #region Instance Properties

        private frmMain frmBoundWindow { get; set; }

        #endregion

        #region Constants 

        private static GridLength ERROR_GRID_HEIGHT = new GridLength(70);

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default constructor - just parses xaml and instantiates a new main form
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            frmBoundWindow = new frmMain();
        }

        /// <summary>
        /// Paramaterized constructor - takes a main form to open on login
        /// </summary>
        public frmLogin(frmMain frmWindowToBind)
        {
            InitializeComponent();
            frmBoundWindow = frmWindowToBind;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Reveals the passkey
        /// </summary>
        /// <param name="sender">The checkbox</param>
        /// <param name="e">Event args</param>
        private void cbxShowPasskey_Checked(object sender, RoutedEventArgs e)
        {
            pbxPasskeyEntry.Show = true;
        }

        /// <summary>
        /// Hides the passkey
        /// </summary>
        /// <param name="sender">The checkbox</param>
        /// <param name="e">Event args</param>
        private void cbxShowPasskey_Unchecked(object sender, RoutedEventArgs e)
        {
            pbxPasskeyEntry.Show = false;
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="sender">Login button</param>
        /// <param name="e">Event args</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }
        
        /// <summary>
        /// Closes the application if user agrees.
        /// </summary>
        /// <param name="sender">Cancel button</param>
        /// <param name="e">Event args</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Shutdown();
        }

        /// <summary>
        /// Opens registration form.
        /// </summary>
        /// <param name="sender">Create account button</param>
        /// <param name="e">Event args</param>
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            (new frmRegister()).ShowDialog();
        }

        /// <summary>
        /// Opens main if user already logged in.
        /// </summary>
        /// <param name="sender">Window</param>
        /// <param name="e">Event args/param>
        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            /*if (User.CurrentUser != null) { ShowMain(); }*/
        }

        #endregion

        #region Logic

        /// <summary>
        /// Attempts login based on email and password, displays error if failure
        /// </summary>
        private void AttemptLogin()
        {
            try
            {
                if (User.GetUser(tboEmailEntry.Content, pbxPasskeyEntry.Content, true) == null) 
                { 
                    ShowError("No user by that email or password.");
                    return;
                }
                ShowMain();
            }

            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Displays an error message
        /// </summary>
        /// <param name="error">The error to display</param>
        private void ShowError(string error)
        {
            // Expand error area
            ErrorRow.Height = ERROR_GRID_HEIGHT;

            // Display the error
            tboErrorText.Text = error;
            bdrErrorContainer.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Shows the main form bound to this, and then closes this.
        /// </summary>
        private void ShowMain()
        {
            frmBoundWindow.Show();
            Close();
        }

        /// <summary>
        /// Prompts user before shutting down the application.
        /// </summary>
        private void Shutdown()
        {
            if (MessageBox.Show("Press 'Yes' to confirm and exit application.", "Exit application?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                frmBoundWindow.Close();
                Close();
            }
        }

        #endregion

    }
}

#endregion