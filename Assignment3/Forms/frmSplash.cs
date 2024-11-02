/*
 * Title: frmSplash.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-01
 * Purpose: To provide a simple splash screen for the d&d character creator.
 */

#region Namespace Definition

namespace Assignment3
{
    /// <summary>
    /// This class serves as the user's entrance point to the character creator; from here
    /// they can choose to enter the character creator or exit.
    /// </summary>
    public partial class frmSplash : Form
    {

        #region Constructors

        /// <summary>
        /// This class only contains one constructor, to be called when the application is initialized
        /// </summary>
        public frmSplash()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// To be called when character creator button is clicked. Just opens main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessCharacterCreator_Click(object sender, EventArgs e)
        {
            (new frmMain()).Show();
        }

        #region Visual Interaction

        /// <summary>
        /// To be called when mouse hover begins on character creator access button or exit button. Visually indicates hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneric_MouseEnter(object sender, EventArgs e)
        {
            IndicateHoverOnButton((Button)sender);
        }

        /// <summary>
        /// To be called when mouse hover ends on character creator access button or exit. Visually indicates end of hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneric_MouseLeave(object sender, EventArgs e)
        {
            IndicateHoverEndOnButton((Button)sender);
        }

        #endregion

        #endregion

        #region Dynamic Styling

        /// <summary>
        /// Expands and changes a button's font to red to indicate a mouse hover.
        /// </summary>
        /// <param name="btnToStyle">The button to style.</param>
        private void IndicateHoverOnButton(Button btnToStyle)
        {
            // Simply update the button size to indicate a hover and re adjust positioning
            btnToStyle.Size = new Size(btnToStyle.Width + 8, btnToStyle.Height + 8);
            btnToStyle.Location = new Point(btnToStyle.Location.X - 4, btnToStyle.Location.Y - 4);

            // Update font colour to red
            btnToStyle.ForeColor = Color.Red;
        }

        /// <summary>
        /// Shrinks and changes a button's font to black to indicate a mouse hover end.
        /// </summary>
        /// <param name="btnToStyle">The button to style.</param>
        private void IndicateHoverEndOnButton(Button btnToStyle)
        {
            // Simply update the button size to indicate a hover and re adjust positioning
            btnToStyle.Size = new Size(btnToStyle.Width - 8, btnToStyle.Height - 8);
            btnToStyle.Location = new Point(btnToStyle.Location.X + 4, btnToStyle.Location.Y + 4);

            // Update font colour to black
            btnToStyle.ForeColor = Color.Black;
        }

        #endregion
    }
}

#endregion