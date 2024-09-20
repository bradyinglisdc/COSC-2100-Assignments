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
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.pnlIceCream.SuspendLayout();
            this.tctrlContentArea.SuspendLayout();
            this.tpgOrderTotal.SuspendLayout();
            this.tpgCartMenu.SuspendLayout();
            this.pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
  
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
        private System.Windows.Forms.Button btnCancelOrder;
    }
}

