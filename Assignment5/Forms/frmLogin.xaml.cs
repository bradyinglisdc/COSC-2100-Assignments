/*
 * Title: frmLogin.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-04
 * Purpose: Provides the interaction logic for frmLogin.xaml, allowing a user to login and find their associated data.
*/

#region Namespaces Used

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
        #region Constructor(s)

        /// <summary>
        /// Default constructor - just parses xaml
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
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
        private void btnLogin_MouseLeftButtonDown(object sender, EventArgs e)
        {
            //DBAL.User.GetUser()
        }

        #endregion
    }
}

#endregion