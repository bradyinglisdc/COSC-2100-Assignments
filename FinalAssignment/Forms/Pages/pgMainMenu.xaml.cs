/*
 * Title: frmMainMenu.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-13
 * Purpose: Displays main options to user.
 *  
 * AI Use and Documentation: No AI used for this class.
*/

#region Namespaces Used

using System.Windows.Controls;

#endregion

#region Namespace Definition

namespace FinalAssignment
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