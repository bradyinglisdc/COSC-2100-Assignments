namespace Assignment4
{
    partial class frmMainMenu
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
            btnEditDefaultProfile = new Button();
            btnViewProfiles = new Button();
            btnQuit = new Button();
            SuspendLayout();
            // 
            // btnEditDefaultProfile
            // 
            btnEditDefaultProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnEditDefaultProfile.BackColor = Color.FromArgb(130, 130, 130);
            btnEditDefaultProfile.FlatAppearance.BorderSize = 2;
            btnEditDefaultProfile.FlatStyle = FlatStyle.Popup;
            btnEditDefaultProfile.Font = new Font("Minecraftia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditDefaultProfile.ForeColor = SystemColors.Control;
            btnEditDefaultProfile.Location = new Point(320, 214);
            btnEditDefaultProfile.Margin = new Padding(3, 4, 3, 4);
            btnEditDefaultProfile.Name = "btnEditDefaultProfile";
            btnEditDefaultProfile.Size = new Size(275, 65);
            btnEditDefaultProfile.TabIndex = 0;
            btnEditDefaultProfile.Text = "Edit Default Profile";
            btnEditDefaultProfile.UseVisualStyleBackColor = false;
            btnEditDefaultProfile.Click += btnEditDefaultProfile_Click;
            // 
            // btnViewProfiles
            // 
            btnViewProfiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnViewProfiles.BackColor = Color.FromArgb(130, 130, 130);
            btnViewProfiles.FlatAppearance.BorderSize = 2;
            btnViewProfiles.FlatStyle = FlatStyle.Popup;
            btnViewProfiles.Font = new Font("Minecraftia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewProfiles.ForeColor = SystemColors.Control;
            btnViewProfiles.Location = new Point(320, 288);
            btnViewProfiles.Margin = new Padding(3, 4, 3, 4);
            btnViewProfiles.Name = "btnViewProfiles";
            btnViewProfiles.Size = new Size(275, 65);
            btnViewProfiles.TabIndex = 1;
            btnViewProfiles.Text = "View/Create Profiles";
            btnViewProfiles.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnQuit.BackColor = Color.FromArgb(130, 130, 130);
            btnQuit.FlatAppearance.BorderSize = 2;
            btnQuit.FlatStyle = FlatStyle.Popup;
            btnQuit.Font = new Font("Minecraftia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQuit.ForeColor = SystemColors.Control;
            btnQuit.Location = new Point(352, 361);
            btnQuit.Margin = new Padding(3, 4, 3, 4);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(208, 65);
            btnQuit.TabIndex = 2;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = false;
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnQuit);
            Controls.Add(btnViewProfiles);
            Controls.Add(btnEditDefaultProfile);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            ResumeLayout(false);
        }

        #endregion
        private Button btnEditDefaultProfile;
        private Button btnViewProfiles;
        private Button btnQuit;
    }
}
