namespace Assignment3
{
    partial class frmSplash
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSplashHeader = new Label();
            SuspendLayout();
            // 
            // lblSplashHeader
            // 
            lblSplashHeader.BackColor = Color.FromArgb(10, 10, 10);
            lblSplashHeader.Font = new Font("Algerian", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSplashHeader.ForeColor = SystemColors.Control;
            lblSplashHeader.Location = new Point(0, 0);
            lblSplashHeader.Name = "lblSplashHeader";
            lblSplashHeader.Size = new Size(729, 53);
            lblSplashHeader.TabIndex = 0;
            lblSplashHeader.Text = "Dungeons && Dragons:\r\nCharacter Creator\r\n\r\n\r\n";
            lblSplashHeader.TextAlign = ContentAlignment.BottomCenter;
            // 
            // frmSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 380);
            Controls.Add(lblSplashHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSplash";
            Text = "Character Creator";
            ResumeLayout(false);
        }

        #endregion

        private Label lblSplashHeader;
    }
}
