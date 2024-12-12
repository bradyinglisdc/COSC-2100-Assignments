/*
 * Title: frmProduction.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: To provide the interaction logic for frmProduction.xaml
 * AI Used: AI was used to develop the CreateTimeline() method.
 *          More documentation can be found there (lines 82)
*/

#region Namespaces Used

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalAssignment.Models;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmProduction : Window
    {
        #region Styling Constants

        private const int TotalPianoKeys = 132;
        private const int PianoKeyHeight = 20;
        private const int BlackKeyWidth = 80;
        private static SolidColorBrush WhiteKeyBorderBrush = new SolidColorBrush(Color.FromRgb(187, 187, 187));


        #endregion

        #region Constructor(s)

        public frmProduction()
        {
            InitializeComponent();
            Note.FillParents();
            CreateTimeline();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Allows for drag move of window when left mouse is down on grdToolbar
        /// </summary>
        /// <param name="sender">grdToolbar.</param>
        /// <param name="e">Event Args.</param>
        private void grdToolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        /// <summary>
        /// Closes this production environment.
        /// </summary>
        /// <param name="sender">btnExit.</param>
        /// <param name="e">Event Args.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Changes WindowState to minimized
        /// </summary>
        /// <param name="sender">btnMinimize.</param>
        /// <param name="e">Event Args.</param>
        private void btnMinmimize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        #region Setup

        /// <summary>
        /// Creates the piano roll and timeline area.
        /// AI Used: Yes
        /// Prompt: "I am modeling a piano in C# .net. Here is what I need from you:
        ///          there will be const int TotalPianoKeys to create. A white key
        ///          should not have it's width changed, and should get PianoKeyHeight
        ///          for it's height.
        ///          
        ///          A black key should get width BlackKeyWidth, and height should be
        ///          the same as white, PianoKeyHeight. A black key should be placed on
        ///          top of a white key as a child.
        ///           
        ///          The pattern is: white, black, white, black, white, black, white, white,
        ///                          black, white, black, white, then repeat. Each of these
        ///                          represent one key, and there must be TotalPianoKeys keys.
        ///          
        ///          They will be added to the children of 'pnlPianoRoll'.
        ///          "
        /// Changes Made: Gen AI had an extremely hard time comprehending the task, so I had
        ///               to change essentially everything except for the pattern char system.
        /// </summary>
        private void CreateTimeline()
        {
            char[] pianoPattern = { 'W', 'B', 'W', 'B', 'W', 'B', 'W', 'W', 'B', 'W', 'B', 'W' };
            for (int i = 0; i < TotalPianoKeys / pianoPattern.Length; i++)
            {
                foreach (char currentKey in pianoPattern)
                {
                    if (currentKey == 'W')
                    {
                        Border key = new Border()
                        {
                            Height = PianoKeyHeight,
                            Background = Brushes.White,
                            BorderBrush = WhiteKeyBorderBrush,
                            BorderThickness = new
                        };
                    }
                }
            }
        }

        #endregion

    }
}

#endregion