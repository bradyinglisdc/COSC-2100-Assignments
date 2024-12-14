/*
 * Title: frmMain.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: The main location for application interaction. This is the first form to be loaded. Within it,
 *          access is provided to a login/registration, main menu, a 'My Projects' page, a 'Community Projects' page, and statistics
 *          
 * AI Use and Documentation: No AI used for this class.
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
using FinalAssignment.Models;

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
            StartApplication();
            NavigateLoginRegister();
        }

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
        private void btnCloseWindow_Click(object? sender, EventArgs e)
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

        /// <summary>
        /// Called when pgLoginRegister's LoggedIn event is invoked.
        /// Proceeds to main menu
        /// </summary>
        private void PgToNavigate_LoggedIn()
        {
            NavigateMainMenu();
        }

        /// <summary>
        /// Called when pgMainMenu's PageChanged event is invoked. Navigates to
        /// the specified page.
        /// </summary>
        /// <param name="page">The page to navigate to.</param>
        private void PgToNavigateTo_PageChanged(Page page)
        {
            NavigateProjects(page);
        }

        /// <summary>
        /// Opens a producer window for the requested project.
        /// </summary>
        /// <param name="projectToEdit">The project to edit.</param>
        private void PgToNavigateTo_EditRequested(Project projectToEdit)
        {
            (new frmProduction(projectToEdit, false)).Show();
        }

        /// <summary>
        /// Called whem btnBack is clicked on phMyProjects or pgCommunityProjects.
        /// Navigates to man menu.
        /// </summary>
        /// <param name="sender">btnBack.</param>
        /// <param name="e">Event Args.</param>
        private void BtnBack_Click(object? sender, EventArgs e)
        {
            NavigateMainMenu();
        }

        /// <summary>
        /// Opens a read only producer window for the requested project.
        /// </summary>
        /// <param name="projectToView">The project to view.</param>
        private void PgToNavigateTo_ViewRequested(Project projectToView)
        {
            (new frmProduction(projectToView, true)).Show();
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

        #region Page Navigation

        /// <summary>
        /// Navigates page display to pgLoginRegister, subscribing to it's events.
        /// </summary>
        private void NavigateLoginRegister()
        {
            // Instantiate and subscribe
            pgLoginRegister pgToNavigate = new pgLoginRegister();
            pgToNavigate.btnCancelLogin.Click += btnCloseWindow_Click;
            pgToNavigate.btnCancelRegister.Click += btnCloseWindow_Click;
            pgToNavigate.LoggedIn += PgToNavigate_LoggedIn;

            // Navigate
            frmPageDisplay.Navigate(pgToNavigate);
        }

        /// <summary>
        /// Navigates page display to pgMainMenu, subscribing to it's events.
        /// </summary>
        private void NavigateMainMenu()
        {
            // Instantiate and subscribe
            pgMainMenu pgToNavigateTo = new pgMainMenu();
            pgToNavigateTo.btnQuit.Click += btnCloseWindow_Click;
            pgToNavigateTo.PageChanged += PgToNavigateTo_PageChanged;

            // Navigate
            frmPageDisplay.Navigate(pgToNavigateTo);
        }

        /// <summary>
        /// Navigates to the specified project page.
        /// </summary>
        /// <param name="page">An instance of the project page to navigate to.</param>
        private void NavigateProjects(Page page)
        {
            // Navigate based on page type
            if (page is pgMyProjects) { NavigateMyProjects(); }
            else { NavigateCommunityProjects(); }
        }

        /// <summary>
        /// Navigates page display to pgMyProjects, subscribing to it's events.
        /// </summary>
        private void NavigateMyProjects()
        {
            // Instantiate and subscribe
            pgMyProjects pgToNavigateTo = new pgMyProjects();
            pgToNavigateTo.btnBack.Click += BtnBack_Click;
            pgToNavigateTo.EditRequested += PgToNavigateTo_EditRequested;

            // Navigate
            frmPageDisplay.Navigate(pgToNavigateTo);
        }


        /// <summary>
        /// Navigates page display to pgCommunityProjects, subscribing to it's events.
        /// </summary>
        private void NavigateCommunityProjects()
        {
            // Instantiate and subscribe
            pgCommunityProjects pgToNavigateTo = new pgCommunityProjects();
            pgToNavigateTo.btnBack.Click += BtnBack_Click;
            pgToNavigateTo.EditRequested += PgToNavigateTo_ViewRequested;

            // Navigate
            frmPageDisplay.Navigate(pgToNavigateTo);
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
