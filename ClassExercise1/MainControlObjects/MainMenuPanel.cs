/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This class is a child of the Panel class. It's purpose is to modularize 
 * frmMain by defining a MainMenuPanel object, which contains controls and propeties
 * specific to the main menu of frmMain to be instantiated on the classes constructor call.
 */

#region Namespaces Used
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1.MainControlObjects
{
    #region Class Definition
    internal class MainMenuPanel : Panel
    {
        #region Properties
        // Tab bar
        public Panel pnlTabBar
        {
            get; set;
        }
        public Label lblMenuHeader
        {
            get; set;
        }
        public Button btnMinimize
        {
            get; set;
        }

        // Game selection button
        public Button btnStartGuessTheNumber
        {
            get; set;
        }
        public Button btnStartIceCream
        {
            get; set;
        }
        #endregion

        #region Constructor(s)
        public MainMenuPanel()
        {
            // On constructor call, instantiate all controls for this instance
            SetAllProperties();

            // Style each control
            StyleAllControls();
        }
        #endregion

        #region Control Setup/Styling Methods
        private void SetAllProperties()
        {
            // Simply instantiates each property
            pnlTabBar = new Panel();
            lblMenuHeader = new Label();
            btnMinimize = new Button();
            btnStartGuessTheNumber = new Button();
            btnStartIceCream = new Button();
        }

        private void StyleAllControls()
        {
            // Styling for the panel itself
            StyleMenu();

            // Style for the menu's tab bar
            StyleTabBar();

            // Style for the minimize button
            StyleMinimizeButton();

            // Style for each game start button
            StyleGameStartButtons();
        }

        private void StyleMenu()
        {
            // Firstly, add each control property to this instance.
            // Minimize button and menu header are not added here, 
            // as they will be properties of the TabBar control.
            Controls.Add(this.btnStartIceCream);
            Controls.Add(this.btnStartGuessTheNumber);
            Controls.Add(this.pnlTabBar);

            // Next, set this instances anchor, size, colour, name, positioning
            Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
|               System.Windows.Forms.AnchorStyles.Left)));
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            Location = new System.Drawing.Point(0, 0);
            Name = "pnlMainMenu";
            Size = new System.Drawing.Size(183, 450);
            TabIndex = 0;
        }

        private void StyleTabBar()
        {
            // Add this controls properties (contians the header for the menu and minimize btn)
            //pnlTabBar.Controls.Add();
        }

       
        #endregion





    }
    #endregion
}
#endregion
