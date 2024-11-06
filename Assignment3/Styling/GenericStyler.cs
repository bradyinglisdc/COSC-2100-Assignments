/*
 * Title: GenericStyler.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-05
 * Purpose: To provide a static class with generic styling methods
 */


#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

#region Namespace Definition

namespace Assignment3
{
    /// <summary>
    /// A static class to provide styling methods for windows form controls
    /// </summary>
    public static class GenericStyler
    {
        #region Constants/Static Variables

        const int ButtonHoverSizeToChange = 8;
        const int ButtonHoverLocationToChange = ButtonHoverSizeToChange / 2;

        #endregion

        /// <summary>
        /// Expands and changes a button's font to red to indicate a mouse hover.
        /// </summary>
        /// <param name="btnToStyle">Reference to button to style.</param>
        public static void IndicateHoverOnButton(Button btnToStyle)
        {
            // Simply update the button size to indicate a hover and re adjust positioning
            btnToStyle.Size = new Size(btnToStyle.Width + ButtonHoverSizeToChange, btnToStyle.Height + ButtonHoverSizeToChange);
            btnToStyle.Location = new Point(btnToStyle.Location.X - ButtonHoverLocationToChange, btnToStyle.Location.Y - ButtonHoverLocationToChange);

            // Update font colour to red
            btnToStyle.ForeColor = Color.Red;
        }


        /// <summary>
        /// Shrinks and changes a button's font to black to indicate a mouse hover end.
        /// </summary>
        /// <param name="btnToStyle">The button to style.</param>
        public static void IndicateHoverEndOnButton(Button btnToStyle)
        {
            // Simply update the button size to indicate a hover and re adjust positioning
            btnToStyle.Size = new Size(btnToStyle.Width - ButtonHoverSizeToChange, btnToStyle.Height - ButtonHoverSizeToChange);
            btnToStyle.Location = new Point(btnToStyle.Location.X + ButtonHoverLocationToChange, btnToStyle.Location.Y + ButtonHoverLocationToChange);

            // Update font colour to black
            btnToStyle.ForeColor = Color.Black;
        }

    }
}

#endregion