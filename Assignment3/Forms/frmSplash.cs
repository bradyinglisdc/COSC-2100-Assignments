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
        /// To be called when character creator button is clicked. Just hides this form and opens main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessCharacterCreator_Click(object sender, EventArgs e)
        {
            (new frmMain()).Show();
            Hide();
        }

        /// <summary>
        /// To be called when exit button is clicked. Just exits application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Visual Interaction

        /// <summary>
        /// To be called when mouse hover begins on character creator access button or exit button. Visually indicates hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneric_MouseEnter(object sender, EventArgs e)
        {
            GenericStyler.IndicateHoverOnButton((Button)sender);
        }

        /// <summary>
        /// To be called when mouse hover ends on character creator access button or exit. Visually indicates end of hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneric_MouseLeave(object sender, EventArgs e)
        {
            GenericStyler.IndicateHoverEndOnButton((Button)sender);
        }

        #endregion

        #endregion

    }
}

#endregion