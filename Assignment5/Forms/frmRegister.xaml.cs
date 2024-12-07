/*
 * Title: frmRegister.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-07
 * Purpose: Provides the interaction logic for frmRegister.xaml, allowing user to create a new account.
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.DBAL;
using System.Windows;

#endregion

#region Namespace Definition

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for frmRegister.xaml
    /// </summary>
    public partial class frmRegister : Window
    {
        #region Constants 

        private static GridLength ERROR_GRID_HEIGHT = new GridLength(70);

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Just parses xaml.
        /// </summary>
        public frmRegister()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Just closes this.
        /// </summary>
        /// <param name="sender">btnLogin</param>
        /// <param name="e">Event args/param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Shows passkey.
        /// </summary>
        /// <param name="sender">cbxShowPasskey</param>
        /// <param name="e">Event argss</param>
        private void cbxShowPasskey_Checked(object sender, RoutedEventArgs e)
        {
            pbxPasskeyEntry.Show = true;
        }

        /// <summary>
        /// Hides passkey.
        /// </summary>
        /// <param name="sender">cbxShowPasskey</param>
        /// <param name="e">Event argss</param>
        private void cbxShowPasskey_Unchecked(object sender, RoutedEventArgs e)
        {
            pbxPasskeyEntry.Show = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AttemptRegister();
        }

        #endregion

        #region Logic

        /// <summary>
        /// Attempts register based on name, email and password, displays error if failure
        /// </summary>
        private void AttemptRegister()
        {
            try
            {
                User.CreateUser(tboFirstNameEntry.Content, tboLastNameEntry.Content, tboEmailEntry.Content, pbxPasskeyEntry.Content, true); 
                Close();
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

        #endregion
    }
}

#endregion