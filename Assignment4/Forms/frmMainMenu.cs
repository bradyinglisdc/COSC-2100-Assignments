/*
 * Title: frmMainMenu.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-12
 * Purpose: To provide an interface for Minecraft profile settings
 */

#region Namespace Definition

namespace Assignment4
{
    public partial class frmMainMenu : Form
    {

        #region Constructors

        public frmMainMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler Methods

        /// <summary>
        /// Simply instantiates a new frmEditProfile form with the startup profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditDefaultProfile_Click(object sender, EventArgs e)
        {
            EditDefaultProfile();
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Instantiates a new frmEditProfile form using the startup profile as the profile to edit
        /// </summary>
        private void EditDefaultProfile()
        {
            Profile? startupProfile = Profile.GetStartupProfile();
            if (startupProfile != null) { (new frmEditProfile()).Show(); }
            else
            {
                MessageBox.Show("No startup profile is currently set... Select View/Create Profiles to set one.");
            }
        }

        #endregion

    }
}

#endregion
