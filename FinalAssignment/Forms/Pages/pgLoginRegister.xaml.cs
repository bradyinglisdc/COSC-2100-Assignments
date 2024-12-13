/*
 * Title: frmMain.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: To provide interaction logic for pgLoginRegister.xaml
 * AI Use and Documentation: Lines xx, xx, xx ,xx
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using FinalAssignment.Models;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for pgLoginRegister.xaml
    /// </summary>
    public partial class pgLoginRegister : Page
    {
        #region Delegates and Events

        public delegate void UserStatusHandler();
        public event UserStatusHandler? LoggedIn;

        #endregion

        #region Constants and Static Variables

        private static Brush HoverHeaderBackground = new SolidColorBrush(Color.FromArgb(32,255,255,255));
        private static Brush DefaultHeaderBackground = Brushes.Transparent;
        private const int SelectedHeaderFontSize = 26;
        private const int DefaultHeaderFontSize = 20;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets and sets OnLoginSection value to determine which section to switch to.
        /// </summary>
        public bool OnLoginSection { get; set; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Parses xaml, then displays login page by default
        /// </summary>
        public pgLoginRegister()
        {
            InitializeComponent();
            UpdateSection();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Styles login or register button header to display a mouse enter.
        /// </summary>
        /// <param name="sender">btnLogin or btnRegister.</param>
        /// <param name="e">EventArgs.</param>
        private void btnHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            ((GenericButton)sender).Background = HoverHeaderBackground;
        }

        /// <summary>
        /// Styles login or register button header to display a mouse leave.
        /// </summary>
        /// <param name="sender">btnLogin or btnRegister.</param>
        /// <param name="e">EventArgs.</param>
        private void btnHeader_MouseLeave(object sender, MouseEventArgs e)
        {
            ((GenericButton)sender).Background = DefaultHeaderBackground;
        }

        /// <summary>
        /// Displays registration section.
        /// </summary>
        /// <param name="sender">btnRegister.</param>
        /// <param name="e">EventArgs.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (OnLoginSection) { UpdateSection(); }
        }

        /// <summary>
        /// Displays login section.
        /// </summary>
        /// <param name="sender">btnLogin.</param>
        /// <param name="e">EventArgs.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!OnLoginSection) { UpdateSection(); }
        }

        /// <summary>
        /// Shows registration password.
        /// </summary>
        /// <param name="sender"><cbxRegisterShowPassword./param>
        /// <param name="e">Event Args.</param>
        private void cbxRegisterShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            pbxRegisterPassword.Show = true;
        }

        /// <summary>
        /// Shows login password.
        /// </summary>
        /// <param name="sender"><cbxRegisterShowPassword./param>
        /// <param name="e">Event Args.</param>
        private void cbxLoginShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            pbxLoginPassword.Show = true;
        }

        /// <summary>
        /// Hides registration password.
        /// </summary>
        /// <param name="sender"><cbxRegisterShowPassword./param>
        /// <param name="e">Event Args.</param>
        private void cbxRegisterShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            pbxRegisterPassword.Show = false;
        }

        /// <summary>
        /// Hides login password.
        /// </summary>
        /// <param name="sender"><cbxRegisterShowPassword./param>
        /// <param name="e">Event Args.</param>
        private void cbxLoginShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            pbxLoginPassword.Show = false;
        }

        /// <summary>
        /// Calls AttemptLogin().
        /// </summary>
        /// <param name="sender">btnSubmitLogin.</param>
        /// <param name="e">Event Args./param>
        private void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        /// <summary>
        /// Calls AttemptRegister().
        /// </summary>
        /// <param name="sender">btnSubmitRegister.</param>
        /// <param name="e">Event Args./param>
        private void btnSubmitRegister_Click(object sender, EventArgs e)
        {
            AttemptRegister();
        }

        #endregion

        #region Login

        /// <summary>
        /// Attempts to log the user in, displaying an error if needed.
        /// </summary>
        private void AttemptLogin()
        {
            try
            {
                if (User.Login(tbxLoginUsername.Content, pbxLoginPassword.Content) == null)
                {
                    throw new Exception("Username or password incorrect.");
                }
                LoggedIn?.Invoke();
            }

            catch (Exception ex)
            {
                tboLoginError.Text = $"Login Error | {ex.Message}";

                bdrLoginError.Visibility = Visibility.Visible;
            }

       
        }

        #endregion

        #region Registration

        /// <summary>
        /// Attempts to register the user, displaying an error if needed.
        /// </summary>
        private void AttemptRegister()
        {
            try
            {
                User newRegister = new User(tbxRegisterUsername.Content, tbxRegisterEmail.Content);
                newRegister.Insert(pbxRegisterPassword.Content);
                LoggedIn?.Invoke();
            }

            catch (Exception ex)
            {
                tboRegisterError.Text = $"Registration Error | {ex.Message}";
                bdrLoginError.Visibility = Visibility.Hidden;
                bdrRegisterError.Visibility = Visibility.Visible;
            }
;
        }


        #endregion

        #region Logic

        /// <summary>
        /// Negates OnLoginSection, then shows the corresponding section
        /// </summary>
        private void UpdateSection()
        {
            OnLoginSection = !OnLoginSection;
            if (OnLoginSection) 
            { 
                // Styling
                grdLoginForm.Visibility = Visibility.Visible;
                grdRegistrationForm.Visibility = Visibility.Hidden;
                btnLogin.FontSize = SelectedHeaderFontSize;
                btnRegister.FontSize = DefaultHeaderFontSize;
                bdrRegisterError.Visibility = Visibility.Hidden;

                // Accessability
                btnCancelRegister.IsCancel = false;
                btnCancelLogin.IsCancel = true;
                btnSubmitRegister.IsDefault = false;
                btnSubmitLogin.IsDefault = true;

                return;
            }

            // Styling
            grdLoginForm.Visibility = Visibility.Hidden;
            grdRegistrationForm.Visibility = Visibility.Visible;
            btnLogin.FontSize = DefaultHeaderFontSize;
            btnRegister.FontSize = SelectedHeaderFontSize;
            bdrLoginError.Visibility = Visibility.Hidden;

            // Accessability
            btnCancelLogin.IsCancel = false;
            btnCancelRegister.IsCancel = true;
            btnSubmitLogin.IsDefault = false;
            btnSubmitRegister.IsDefault = true;
        }

        #endregion
    }
}

#endregion
