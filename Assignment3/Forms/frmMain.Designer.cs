namespace Assignment3
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
            pbxMainBackground = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxMainBackground).BeginInit();
            SuspendLayout();
            // 
            // pbxMainBackground
            // 
            pbxMainBackground.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxMainBackground.Image = Properties.Resources.MainFrmBaclgroundV3;
            pbxMainBackground.Location = new Point(0, 0);
            pbxMainBackground.Name = "pbxMainBackground";
            pbxMainBackground.Size = new Size(1040, 635);
            pbxMainBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMainBackground.TabIndex = 0;
            pbxMainBackground.TabStop = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 635);
            Controls.Add(pbxMainBackground);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "D&D: Character View";
            ((System.ComponentModel.ISupportInitialize)pbxMainBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxMainBackground;
    }
}