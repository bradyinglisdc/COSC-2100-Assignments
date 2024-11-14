namespace Assignment4
{
    partial class frmEditProfile
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
            tbxSearch = new TextBox();
            lblSearch = new Label();
            SuspendLayout();
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new Point(229, 52);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(316, 27);
            tbxSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(229, 29);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(53, 20);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // frmEditProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSearch);
            Controls.Add(tbxSearch);
            Name = "frmEditProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profile Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxSearch;
        private Label lblSearch;
    }
}