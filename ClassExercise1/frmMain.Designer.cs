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
            this.btnExitProgram = new System.Windows.Forms.Button();
            this.pnlIceCream = new System.Windows.Forms.Panel();
            this.tctrlContentArea = new System.Windows.Forms.TabControl();
            this.tpgOrderTotal = new System.Windows.Forms.TabPage();
            this.lblCartEmptyIndiactor = new System.Windows.Forms.Label();
            this.lblOrderTotalFooter = new System.Windows.Forms.Label();
            this.tpgCartMenu = new System.Windows.Forms.TabPage();
            this.lblCartMenuFooter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOpenGamePrompt = new System.Windows.Forms.Label();
            this.pnlIceCream.SuspendLayout();
            this.tctrlContentArea.SuspendLayout();
            this.tpgOrderTotal.SuspendLayout();
            this.tpgCartMenu.SuspendLayout();
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
            this.tctrlContentArea.Location = new System.Drawing.Point(17, 42);
            this.tctrlContentArea.Name = "tctrlContentArea";
            this.tctrlContentArea.SelectedIndex = 0;
            this.tctrlContentArea.Size = new System.Drawing.Size(626, 357);
            this.tctrlContentArea.TabIndex = 0;
            // 
            // tpgOrderTotal
            // 
            this.tpgOrderTotal.Controls.Add(this.lblCartEmptyIndiactor);
            this.tpgOrderTotal.Controls.Add(this.lblOrderTotalFooter);
            this.tpgOrderTotal.Location = new System.Drawing.Point(4, 22);
            this.tpgOrderTotal.Name = "tpgOrderTotal";
            this.tpgOrderTotal.Padding = new System.Windows.Forms.Padding(3);
            this.tpgOrderTotal.Size = new System.Drawing.Size(618, 331);
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
            this.lblOrderTotalFooter.Size = new System.Drawing.Size(622, 29);
            this.lblOrderTotalFooter.TabIndex = 1;
            this.lblOrderTotalFooter.Text = "Ice Cream Sales Helper - Order Total";
            // 
            // tpgCartMenu
            // 
            this.tpgCartMenu.Controls.Add(this.panel1);
            this.tpgCartMenu.Controls.Add(this.lblCartMenuFooter);
            this.tpgCartMenu.Location = new System.Drawing.Point(4, 22);
            this.tpgCartMenu.Name = "tpgCartMenu";
            this.tpgCartMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCartMenu.Size = new System.Drawing.Size(618, 331);
            this.tpgCartMenu.TabIndex = 1;
            this.tpgCartMenu.Text = "Cart Menu";
            this.tpgCartMenu.UseVisualStyleBackColor = true;
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
            this.lblCartMenuFooter.Size = new System.Drawing.Size(622, 29);
            this.lblCartMenuFooter.TabIndex = 2;
            this.lblCartMenuFooter.Text = "Ice Cream Sales Helper - Cart Menu";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(79, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // lblOpenGamePrompt
            // 
            this.lblOpenGamePrompt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOpenGamePrompt.Location = new System.Drawing.Point(170, 224);
            this.lblOpenGamePrompt.Name = "lblOpenGamePrompt";
            this.lblOpenGamePrompt.Size = new System.Drawing.Size(345, 13);
            this.lblOpenGamePrompt.TabIndex = 1;
            this.lblOpenGamePrompt.Text = "No game open...Press the \'+\' on the Game Picker menu to pick a game!";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.pnlIceCream);
            this.Controls.Add(this.btnExitProgram);
            this.Controls.Add(this.lblOpenGamePrompt);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOpenGamePrompt;
    }
}

