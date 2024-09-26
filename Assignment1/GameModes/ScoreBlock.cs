/*
 * Title: ScoreBlock.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-26
 * Purpose: This panel simply contains a styled name and a score to be modified
*/

#region Namespaces Used
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
#endregion

#region Namespace Definition
namespace Assignment1
{ 
    #region ClassDefinition
    public class ScoreBlock : Panel
    {
        #region Properties
        public Label lblScoreHeader { get; set; }
        public Label lblScore { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Instantiates and adds all controls.
        /// </summary>
        public ScoreBlock()
        {
            InstantiateControls();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds controls.
        /// </summary>
        private void InstantiateControls()
        {
            // Instantiate controls
            lblScoreHeader = new Label();
            lblScore = new Label();

            // Add controls
            this.Controls.Add(lblScoreHeader);
            this.Controls.Add(lblScore);
        }

        /// <summary>
        /// Styles all controls.
        /// </summary>
        private void StyleControls()
        {
            // Return if no parent exists yet
            if (Parent == null) { return; }

            #region Panel Styling
            #endregion
        }

        #endregion

    }
    #endregion
}
#endregion
