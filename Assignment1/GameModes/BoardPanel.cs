/*
 * Title: BoardPanel.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-25
 * Purpose: This panel contains the logic and styling for a tic tac toe
 * board game.
*/

#region Namespaces Used
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public class BoardPanel : Panel
    {
        #region Properties
        /// <summary>
        /// 2d array of each label where an X or an O might be placed.
        /// </summary>
        public Label[,] GameGrid
        {
            get;
            set;
        }
        public ToolTip ToolTips
        {
            get;
            set;
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Instantiates controls, adds them to list of controls, subscribes event handler methods.
        /// </summary>
        public BoardPanel()
        {
            SetupControls();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds controls to list of controls,
        /// subscribes method to their Click event. Also adds tab indexs to each.
        /// </summary>
        private void SetupControls()
        {
            // Instantiate list of grid positions and tool tips
            GameGrid = new Label[3,3];
            ToolTips = new ToolTip();

            // Itereate through board length and instantiate + keep track of label for each proposed grid position
            int tabIndex = 0;
            for (int i = 0; i < GameGrid.GetLength(0); i++)
            {
                for (int j = 0; j < GameGrid.GetLength(1); j++)
                {
                    Label gridPosition = new Label();
                    gridPosition.Click += new EventHandler(GridPosition_Click);
                    gridPosition.TabIndex = tabIndex++;
                    ToolTips.SetToolTip(gridPosition, "There is no X or O on this square yet. Click here to add one!");

                    GameGrid[i, j] = gridPosition;
                    this.Controls.Add(gridPosition);
                }
            }
        }

        /// <summary>
        /// Styles each grid position based on parent positioning.
        /// </summary>
        public void StyleControls()
        {
            // Just return if the parent does not exist.
            if (Parent == null) { return; }

            #region Panel
            this.Width = Parent.Width / 2;
            this.Height = Parent.Height / 2;
            this.MaximumSize = new Size(1100, 1100);
            this.BackColor = Color.FromArgb(0, 100, 0);
            #endregion

            #region Game Grid
            // Define size and margin for each label
            int margin = 5;
            int[] labelDimensions = new int[] { this.Width / 3, this.Height / 3 };

            // Apply styling to each label
            int xSpacing = 0;
            int ySpacing = 0;
            for (int i = 0; i < GameGrid.GetLength(0); i++)
            {
                xSpacing = 0;
                for (int j = 0; j < GameGrid.GetLength(1); j++)
                {
                    // Color, font and size
                    GameGrid[i,j].Font = new Font("Courier New", (this.Width + this .Height) / 15, FontStyle.Bold);
                    GameGrid[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    GameGrid[i, j].BackColor = Color.FromArgb(255, 255, 255);
                    GameGrid[i, j].ForeColor = Color.FromArgb(0, 100, 0);
                    GameGrid[i, j].Size = new Size(labelDimensions[0], labelDimensions[1]);

                    // Location
                    GameGrid[i, j].Location = new Point(margin + xSpacing, margin + ySpacing);
                    xSpacing += labelDimensions[0] + margin;
                }
                ySpacing += labelDimensions[1] + margin;
            }
            #endregion

            #region Panel Update
            // Update Panel size to accomadate margin and weird windows forms formatting
            this.Width += margin * 4 - 2;
            this.Height += margin * 4 - 2;

            // Update location, keep centre
            this.Location = new Point(Parent.Width / 2 - this.Width / 2 - 5, ((HumanVsHumanPanel)Parent).btnPlayAgain.Location.Y +
                ((HumanVsHumanPanel)Parent).btnPlayAgain.Height + margin);
            #endregion
        }

        #endregion

        #region Event Handler Methods
        /// <summary>
        /// Calls method to fill grid position with either X or O,
        /// provided that position does not already contain an X or O.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridPosition_Click(object sender, EventArgs e)
        {
            AddPlayerMark((Label)sender);
        }
        #endregion

        #region Game Logic Methods
        /// <summary>
        /// Adds either an X or an O to the grid position by ensuring the
        /// parent control exists and is a HumanVsHuman or a HumanVsAI;
        /// provided it does not already contain an X or an O.
        /// </summary>
        /// <param name="gridPosition"></param>
        private void AddPlayerMark(Label gridPosition)
        {
   
            // Just return if the parent does not exist or the label already contains a marker
            if (Parent == null || gridPosition.Text != "") { return; }

            // If the parent is a HumanVsHumanPanel/HumanVsAIPanel, cast it and grab the game state then change turns
            if (this.Parent is HumanVsHumanPanel) 
            {
                HumanVsHumanPanel parentPanel = (HumanVsHumanPanel)Parent;
                parentPanel.UpdateCurrentState(gridPosition);
            }
            /*else if (this.Parent is HumanVsAIPanel) { gameState = ((HumanVsAIPanel)this.Parent).BoundGameState; }*/

            // Return if it is not of the correct type
            else { return; }
        }
        #endregion

        #region Cleanup Methods
        /// <summary>
        /// To be called when an end state is found. Ubsubscribes all event handler methods
        /// and changes tool tips.
        /// </summary>
        public void DisableBoard()
        {
            foreach (Label label in GameGrid)
            {
                label.Click -= GridPosition_Click;
                ToolTips.SetToolTip(label, "Game is over!");
            }
        }
        #endregion
    }
    #endregion
}
#endregion
