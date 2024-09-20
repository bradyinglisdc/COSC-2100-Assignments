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
using System.Linq;
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

        #region Properties
        public bool Minimized
        {
            get;
            set;
        }
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

            // On any game start button click, start the apropriate game
            foreach (Button gameStartButton in GameStartButtons)
            {
                // Add the evnet handler, getting the game by the button text
                gameStartButton.Click += new EventHandler(btnGameStart_Click);
            }
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

        /// <summary>
        /// Called on any game button clicked.
        /// Simply grabs the game name to switch to and switches to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnGameStart_Click(object sender, EventArgs e)
        {
            // Cast the sender object to a control to access the text of the button which was clicked
            Control btnGameClicked = (Control)sender;
            ChangeGame(btnGameClicked.Text);
        }
        #endregion

        #region Control Functionality Methods
        public void MinimizePanel()
        {
            if (Minimized) { return; }

            // Shrink the panel so that only the tab bar is showing
            Size = new System.Drawing.Size(MinimizedWidth, pnlTabBar.Size.Height);

            // Set anchor to top left to prevent resizing with parent form
            Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Move minimize button to left so it is visible, change text to + to indicate it's now maximize btn
            btnMinimize.Location = new System.Drawing.Point(MinimizedMininimzeButtonX, btnMinimize.Location.Y);
            btnMinimize.Text = "+";

            // Remove current Click event handler from minimize btn
            btnMinimize.Click -= btnMinimize_Click;

            // Add maximize menu event handler and bring to front. Set minimized to true.
            btnMinimize.Click += new EventHandler(btnMaximize_Click);
            BringToFront();
            Minimized = true;
        }

        public void MaximizePanel()
        {
            if(!Minimized) { return; }

            // Grab reference to parent form
            frmMain parent = (frmMain)Parent;

            // Return instantly if parent is null
            /*if (parent == null) { return; }*/
 
            // Remove this menu and set parent forms menu to a new instance of the main menu, essentially refreshing it
            if (parent.Controls.Contains(this)) { parent.Controls.Remove(this); }
            
            // Ensure main menu is brough to front before adding it. Set minimized to false.
            parent.pnlMainMenu = new MainMenuPanel(parent.Height);
            parent.pnlMainMenu.BringToFront(); 
            Minimized = false;
        }

        /// <summary>
        /// Switches current game to whatever was selected (gameName string)
        /// if it exists.
        /// </summary>
        /// <param name="game">The game name to switch to.</param>
        public void ChangeGame(string gameName)
        {
            // Ensure game name exist. Display error and return otherwise.
            if (!AvailableGames.ContainsGameByName(gameName)) 
            {
                DisplayError($"Attempted to access game that does not exist. ({gameName})\nPlease see 'AvailableGames'" +
                    "class for list of all games.");
                return;
            }

            // Ensure parent (mainFrm) exists
            if (Parent == null)
            {
                DisplayError("Main menu has no form to display the game on.");
            }

            // If all is valid, switch games (cast parent control to frmMain first)
            frmMain parent = (frmMain)Parent;
            parent.ChangeGame(gameName);
        }
        #endregion

    }
    #endregion
}
#endregion