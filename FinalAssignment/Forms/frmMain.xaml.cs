/*
 * Title: frmMain.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: The main location for application interaction. This is the first form to be loaded. Within it,
 *          access is provided to a main menu, a 'My Projects' page, a 'Community Projects' page, and statistics
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
            StartApplication();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Splash screen loads from here.
        /// </summary>
        private void StartApplication()
        {
            // Splash screen will load all 132 notes into memory
            (new frmSplash()).ShowDialog();
            Hide();
        }

        #endregion


    }
}

#endregion
