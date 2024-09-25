/*
 * Title: HumanVsHumanPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-24
 * Purpose: This is the parent form where each control for the program will be placed.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public class HumanVsHumanPanel : GenericGamePanel
    {
        #region Properties
        private int[] ParentControlDimensions { get; set; }
        private Panel pnlGameSetup { get; set; }
        private TextBox txtPlayerOneNameInput { get; set; }
        private TextBox txtPlayerTwoNameInput { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Calls parent constructor, overrides Instantiate control methdod
        /// </summary>
        public HumanVsHumanPanel() : base()
        {
            InstantiateControls();
        }
        #endregion

        #region Setup Methods
        /// <summary>
        /// Instantiates and adds all child controls
        /// </summary>
        private void InstantiateControls()
        {
            // Instantiating Controlss
            pnlGameSetup = new Panel();
            txtPlayerOneNameInput = new TextBox();
            txtPlayerTwoNameInput = new TextBox();

            // Adding controls to their children
            pnlGameSetup.Controls.Add(txtPlayerOneNameInput);
            pnlGameSetup.Controls.Add(txtPlayerTwoNameInput);
            this.Controls.Add(pnlGameSetup);
        }

        /// <summary>
        /// Styles child controls. To be called after parent is defined. If no parent is defined, instantly returns
        /// </summary>
        public void StyleControls()
        {
            // Return if parent deosn't exist
            if (Parent == null) { return; }

            // Grab the dimensions of the parent control and centre for styling
            ParentControlDimensions = new int[] { Parent.Width, Parent.Height};
            int horizontalCentre = ParentControlDimensions[0] / 2;
            int verticalCentre = ParentControlDimensions[1] / 2;

            #region Panel Styling
            this.Width = Parent.Width;
            this.Height = Parent.Height;
            #endregion

            #region pnlGameSetup Styling
            pnlGameSetup.BackColor = Color.Red;
            pnlGameSetup.Width = horizontalCentre;
            pnlGameSetup.Height = Parent.Height - 10;
            pnlGameSetup.Location = new Point(horizontalCentre - pnlGameSetup.Width / 2, verticalCentre - pnlGameSetup.Height / 2);
            #endregion







        }

        #endregion



    }
    #endregion
}
#endregion
