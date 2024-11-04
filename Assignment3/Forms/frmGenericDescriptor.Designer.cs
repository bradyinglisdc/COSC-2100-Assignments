namespace Assignment3.Forms
{
    partial class frmGenericDescriptor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenericDescriptor));
            printPreviewDialog1 = new PrintPreviewDialog();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Baskerville Old Face", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Image = Properties.Resources.CharacterCreatorButton;
            lblDescription.Location = new Point(0, -4);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(373, 207);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "none";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmGenericDescriptor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 197);
            Controls.Add(lblDescription);
            MaximumSize = new Size(386, 236);
            MinimumSize = new Size(386, 236);
            Name = "frmGenericDescriptor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Description";
            ResumeLayout(false);
        }

        #endregion

        private PrintPreviewDialog printPreviewDialog1;
        private Label lblDescription;
    }
}