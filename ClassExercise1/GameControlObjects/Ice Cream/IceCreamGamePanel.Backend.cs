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
using Microsoft.VisualBasic;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class definition
    public partial class IceCreamGamePanel
    {
        #region Constansts
        private const double CashBoxDailyStartAmount = 100.0;
        #endregion

        #region Propeties
        public double CashBoxTotal
        {
            get;
            set;
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Sets up front and back end logic for this panel.
        /// </summary>
        public IceCreamGamePanel()
        {
            // Set cash box total
            CashBoxTotal = CashBoxDailyStartAmount;

            // Insantiate products
            ProductDriver.InstantiateAllProducts();

            // Instantiate all controls on constructor call
            SetAllProperties();

            // Style each control
            StyleAllControls();

            // Subscribe event handler methods
            SubscribeEventHandlers();

            RefreshOrders();
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

            // Order managment button event listeners
            btnCancelOrder.Click += new EventHandler((object sender, EventArgs e) =>
            {
                // Simply remove every product panel and refresh
                pnlProductView.ProductsAdded.Clear();
                RefreshOrders();
            });

            btnPayCard.Click += new EventHandler((object sender, EventArgs e) =>
            {
                // Add money to cash box, erase order and inform user.
                CashBoxTotal += pnlProductView.GetTotal();
                pnlProductView.ProductsAdded.Clear();
                RefreshOrders();
                MessageBox.Show($"Order complete. New cash box balance: {CashBoxTotal}");
            });

            btnPayCash.Click += new EventHandler((object sender, EventArgs e) =>
            {
                // Add money to cash box, erase order and inform user.
                CashBoxTotal += pnlProductView.GetTotal();
                pnlProductView.ProductsAdded.Clear();
                RefreshOrders();
                MessageBox.Show($"Order complete. New cash box balance: {CashBoxTotal}");
            });
        }
        #endregion

        #region Main Logic Methods
        /// <summary>
        /// Either displays message telling user they ahve no orders, 
        /// or displays orders with updated total.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateOrderView(object sender, EventArgs e)
        {
            // Refresh Orders
            RefreshOrders();
        }
        /// <summary>
        /// Removes and re adds orders to OrderArea.
        /// Resets total as well.
        /// </summary>
        public void RefreshOrders()
        {
            pnlOrderArea.Controls.Clear();
            pnlOrderArea.Controls.Add(pnlProductView.CreateRemoveableList());
            lblAmountDue.Text = $"${pnlProductView.GetTotal()}";

            // If user has no products in order, make label visible informing user
            if (pnlProductView.ProductsAdded.Count == 0)
            {
                HideControls();
                lblCartEmptyIndiactor.Visible = true;
                lblCartEmptyIndiactor.BringToFront();
            }

            // Otherwise hide message and make controls visible
            else
            {
                ShowControls();
                lblCartEmptyIndiactor.Visible = false;
            }
        }

        /// <summary>
        /// Shows controls for managing orders.
        /// </summary>
        public void ShowControls()
        {
            btnCancelOrder.Visible = true;
            btnPayCash.Visible = true;
            btnPayCard.Visible = true;

            btnCancelOrder.Enabled = true;
            btnPayCash.Enabled = true;
            btnPayCard.Enabled = true;
        }

        /// <summary>
        /// Hides controls for managing orders.
        /// </summary>
        public void HideControls()
        {
            btnCancelOrder.Visible = false;
            btnPayCash.Visible = false;
            btnPayCard.Visible = false;

            btnCancelOrder.Enabled = false;
            btnPayCash.Enabled = false;
            btnPayCard.Enabled = false;
        }



        #endregion
    }
    #endregion
}
#endregion
