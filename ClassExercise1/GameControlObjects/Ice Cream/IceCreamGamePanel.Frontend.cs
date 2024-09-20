/*
 * Title: IceCreamGamePanel (frontend)
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: This class defines all front-end logic for the ice cream game panel.
 * 
 * Inherits GenericGamePanel class in order to receive apropriate properties
 * and methods for styling and organization within AvailableGames.Games 
 * 
 * This portion of the partial class contains the fronted/UI for the game.
 * The backend/logic is contained within the second partial definition of this class IceCreamGamePanel.Backend.cs).
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
    #region Class Definition
    public partial class IceCreamGamePanel : GenericGamePanel
    {
        #region Properties
        private System.Windows.Forms.TabControl tctrlContentArea { get; set; }
        private System.Windows.Forms.TabPage tpgOrderTotal { get; set; }
        private System.Windows.Forms.TabPage tpgCartMenu { get; set; }
        private System.Windows.Forms.Label lblOrderTotalFooter { get; set; }
        private System.Windows.Forms.Label lblCartMenuFooter { get; set; }
        private System.Windows.Forms.Label lblCartEmptyIndiactor { get; set; }
        private ProductPanelView pnlProductView { get; set; }
        private System.Windows.Forms.ToolTip IceCreamHelperToolTips { get; set; }
        private System.ComponentModel.IContainer Components { get; set; }
        private System.Windows.Forms.Panel pnlOrderArea { get; set; }
        private System.Windows.Forms.Label lblOrderTotalHeader { get; set; }
        private System.Windows.Forms.Label lblAmountDue { get; set; }
        #endregion

        #region Styling/Setup methods
        /// <summary>
        /// Instantiates each child control.
        /// </summary>
        private void SetAllProperties()
        {
            // Game name
            GameName = "Icecream Helper";

            // Main controls
            Components = new System.ComponentModel.Container();
            tctrlContentArea = new TabControl();
            tpgOrderTotal = new TabPage();
            lblCartEmptyIndiactor = new Label();
            lblOrderTotalFooter = new Label();
            tpgCartMenu = new TabPage();
            lblCartMenuFooter = new Label();
            IceCreamHelperToolTips = new ToolTip(Components);
            pnlOrderArea = new Panel();
            lblOrderTotalHeader = new Label();
            lblAmountDue = new Label();

            // Product view area (ProductPanelView)
            pnlProductView = new ProductPanelView();
        }

        /// <summary>
        /// Adds apropriate properties and styling to each
        /// control. Adds each control to parent control (this instance of the panel).
        /// </summary>
        private void StyleAllControls()
        {
            // Ice cream panel styling
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            Controls.Add(tctrlContentArea);
            Location = new System.Drawing.Point(12, 12);
            Name = "pnlIceCream";
            Size = new System.Drawing.Size(658, 414);
            TabIndex = 3;
            
            // tctrlContentArea
            tctrlContentArea.Controls.Add(tpgOrderTotal);
            tctrlContentArea.Controls.Add(tpgCartMenu);
            tctrlContentArea.Location = new System.Drawing.Point(17, 27);
            tctrlContentArea.Name = "tctrlContentArea";
            tctrlContentArea.SelectedIndex = 0;
            tctrlContentArea.Size = new System.Drawing.Size(626, 372);
            tctrlContentArea.TabIndex = 0;

            // tpgOrderTotal
            tpgOrderTotal.Controls.Add(lblCartEmptyIndiactor);
            tpgOrderTotal.Controls.Add(pnlOrderArea);
            tpgOrderTotal.Controls.Add(lblOrderTotalFooter);
            tpgOrderTotal.Controls.Add(lblOrderTotalHeader);
            tpgOrderTotal.Location = new System.Drawing.Point(4, 22);
            tpgOrderTotal.Name = "tpgOrderTotal";
            tpgOrderTotal.Padding = new System.Windows.Forms.Padding(3);
            tpgOrderTotal.Size = new System.Drawing.Size(618, 346);
            tpgOrderTotal.TabIndex = 0;
            tpgOrderTotal.Text = "Order Total";
            tpgOrderTotal.UseVisualStyleBackColor = true;

            // lblCartEmptyIndiactor
            lblCartEmptyIndiactor.AutoSize = true;
            lblCartEmptyIndiactor.Location = new System.Drawing.Point(180, 141);
            lblCartEmptyIndiactor.Name = "lblCartEmptyIndiactor";
            lblCartEmptyIndiactor.Size = new System.Drawing.Size(259, 26);
            lblCartEmptyIndiactor.TabIndex = 2;
            lblCartEmptyIndiactor.Text = "Looks like your order is empty...\r\nHead over to the \'Cart Menu\' tab to create you" +
    "r order.";
            lblCartEmptyIndiactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            IceCreamHelperToolTips.SetToolTip(lblCartEmptyIndiactor, "Navigate to \'Cart Menu\' tab to add items to order.");

            // lblOrderTotalFooter
            lblOrderTotalFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lblOrderTotalFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            lblOrderTotalFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblOrderTotalFooter.ForeColor = System.Drawing.Color.White;
            lblOrderTotalFooter.Location = new System.Drawing.Point(-2, 306);
            lblOrderTotalFooter.Name = "lblOrderTotalFooter";
            lblOrderTotalFooter.Size = new System.Drawing.Size(622, 44);
            lblOrderTotalFooter.TabIndex = 1;
            lblOrderTotalFooter.Text = "Ice Cream Sales Helper - Order Total";

            // tpgCartMenu
            tpgCartMenu.Controls.Add(pnlProductView);
            tpgCartMenu.Controls.Add(lblCartMenuFooter);
            tpgCartMenu.Location = new System.Drawing.Point(4, 22);
            tpgCartMenu.Name = "tpgCartMenu";
            tpgCartMenu.Padding = new System.Windows.Forms.Padding(3);
            tpgCartMenu.Size = new System.Drawing.Size(618, 346);
            tpgCartMenu.TabIndex = 1;
            tpgCartMenu.Text = "Cart Menu";
            tpgCartMenu.UseVisualStyleBackColor = true;

            // lblCartMenuFooter
            lblCartMenuFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lblCartMenuFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            lblCartMenuFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCartMenuFooter.ForeColor = System.Drawing.Color.White;
            lblCartMenuFooter.Location = new System.Drawing.Point(-2, 306);
            lblCartMenuFooter.Name = "lblCartMenuFooter";
            lblCartMenuFooter.Size = new System.Drawing.Size(622, 44);
            lblCartMenuFooter.TabIndex = 2;
            lblCartMenuFooter.Text = "Ice Cream Sales Helper - Cart Menu";

            // Order area
            pnlOrderArea.Location = new System.Drawing.Point(0, 50);
            pnlOrderArea.Size = new System.Drawing.Size(615, 250);
            pnlOrderArea.TabIndex = 7;
            pnlOrderArea.AutoScroll = true;

            // Order total header
            lblOrderTotalHeader.Controls.Add(lblAmountDue);
            lblOrderTotalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            lblOrderTotalHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblOrderTotalHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblOrderTotalHeader.Location = new System.Drawing.Point(0, 3);
            lblOrderTotalHeader.Size = new System.Drawing.Size(622, 44);
            lblOrderTotalHeader.TabIndex = 5;
            lblOrderTotalHeader.Text = "Total Amount Due:";
            lblOrderTotalHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            

            // Amount due label
            lblAmountDue.AutoSize = true;
            lblAmountDue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            lblAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAmountDue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblAmountDue.Location = new System.Drawing.Point(186, 10);
            lblAmountDue.Name = "lblAmountDue";
            lblAmountDue.Size = new System.Drawing.Size(36, 25);
            lblAmountDue.TabIndex = 6;
            lblAmountDue.Text = "$0";
            lblOrderTotalHeader.BringToFront();
        }
        #endregion
    }
    #endregion
}
#endregion
