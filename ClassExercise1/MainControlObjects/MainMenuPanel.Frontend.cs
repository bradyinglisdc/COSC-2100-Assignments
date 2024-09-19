/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This class is a child of the Panel class. It's purpose is to modularize 
 * frmMain by defining a MainMenuPanel object, which contains controls and propeties
 * specific to the main menu of frmMain to be instantiated on the classes constructor call.
 * 
 * This portion of the partial class contains the front end/UI for the menu.
 * The backend/logic is contained within the second partial definition of this class (MainMenuPanel.Backend.cs).
 * 
 * To style this control, I used the [design] UI file to get everything right, and then pulled
 * the results of the styling from the frmMain.Designer.cs file.
 */

#region Namespaces Used
using System.Windows.Forms;
using System.Collections.Generic;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public partial class MainMenuPanel : Panel
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

        // Game selection buttons
        public Button btnStartGuessTheNumber
        {
            get; set;
        }
        public Button btnStartIceCream
        {
            get; set;
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

        private void StyleAllControls(int formHeight)
        {
            // Styling for the panel itself
            StyleMenu(formHeight);

            // Style for the menu's tab bar
            StyleTabBar();

            // Style for the tab bars header
            StyleMenuHeader();

            // Style for the tab bars minimize button
            StyleMinimizeButton();

            // Style for each game start button
            StyleGameStartButtons();
        }

        private void StyleMenu(int formHeight)
        {
            // Firstly, add each control property to this instance.
            Controls.Add(pnlTabBar);
            Controls.Add(btnStartGuessTheNumber);
            Controls.Add(btnStartIceCream);
            pnlTabBar.Controls.Add(lblMenuHeader);
            pnlTabBar.Controls.Add(btnMinimize);

            // Next, set this instances anchor, size, colour, name, positioning
            Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
|               System.Windows.Forms.AnchorStyles.Left)));
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            Location = new System.Drawing.Point(0, 0);
            Name = "pnlMainMenu";
            Size = new System.Drawing.Size(183, formHeight);
            TabIndex = 0;
        }

        private void StyleTabBar()
        {
            // Set the tab bars anchor, size, colour, name, positioning
            pnlTabBar.BackColor = System.Drawing.SystemColors.ControlLight;
            pnlTabBar.Location = new System.Drawing.Point(0, 0);
            pnlTabBar.Name = "pnlTabBar";
            pnlTabBar.Size = new System.Drawing.Size(183, 30);
            pnlTabBar.TabIndex = 2;
        }

        private void StyleMenuHeader()
        {
            // Set the menu header anchor, size, colour, name, positioning
            lblMenuHeader.AutoSize = true;
            lblMenuHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            lblMenuHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblMenuHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            lblMenuHeader.Location = new System.Drawing.Point(3, 5);
            lblMenuHeader.Name = "lblMenuHeader";
            lblMenuHeader.Size = new System.Drawing.Size(95, 18);
            lblMenuHeader.TabIndex = 1;
            lblMenuHeader.Text = "Game Picker";
        }

        private void StyleMinimizeButton()
        {
            // Set the minimize button's propeties
            btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnMinimize.Location = new System.Drawing.Point(151, 6);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new System.Drawing.Size(29, 16);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "-";
            btnMinimize.UseVisualStyleBackColor = false;
        }

        private void StyleGameStartButtons()
        {
            // Style start guess the number button
            btnStartGuessTheNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            btnStartGuessTheNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnStartGuessTheNumber.Location = new System.Drawing.Point(0, 36);
            btnStartGuessTheNumber.Name = "btnStartGuessTheNumber";
            btnStartGuessTheNumber.Size = new System.Drawing.Size(183, 34);
            btnStartGuessTheNumber.TabIndex = 3;
            btnStartGuessTheNumber.Text = "Guess The Number";
            btnStartGuessTheNumber.UseVisualStyleBackColor = false;
     
            // Style start ice cream button
            btnStartIceCream.BackColor = System.Drawing.SystemColors.ControlLightLight;
            btnStartIceCream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnStartIceCream.Location = new System.Drawing.Point(0, 76);
            btnStartIceCream.Name = "btnStartIceCream";
            btnStartIceCream.Size = new System.Drawing.Size(183, 34);
            btnStartIceCream.TabIndex = 4;
            btnStartIceCream.Text = "Ice Cream";
            btnStartIceCream.UseVisualStyleBackColor = false;
        }
        #endregion
    }
    #endregion
}
#endregion
