/*
 * Title: ProductPanelView
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: The purpose of this class is to define a more customizable alternative to list view.
 * 
 * Essentially just instantiates a list of type Product as Controls and adds them to itself.
 * Also keeps track of products added.
 */


#region Namespaces Used
using System.Windows.Forms;
using System.Collections.Generic;
using System;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public class ProductPanelView : Panel
    {
        #region Propeties
        public List<Product> ProductsAdded
        {
            get;
            set;
        }
        #endregion

        #region Constansts
        private const int ProductSpacingY = 40;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Constructor sets up self and child controls (each product panel).
        /// If true is passes as argument, products will be created to be removeable.
        /// </summary>
        public ProductPanelView()
        {
            ProductsAdded = new List<Product>();
            CreateAndAddControls();
        }
        #endregion

        #region Setup/styling methods
        /// <summary>
        /// Sets up each product panel's child elements, the child panel and the PanelView itself
        /// </summary>
        public void CreateAndAddControls()
        {
            int currentProductYSpacing = 0;

            foreach (Product product in Product.Products)
            {
                // Create new product panel and it's child controls
                Panel pnlProduct = new Panel();
                Label lblName = new Label();
                Label lblPrice = new Label();
                Button btnAddToOrder = new Button();
                NumericUpDown nudQuantity = new NumericUpDown();

                // Style the view panel itself
                Location = new System.Drawing.Point(6, 6);
                Name = "pnlProductPanelView";
                Size = new System.Drawing.Size(606, 297);
                TabIndex = 3;
                AutoScroll = true;
                VScroll = true;

                // Style product panel
                pnlProduct.BackColor = System.Drawing.Color.LightGray;
                pnlProduct.Location = new System.Drawing.Point(6, 6 + currentProductYSpacing);
                pnlProduct.Name = "pnlProduct";
                pnlProduct.Size = new System.Drawing.Size(565, 34);
                pnlProduct.TabIndex = 0;

                // Style product name
                lblName.AutoSize = true;
                lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblName.ForeColor = System.Drawing.Color.Black;
                lblName.Location = new System.Drawing.Point(63, 7);
                lblName.Name = "lblProductName";
                lblName.Size = new System.Drawing.Size(122, 20);
                lblName.TabIndex = 1;
                lblName.Text = product.Name;

                // Style product price
                lblPrice.AutoSize = true;
                lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblPrice.ForeColor = System.Drawing.Color.Green;
                lblPrice.Location = new System.Drawing.Point(3, 7);
                lblPrice.Name = "lblProductPrice";
                lblPrice.Size = new System.Drawing.Size(54, 20);
                lblPrice.TabIndex = 0;
                lblPrice.Text = "$" + product.Price.ToString();

                // Style product button
                btnAddToOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnAddToOrder.Location = new System.Drawing.Point(460, 6);
                btnAddToOrder.Location = new System.Drawing.Point(460, 6);
                btnAddToOrder.Name = "btnAddProduct";
                btnAddToOrder.Size = new System.Drawing.Size(100, 23);
                btnAddToOrder.TabIndex = 2;
                btnAddToOrder.UseVisualStyleBackColor = true;
                btnAddToOrder.ForeColor = System.Drawing.Color.Green;
                btnAddToOrder.Text = "Add To Order"; 
   

                // Style for quantity nud
                nudQuantity.Location = new System.Drawing.Point(420, 7);
                nudQuantity.Minimum = new decimal(new int[] {
                    1,
                    0,
                    0,
                    0});
                nudQuantity.Name = "nudQuantity";
                nudQuantity.Size = new System.Drawing.Size(31, 20);
                nudQuantity.TabIndex = 0;
                nudQuantity.Value = new decimal(new int[] {
                    1,
                    0,
                    0,
                    0});

                // Add children to product panel
                pnlProduct.Controls.Add(lblPrice);
                pnlProduct.Controls.Add(lblName);
                pnlProduct.Controls.Add(nudQuantity);
                pnlProduct.Controls.Add(btnAddToOrder);

                // Add product panel to this ProductPanelView
                Controls.Add(pnlProduct);

                // Incriment spacing so panels appear in rows.
                currentProductYSpacing += ProductSpacingY;

                // Ensure each product added is kept track of
                btnAddToOrder.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    for (int i = 0; i < nudQuantity.Value; i++)
                    {
                        ProductsAdded.Add(Product.FindByName(lblName.Text));
                    }
                });
                
            }
        }
        #endregion

        #region General Methods
        /// <summary>
        /// Creates a removeable panel list of this instances Product list.
        /// </summary>
        /// <returns></returns>
        public Panel CreateRemoveableList()
        {
            // Setup the panel
            Panel pnlRemoveableList = new Panel();
            pnlRemoveableList.Location = new System.Drawing.Point(0, 0);
            pnlRemoveableList.Name = "pnlProductOrder";
            pnlRemoveableList.Size = new System.Drawing.Size(590, 700);
            pnlRemoveableList.TabIndex = 0;
            
            // Setup each product
            int currentProductYSpacing = 0;

            foreach (Product product in ProductsAdded)
            {
                // Isntantiate each control
                Panel pnlProductOrder = new Panel();
                Label lblName = new Label();
                Label lblPrice = new Label();
                Button btnRemoveProduct = new Button();

                // For product panel
                pnlProductOrder.BackColor = System.Drawing.Color.LightGray;
                pnlProductOrder.Location = new System.Drawing.Point(0, currentProductYSpacing);
                pnlProductOrder.Size = new System.Drawing.Size(595, 34);
                pnlProductOrder.TabIndex = 0;

                // Add properties for product name
                lblName.AutoSize = true;
                lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblName.ForeColor = System.Drawing.Color.Black;
                lblName.Location = new System.Drawing.Point(61, 7);
                lblName.Size = new System.Drawing.Size(122, 20);
                lblName.TabIndex = 3;
                lblName.Text = product.Name;

                // For product price
                lblPrice.AutoSize = true;
                lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblPrice.ForeColor = System.Drawing.Color.Green;
                lblPrice.Location = new System.Drawing.Point(6, 7);
                lblPrice.Size = new System.Drawing.Size(54, 20);
                lblPrice.TabIndex = 3;
                lblPrice.Text = product.Price.ToString();

                // For remove button
                btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnRemoveProduct.ForeColor = System.Drawing.Color.Crimson;
                btnRemoveProduct.Location = new System.Drawing.Point(455, 6);
                btnRemoveProduct.Size = new System.Drawing.Size(131, 23);
                btnRemoveProduct.TabIndex = 3;
                btnRemoveProduct.Text = "Remove From Order";
                btnRemoveProduct.UseVisualStyleBackColor = true;

                // Add each control to product panel
                pnlProductOrder.Controls.Add(lblPrice);
                pnlProductOrder.Controls.Add(lblName);
                pnlProductOrder.Controls.Add(btnRemoveProduct);

                // Add product panel to main panel
                pnlRemoveableList.Controls.Add(pnlProductOrder);

                // Add to spacing
                currentProductYSpacing += ProductSpacingY;
            }

            // Finally return the panel
            return pnlRemoveableList;
        }

  
        #endregion
    }
    #endregion
}
#endregion
