/*
 * Title: Beat.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-12
 * Purpose: A child of the border class. Includes the addition of a bool IsClicked property
 *          for the purpose of identifying beat locations in the producer application, as well as 
 *          resizing capabilities.
 * AI Used: AI was used to quickly generate class with an added IsClicked proprty. This class quickly
 *          became essential for program functionality, as it connects a beat/note position on
 *          the front end timeline to the backend timeline.
*/

#region Namespaces Used

using System.Windows.Controls;
using System.Windows.Media;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// This class is a child of Border, and contains the addition of an IsClicked property
    /// for the purpose of identifying areas where a bear exists in frmProduction's timeline.
    /// AI Used: Yes
    ///          AI generated the IsClicked property and initial set up of this class.
    ///          I prompted it to simply create a Border derived class with the addition of 
    ///          an IsClicked property.
    /// </summary>
    internal class Beat : Border
    {
        #region Constants/Static Variables

        private static SolidColorBrush UnclickedBackground = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private static SolidColorBrush ClickedBackground = new SolidColorBrush(Color.FromArgb(160,255,255,255));

        #endregion
        #region Instance Properties

        /// <summary>
        /// Gets and private sets IsClicked property.
        /// </summary>
        public bool IsClicked { get; private set; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default constructor calls base() to initialize the border, then subscribes to MouseLeftButtonDown event.
        /// </summary>
        public Beat() : base()
        {
            MouseLeftButtonDown += Beat_MouseLeftButtonDown;
            Background = UnclickedBackground;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Calls ChangeBackground()
        /// </summary>
        /// <param name="sender">Beat.</param>
        /// <param name="e">Event Args.</param>
        private void Beat_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NegateCurrentState();
        }

        #endregion

        #region Logic

        /// <summary>
        /// Negates IsClicked.
        /// </summary>
        public void NegateCurrentState()
        {
            IsClicked = !IsClicked;
            if (IsClicked)
            {
                Background = ClickedBackground;
                return;
            }
            Background = UnclickedBackground;
        }

        #endregion
    }
}

#endregion