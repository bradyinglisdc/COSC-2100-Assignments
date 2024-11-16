/*
 * Title: ProfileViewerWindow.xaml.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-15
 * Purpose: To provide interaction logic for each profiler view
 */

#region Namespaces Used

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#endregion

#region Namespace Definition

namespace Assignment4
{
    /// <summary>
    /// Provides interaction logic for ProfileViewUserControl.xaml
    /// </summary>
    public partial class ProfileViewUserControl : UserControl
    {

        #region Constructors

        public ProfileViewUserControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler Methods

        /// <summary>
        /// Styles to indicate a mouse hover.
        /// </summary>
        /// <param name="sender">The container being hovered</param>
        /// <param name="e">Event args</param>
        private void ProfileDisplay_MouseEnter(object sender, MouseEventArgs e)
        {
            ProfileDisplay.Background = new SolidColorBrush(Color.FromArgb(153, 30, 30, 30));
        }

        /// <summary>
        /// Styles to indicate a mouse leave.
        /// </summary>
        /// <param name="sender">The container being hovered</param>
        /// <param name="e">Event args</param>
        private void ProfileDisplay_MouseLeave(object sender, MouseEventArgs e)
        {
            ProfileDisplay.Background = new SolidColorBrush(Color.FromArgb(102, 30, 30, 30));
        }
        
        #endregion

    }
}

#endregion
