namespace ClassExercise1
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnExitProgram = new System.Windows.Forms.Button();
            this.pnlIceCream = new System.Windows.Forms.Panel();
            this.tctrlContentArea = new System.Windows.Forms.TabControl();
            this.tpgOrderTotal = new System.Windows.Forms.TabPage();
            this.lblCartEmptyIndiactor = new System.Windows.Forms.Label();
            this.lblOrderTotalFooter = new System.Windows.Forms.Label();
            this.tpgCartMenu = new System.Windows.Forms.TabPage();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.pnlProductPanelView = new System.Windows.Forms.Panel();
            this.lblCartMenuFooter = new System.Windows.Forms.Label();
            this.lblGameOpenPrompt = new System.Windows.Forms.Label();
            this.IceCreamHelperToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.lblOrderTotalHeader = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.pnlOrderList = new System.Windows.Forms.Panel();
            this.pnlIceCream.SuspendLayout();
            this.tctrlContentArea.SuspendLayout();
            this.tpgOrderTotal.SuspendLayout();
            this.tpgCartMenu.SuspendLayout();
            this.pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExitProgram
            // 
            this.btnExitProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitProgram.Location = new System.Drawing.Point(558, 432);
            this.btnExitProgram.Name = "btnExitProgram";
            this.btnExitProgram.Size = new System.Drawing.Size(112, 23);
            this.btnExitProgram.TabIndex = 2;
            this.btnExitProgram.Text = "E&xit My Games";
            this.btnExitProgram.UseVisualStyleBackColor = true;
            this.btnExitProgram.Click += new System.EventHandler(this.btnExitProgram_Click);
            // 
            // pnlIceCream
            // 
            this.pnlIceCream.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlIceCream.Controls.Add(this.tctrlContentArea);
            this.pnlIceCream.Location = new System.Drawing.Point(12, 12);
            this.pnlIceCream.Name = "pnlIceCream";
            this.pnlIceCream.Size = new System.Drawing.Size(658, 414);
            this.pnlIceCream.TabIndex = 3;
            // 
            // tctrlContentArea
            // 
            this.tctrlContentArea.Controls.Add(this.tpgOrderTotal);
            this.tctrlContentArea.Controls.Add(this.tpgCartMenu);
            this.tctrlContentArea.Location = new System.Drawing.Point(17, 27);
            this.tctrlContentArea.Name = "tctrlContentArea";
            this.tctrlContentArea.SelectedIndex = 0;
            this.tctrlContentArea.Size = new System.Drawing.Size(626, 372);
            this.tctrlContentArea.TabIndex = 0;
            // 
            // tpgOrderTotal
            // 
            this.tpgOrderTotal.Controls.Add(this.lblAmountDue);
            this.tpgOrderTotal.Controls.Add(this.lblOrderTotalHeader);
            this.tpgOrderTotal.Controls.Add(this.btnCard);
            this.tpgOrderTotal.Controls.Add(this.btnCash);
            this.tpgOrderTotal.Controls.Add(this.lblCartEmptyIndiactor);
            this.tpgOrderTotal.Controls.Add(this.lblOrderTotalFooter);
            this.tpgOrderTotal.Controls.Add(this.pnlOrderList);
            this.tpgOrderTotal.Location = new System.Drawing.Point(4, 22);
            this.tpgOrderTotal.Name = "tpgOrderTotal";
            this.tpgOrderTotal.Padding = new System.Windows.Forms.Padding(3);
            this.tpgOrderTotal.Size = new System.Drawing.Size(618, 346);
            this.tpgOrderTotal.TabIndex = 0;
            this.tpgOrderTotal.Text = "Order Total";
            this.tpgOrderTotal.UseVisualStyleBackColor = true;
            // 
            // lblCartEmptyIndiactor
            // 
            this.lblCartEmptyIndiactor.AutoSize = true;
            this.lblCartEmptyIndiactor.Location = new System.Drawing.Point(180, 141);
            this.lblCartEmptyIndiactor.Name = "lblCartEmptyIndiactor";
            this.lblCartEmptyIndiactor.Size = new System.Drawing.Size(259, 26);
            this.lblCartEmptyIndiactor.TabIndex = 2;
            this.lblCartEmptyIndiactor.Text = "Looks like your order is empty...\r\nHead over to the \'Cart Menu\' tab to create you" +
    "r order.";
            this.lblCartEmptyIndiactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IceCreamHelperToolTips.SetToolTip(this.lblCartEmptyIndiactor, "Navigate to \'Cart Menu\' tab to add items to order.");
            // 
            // lblOrderTotalFooter
            // 
            this.lblOrderTotalFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderTotalFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.lblOrderTotalFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotalFooter.ForeColor = System.Drawing.Color.White;
            this.lblOrderTotalFooter.Location = new System.Drawing.Point(-2, 306);
            this.lblOrderTotalFooter.Name = "lblOrderTotalFooter";
            this.lblOrderTotalFooter.Size = new System.Drawing.Size(622, 44);
            this.lblOrderTotalFooter.TabIndex = 1;
            this.lblOrderTotalFooter.Text = "Ice Cream Sales Helper - Order Total";
            // 
            // tpgCartMenu
            // 
            this.tpgCartMenu.Controls.Add(this.pnlProduct);
            this.tpgCartMenu.Controls.Add(this.pnlProductPanelView);
            this.tpgCartMenu.Controls.Add(this.lblCartMenuFooter);
            this.tpgCartMenu.Location = new System.Drawing.Point(4, 22);
            this.tpgCartMenu.Name = "tpgCartMenu";
            this.tpgCartMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCartMenu.Size = new System.Drawing.Size(618, 346);
            this.tpgCartMenu.TabIndex = 1;
            this.tpgCartMenu.Text = "Cart Menu";
            this.tpgCartMenu.UseVisualStyleBackColor = true;
            // 
            // pnlProduct
            // 
            this.pnlProduct.BackColor = System.Drawing.Color.LightGray;
            this.pnlProduct.Controls.Add(this.nudQuantity);
            this.pnlProduct.Controls.Add(this.btnAddProduct);
            this.pnlProduct.Controls.Add(this.lblProductName);
            this.pnlProduct.Controls.Add(this.lblProductPrice);
            this.pnlProduct.Location = new System.Drawing.Point(6, 6);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(606, 34);
            this.pnlProduct.TabIndex = 0;
            this.IceCreamHelperToolTips.SetToolTip(this.pnlProduct, "Click \"Add To Order\" on this product to add it to your order.");
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.Green;
            this.btnAddProduct.Location = new System.Drawing.Point(502, 6);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(100, 23);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = "Add To Order";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(63, 7);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(122, 20);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.ForeColor = System.Drawing.Color.Green;
            this.lblProductPrice.Location = new System.Drawing.Point(3, 7);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(54, 20);
            this.lblProductPrice.TabIndex = 0;
            this.lblProductPrice.Text = "$9.99";
            // 
            // pnlProductPanelView
            // 
            this.pnlProductPanelView.Location = new System.Drawing.Point(6, 6);
            this.pnlProductPanelView.Name = "pnlProductPanelView";
            this.pnlProductPanelView.Size = new System.Drawing.Size(606, 297);
            this.pnlProductPanelView.TabIndex = 3;
            // 
            // lblCartMenuFooter
            // 
            this.lblCartMenuFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCartMenuFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.lblCartMenuFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartMenuFooter.ForeColor = System.Drawing.Color.White;
            this.lblCartMenuFooter.Location = new System.Drawing.Point(-2, 306);
            this.lblCartMenuFooter.Name = "lblCartMenuFooter";
            this.lblCartMenuFooter.Size = new System.Drawing.Size(622, 44);
            this.lblCartMenuFooter.TabIndex = 2;
            this.lblCartMenuFooter.Text = "Ice Cream Sales Helper - Cart Menu";
            // 
            // lblGameOpenPrompt
            // 
            this.lblGameOpenPrompt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGameOpenPrompt.Location = new System.Drawing.Point(170, 224);
            this.lblGameOpenPrompt.Name = "lblGameOpenPrompt";
            this.lblGameOpenPrompt.Size = new System.Drawing.Size(345, 13);
            this.lblGameOpenPrompt.TabIndex = 1;
            this.lblGameOpenPrompt.Text = "No game open...Press the \'+\' on the Game Picker menu to pick a game!";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(465, 7);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(31, 20);
            this.nudQuantity.TabIndex = 0;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCash
            // 
            this.btnCash.Enabled = false;
            this.btnCash.Location = new System.Drawing.Point(540, 310);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(75, 23);
            this.btnCash.TabIndex = 3;
            this.btnCash.Text = "Pay Cash";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // btnCard
            // 
            this.btnCard.Enabled = false;
            this.btnCard.Location = new System.Drawing.Point(459, 310);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(75, 23);
            this.btnCard.TabIndex = 4;
            this.btnCard.Text = "Pay Card";
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // lblOrderTotalHeader
            // 
            this.lblOrderTotalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.lblOrderTotalHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotalHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOrderTotalHeader.Location = new System.Drawing.Point(0, 3);
            this.lblOrderTotalHeader.Name = "lblOrderTotalHeader";
            this.lblOrderTotalHeader.Size = new System.Drawing.Size(622, 44);
            this.lblOrderTotalHeader.TabIndex = 5;
            this.lblOrderTotalHeader.Text = "Total Amount Due:";
            this.lblOrderTotalHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.lblAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAmountDue.Location = new System.Drawing.Point(186, 14);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(36, 25);
            this.lblAmountDue.TabIndex = 6;
            this.lblAmountDue.Text = "$0";
            // 
            // pnlOrderList
            // 
            this.pnlOrderList.AutoScroll = true;
            this.pnlOrderList.Location = new System.Drawing.Point(0, 59);
            this.pnlOrderList.Name = "pnlOrderList";
            this.pnlOrderList.Size = new System.Drawing.Size(618, 215);
            this.pnlOrderList.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.pnlIceCream);
            this.Controls.Add(this.btnExitProgram);
            this.Controls.Add(this.lblGameOpenPrompt);
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Games";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlIceCream.ResumeLayout(false);
            this.tctrlContentArea.ResumeLayout(false);
            this.tpgOrderTotal.ResumeLayout(false);
            this.tpgOrderTotal.PerformLayout();
            this.tpgCartMenu.ResumeLayout(false);
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExitProgram;
        private System.Windows.Forms.Panel pnlIceCream;
        private System.Windows.Forms.TabControl tctrlContentArea;
        private System.Windows.Forms.TabPage tpgOrderTotal;
        private System.Windows.Forms.TabPage tpgCartMenu;
        private System.Windows.Forms.Label lblOrderTotalFooter;
        private System.Windows.Forms.Label lblCartMenuFooter;
        private System.Windows.Forms.Label lblCartEmptyIndiactor;
        private System.Windows.Forms.Label lblGameOpenPrompt;
        private System.Windows.Forms.Panel pnlProductPanelView;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ToolTip IceCreamHelperToolTips;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Label lblOrderTotalHeader;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.Panel pnlOrderList;
    }
}

