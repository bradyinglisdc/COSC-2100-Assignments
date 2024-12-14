/*
 * Title: ProjectContainerStyling.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-13
 * Purpose: Contains static styling members for pgCommunityProjects and pgMyProjects.
 *  
 * AI Use and Documentation: No AI used for this class.
*/

#region Namespaces Used

using System.Windows.Media;
using System.Windows;
using FinalAssignment.Models;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Provides styling methods and variables for pgCommunityProjects and pgMyProjects.
    /// </summary>
    public static class ProjectContainerStyling
    {
        #region Delagates

        public delegate void EditRequestedHandler(Project projectToEdit);

        #endregion

        #region Constants

        public static Brush DEFAULT_BORDER_CONTAINER_BACKGROUND = new SolidColorBrush(Color.FromArgb(100, 170, 187, 187));
        public static Brush HOVER_BORDER_CONTAINER_BACKGROUND = new SolidColorBrush(Color.FromArgb(180, 170, 187, 187));
        public static Brush SELECT_BORDER_CONTAINER_BACKGROUND = new SolidColorBrush(Color.FromArgb(200, 170, 187, 187));
        public const int DEFAULT_BORDER_CONTAINER_WIDTH = 385;
        public const int DEFAULT_BORDER_CONTAINER_HEIGHT = 50;
        public const int DEFAULT_BORDER_CONTAINER_FONT_SIZE = 14;
        public static Thickness DEFAULT_BORDER_CONTAINER_MARGIN = new Thickness(0, 10, 0, 0);
        public static CornerRadius DEFAULT_BORDER_CONTAINER_CORNER_RADIUS = new CornerRadius(15);

        #endregion

        #region Methods



        #endregion

    }
}

#endregion
