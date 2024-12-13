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
                grdLoginForm.Visibility = Visibility.Visible;
                grdRegistrationForm.Visibility = Visibility.Hidden;

                btnLogin.FontSize = SelectedHeaderFontSize;
                btnRegister.FontSize = DefaultHeaderFontSize;
                return;
            }
            grdLoginForm.Visibility = Visibility.Hidden;
            grdRegistrationForm.Visibility = Visibility.Visible;

            btnLogin.FontSize = DefaultHeaderFontSize;
            btnRegister.FontSize = SelectedHeaderFontSize;
        }

        #endregion
    }
}

#endregion
