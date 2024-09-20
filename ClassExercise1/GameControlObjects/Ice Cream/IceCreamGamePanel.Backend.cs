/*
 * Title: IceCreamGamePanel (backend)
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: This class defines all back-end logic for the ice cream game panel.
 * 
 * Inherits GenericGamePanel class in order to receive apropriate properties
 * and methods for styling and organization within AvailableGames.Games 
 * 
 * This portion of the partial class contains the backend/logic for the game.
 * The Fronted/UI is contained within the first partial definition of this class IceCreamGamePanel.Frontend.cs).
 */

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class definition
    public partial class IceCreamGamePanel
    {
        #region Constructor(s)
        /// <summary>
        /// Sets up front and back end logic for this panel.
        /// </summary>
        public IceCreamGamePanel()
        {
            // Insantiate products
            ProductDriver.InstantiateAllProducts();

            // Instantiate all controls on constructor call
            SetAllProperties();

            // Style each control
            StyleAllControls();

            // Subscribe event handler methods
            SubscribeEventHandlers();
        }
        #endregion

        #region Event Handlers 
        /// <summary>
        /// Any event handler methods subscribed here.
        /// </summary>
        private void SubscribeEventHandlers()
        {
            // Refresh page to display products (if they exist) on tab change.
            tctrlContentArea.SelectedIndexChanged += new EventHandler(UpdateOrderView);
        }
        #endregion

        #region Main Logic Methods
        private void UpdateOrderView(object sender, EventArgs e)
        {
            // If no products were added, make label visible informing user
            if (pnlProductView.ProductsAdded.Count == 0)
            {
                lblCartEmptyIndiactor.Visible = true;
                lblCartEmptyIndiactor.BringToFront();
            }

            // Otherwise show products and update total
            else
            {
                lblCartEmptyIndiactor.Visible = false;
                pnlOrderArea.Controls.Clear();
                pnlOrderArea.Controls.Add(pnlProductView.CreateRemoveableList());
            }
        }



        #endregion
    }
    #endregion
}
#endregion
