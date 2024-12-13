/*
 * Title: frmMain.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: The main location for application interaction. This is the first form to be loaded. Within it,
 *          access is provided to a login/registration, main menu, a 'My Projects' page, a 'Community Projects' page, and statistics
 *          
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
using System.Windows.Shapes;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        #region Constructor(s)

        /// <summary>
        /// Default Constructor - parses xaml then loads frmSplash wherin all notes will be loaded in to memory
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            frmPageDisplay.Navigate(new pgLoginRegister());
/*            StartApplication();
*/        }

        #endregion

        #region Event Handelrs

        /// <summary>
        /// Allows for window drag while left mouse button remains down on grdToolbar
        /// </summary>
        /// <param name="sender">grdToolbar.</param>
        /// <param name="e">Event Args.</param>
        private void grdToolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        /// <summary>
        /// Calls RequestClose()
        /// </summary>
        /// <param name="sender">btnCloseWindow.</param>
        /// <param name="e">EventArgs.</param>
        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            RequestClose();
        }

        /// <summary>
        /// Minimizes window.
        /// </summary>
        /// <param name="sender">btnMinimizeWindow.</param>
        /// <param name="e">Event Args.</param>
        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        #region Setup

        /// <summary>
        /// Splash screen loads from here.
        /// </summary>
        private void StartApplication()
        {
            // Splash screen will load all 132 notes into memory
            (new frmSplash(this)).Show();
            Hide();
        }

        #endregion

        #region End States

        /// <summary>
        /// Prompts user before closing the window and all open windows.
        /// </summary>
        private void RequestClose()
        {
            if (MessageBox.Show("To confirm exit, please press 'OK'", "Exit Producer Pal?", MessageBoxButton.OKCancel) == 
                MessageBoxResult.OK)
            {
                ConfirmClose();
            }
        }

        /// <summary>
        /// Closes the current window and all open windows.
        /// 
        /// AI Used: Yes
        /// Prompt: "Complete a ConfirmClose() method based on RequestClose()"
        /// Changes made: Nothing needed changing.
        /// </summary>
        private void ConfirmClose()
        {
            // Loop through all open windows and close them
            foreach (Window window in Application.Current.Windows)
            {
                window.Close();
            }
        }

        #endregion

    }
}

#endregion
