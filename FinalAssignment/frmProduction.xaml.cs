/*
 * Title: frmProduction.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: To provide the interaction logic for frmProduction.xaml
 * AI Used: AI was used to develop the CreateTimeline() method.
 *          More documentation can be found there (lines 82)
*/

#region Namespaces Used

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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

        // Piano
        private const int TotalPianoKeys = 132;
        private const int PianoKeyHeight = 20;
        private const int BlackKeyWidth = 80;
        private static SolidColorBrush PianoKeyBorderBrush = new SolidColorBrush(Color.FromRgb(187, 187, 187));
        private static Thickness PianoKeyThickness = new Thickness(1);

        // Timeline
        private static Thickness TimelineGridThickness = new Thickness(1);
        private static int TimelineGridWidth = 30; 
        private static SolidColorBrush TimelineGridBorderBrush = new SolidColorBrush(Color.FromArgb(128, 187, 187, 187));


        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets and sets the project which the user is producing.
        /// </summary>
        private Project BoundProject { get; set; }

        #endregion

        #region Constructor(s)

        public frmProduction()
        {
            BoundProject = new Project() { TimelineLength = 10000 };
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

        /// <summary>
        /// Matches piano roll vertical offset with timeline area on user scroll.
        /// </summary>
        /// <param name="sender">svrTimelineArea.</param>
        /// <param name="e">Event Args.</param>
        private void svrTimelineArea_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            svrPianoRoll.ScrollToVerticalOffset(svrTimelineArea.VerticalOffset);
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
                    CreateKey(currentKey);
                    CreateTimelineRow();
                }
            }

        }

        /// <summary>
        /// Styles and adds a key to pnlPianoRoll based on the char, 'W' for white, 'B' for black.
        /// </summary>
        /// <param name="currentKey">The char representing the key to style.</param>
        private void CreateKey(char currentKey)
        {
            // Create white key
            Border key = new Border()
            {
                Height = PianoKeyHeight,
                Background = Brushes.White,
                BorderBrush = PianoKeyBorderBrush,
                BorderThickness = PianoKeyThickness
            };

            // Add a black key to the white key before adding if pattern is on black
            if (currentKey == 'B')
            {
                key.Child = new Border()
                {
                    Height = PianoKeyHeight,
                    Width = BlackKeyWidth,
                    Background = Brushes.Black,
                    BorderBrush = PianoKeyBorderBrush,
                    BorderThickness = PianoKeyThickness,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
            }

            // Add the key
            pnlPianoRoll.Children.Add(key);
        }

        /// <summary>
        /// Creates a row to be added to the timeline area
        /// </summary>
        private void CreateTimelineRow()
        {
            // Timeline grid to be populated
            Grid timelineGrid = new Grid() { Height = PianoKeyHeight };

            // Add a column to the timeline row grid for each 1/4 beat in timeline, i.e 250 milliseconds
            for (int i = 0; i < BoundProject.TimelineLength / (int)Note.NoteSize.QuarterBeat; i++)
            {
                // Define a new column to represent this 1/4 beat
                timelineGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(TimelineGridWidth)
                });

                // Add a styled border to the column
                Border beat = new Border()
                {
                    BorderThickness = TimelineGridThickness,
                    BorderBrush = TimelineGridBorderBrush
                };
                timelineGrid.Children.Add(beat);

                // Set the beat's column and row to the last index
                Grid.SetColumn(beat, timelineGrid.ColumnDefinitions.Count - 1);
            }

            // Add the timeline grid
            pnlTimeline.Children.Add(timelineGrid);
        }

        #endregion
    }
}

#endregion