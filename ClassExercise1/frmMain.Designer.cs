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
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblMenuHeader = new System.Windows.Forms.Label();
            this.pnlTabBar = new System.Windows.Forms.Panel();
            this.btnStartGuessTheNumber = new System.Windows.Forms.Button();
            this.btnStartIceCream = new System.Windows.Forms.Button();
            this.pnlMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.pnlMainMenu.Controls.Add(this.btnStartIceCream);
            this.pnlMainMenu.Controls.Add(this.btnStartGuessTheNumber);
            this.pnlMainMenu.Controls.Add(this.lblMenuHeader);
            this.pnlMainMenu.Controls.Add(this.btnMinimize);
            this.pnlMainMenu.Controls.Add(this.pnlTabBar);
            this.pnlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(183, 450);
            this.pnlMainMenu.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(151, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(29, 16);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // lblMenuHeader
            // 
            this.lblMenuHeader.AutoSize = true;
            this.lblMenuHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMenuHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblMenuHeader.Location = new System.Drawing.Point(3, 5);
            this.lblMenuHeader.Name = "lblMenuHeader";
            this.lblMenuHeader.Size = new System.Drawing.Size(95, 18);
            this.lblMenuHeader.TabIndex = 1;
            this.lblMenuHeader.Text = "Game Picker";
            // 
            // pnlTabBar
            // 
            this.pnlTabBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTabBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTabBar.Name = "pnlTabBar";
            this.pnlTabBar.Size = new System.Drawing.Size(183, 30);
            this.pnlTabBar.TabIndex = 2;
            // 
            // btnStartGuessTheNumber
            // 
            this.btnStartGuessTheNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStartGuessTheNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGuessTheNumber.Location = new System.Drawing.Point(0, 36);
            this.btnStartGuessTheNumber.Name = "btnStartGuessTheNumber";
            this.btnStartGuessTheNumber.Size = new System.Drawing.Size(183, 34);
            this.btnStartGuessTheNumber.TabIndex = 3;
            this.btnStartGuessTheNumber.Text = "Guess The Number";
            this.btnStartGuessTheNumber.UseVisualStyleBackColor = false;
            // 
            // btnStartIceCream
            // 
            this.btnStartIceCream.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStartIceCream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartIceCream.Location = new System.Drawing.Point(0, 76);
            this.btnStartIceCream.Name = "btnStartIceCream";
            this.btnStartIceCream.Size = new System.Drawing.Size(183, 34);
            this.btnStartIceCream.TabIndex = 4;
            this.btnStartIceCream.Text = "Ice Cream";
            this.btnStartIceCream.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMainMenu);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Games";
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblMenuHeader;
        private System.Windows.Forms.Panel pnlTabBar;
        private System.Windows.Forms.Button btnStartGuessTheNumber;
        private System.Windows.Forms.Button btnStartIceCream;
    }
}

