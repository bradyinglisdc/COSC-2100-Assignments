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
using System.Windows.Navigation;
using System.Windows.Shapes;

#endregion

#region Namespace Definition

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for pgMainMenu.xaml
    /// </summary>
    public partial class pgMainMenu : Page
    {
        #region Delegates and Events

        public delegate void PageChangedHandler(Page page);

        /// <summary>
        /// Invoked on page change on this instance.
        /// </summary>
        public event PageChangedHandler? PageChanged;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Just parse xaml.
        /// </summary>
        public pgMainMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Invokes PageChanged event with pgMyProjects.
        /// </summary>
        /// <param name="sender">btnMyProjects.</param>
        /// <param name="e">Event Args.</param>
        private void btnMyProjects_Click(object sender, EventArgs e)
        {
            PageChanged?.Invoke(new pgMyProjects());
        }

        /// <summary>
        /// Invokes PageChanged event with pgCommunityProjects.
        /// </summary>
        /// <param name="sender">btnMyProjects.</param>
        private void btnCommunityProjects_Click(object sender, EventArgs e)
        {
            PageChanged?.Invoke(new pgCommunityProjects());
        }

        #endregion 
    }
}

#endregion