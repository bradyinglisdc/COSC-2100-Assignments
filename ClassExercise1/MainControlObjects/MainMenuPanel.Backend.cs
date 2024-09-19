/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This class is a child of the Panel class. It's purpose is to modularize 
 * frmMain by defining the logic for a MainMenuPanel object, which contains controls and propeties
 * specific to the main menu of frmMain to be instantiated on the classes constructor call.
 * 
 * This portion of the partial class contains the backend/logic for the menu.
 * The frontend/UI is contained within the first partial definition of this class (MainMenuPanel.Frontend.cs).
 */

#region Namespaces Used
using System;
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public partial class MainMenuPanel
    {
        #region Constants
        private const int MinimizedWidth = 140;
        private const int MinimizedMininimzeButtonX = 105;
        #endregion

        #region Constructor(s)
        public MainMenuPanel(int formHeight)
        {
            // On constructor call, instantiate all controls for this instance
            SetAllProperties();

            // Style each control
            // Passes the form width in so menu's width matches
            StyleAllControls(formHeight);

            // Subscribe event handler methods
            SubscribeEventHandlers();
        }
        #endregion

        #region Eventhandler Subscriptions and Definitions
        public void SubscribeEventHandlers()
        {
            // On btnMinimize click, call the appropriate method to minimize menu
            btnMinimize.Click += new EventHandler(btnMinimize_Click);
        }

        public void btnMinimize_Click(object sender, EventArgs e)
        {
            // Call method to shrink the panel
            MinimizePanel();

        }

        public void btnMaximize_Click(object sender, EventArgs e)
        {
            // Call method to maximize main menu panel
            MaximizePanel();
        }
        #endregion

        #region Control Methods
        public void MinimizePanel()
        {
            // Shrink the panel so that only the tab bar is showing
            Size = new System.Drawing.Size(MinimizedWidth, pnlTabBar.Size.Height);

            // Set anchor to top left to prevent resizing with parent form
            Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Move minimize button to left so it is visible, change text to + to indicate it's now maximize btn
            btnMinimize.Location = new System.Drawing.Point(MinimizedMininimzeButtonX, btnMinimize.Location.Y);
            btnMinimize.Text = "+";

            // Remove current Click event handler from minimize btn
            btnMinimize.Click -= btnMinimize_Click;

            // Add maximize menu event handler
            btnMinimize.Click += new EventHandler(btnMaximize_Click);
        }

        public void MaximizePanel()
        {
            // Grab reference to parent form
            Control parent = Parent;

            // Removes this menu from parent form, and then creates a new instance of the main menu
            parent.Controls.Remove(this);
            parent.Controls.Add(new MainMenuPanel(parent.Height));
        }

        #endregion

    }
    #endregion
}
#endregion