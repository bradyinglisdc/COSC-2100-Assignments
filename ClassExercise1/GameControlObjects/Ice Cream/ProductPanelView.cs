/*
 * Title: ProductPanelView
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: The purpose of this class is to define a more customizable alternative to list view.
 * 
 * Essentially just instantiates a list of type Product as Controls and adds them to itself.
 */


#region Namespaces Used
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public class ProductPanelView : Panel
    {
        #region Constructor(s)
        /// <summary>
        /// Constructor sets up self and child controls (each product panel)
        /// </summary>
        public ProductPanelView()
        {
            CreateAndAddControls();
        }
        #endregion

        #region Setup/styling methods
        /// <summary>
        /// Sets up each product panel's child elements, the child panel and the PanelView itself
        /// </summary>
        public void CreateAndAddControls()
        {
            foreach (Product product in Product.Products)
            {
                // Create new product panel and it's child controls
                Panel pnlProduct = new Panel();
                Label lblName = new Label();
                Label lblPrice = new Label();
                Button btnAddToOrder = new Button();

                // Style product panel
                pnlProduct.BackColor = System.Drawing.Color.LightGray;

                pnlProduct.Location = new System.Drawing.Point(6, 6);
                pnlProduct.Name = "pnlProduct";
                pnlProduct.Size = new System.Drawing.Size(606, 34);
                pnlProduct.TabIndex = 0;

                // Style product name
                lblName.AutoSize = true;
                lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblName.ForeColor = System.Drawing.Color.Black;
                lblName.Location = new System.Drawing.Point(63, 7);
                lblName.Name = "lblProductName";
                lblName.Size = new System.Drawing.Size(122, 20);
                lblName.TabIndex = 1;
                lblName.Text = "Product Name";

                // Style product price
                lblPrice.AutoSize = true;
                lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblPrice.ForeColor = System.Drawing.Color.Green;
                lblPrice.Location = new System.Drawing.Point(3, 7);
                lblPrice.Name = "lblProductPrice";
                lblPrice.Size = new System.Drawing.Size(54, 20);
                lblPrice.TabIndex = 0;
                lblPrice.Text = "$9.99";

                // Add children to product panel
                pnlProduct.Controls.Add(lblPrice);
                pnlProduct.Controls.Add(lblName);
                pnlProduct.Controls.Add(lblName);

                // Finally, add product panel to this ProductPanelView
            }

        }
        #endregion
    }
    #endregion
}
#endregion
