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
            fileSystemWatcher1 = new FileSystemWatcher();
            btnEditProfile = new Button();
            btnViewProfiles = new Button();
            btnQuit = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnEditProfile
            // 
            btnEditProfile.BackColor = Color.FromArgb(130, 130, 130);
            btnEditProfile.FlatAppearance.BorderSize = 2;
            btnEditProfile.FlatStyle = FlatStyle.Popup;
            btnEditProfile.Font = new Font("Minecraftia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditProfile.ForeColor = SystemColors.Control;
            btnEditProfile.Location = new Point(280, 154);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(241, 49);
            btnEditProfile.TabIndex = 0;
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.UseVisualStyleBackColor = false;
            // 
            // btnViewProfiles
            // 
            btnViewProfiles.BackColor = Color.FromArgb(130, 130, 130);
            btnViewProfiles.FlatAppearance.BorderSize = 2;
            btnViewProfiles.FlatStyle = FlatStyle.Popup;
            btnViewProfiles.Font = new Font("Minecraftia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewProfiles.ForeColor = SystemColors.Control;
            btnViewProfiles.Location = new Point(280, 209);
            btnViewProfiles.Name = "btnViewProfiles";
            btnViewProfiles.Size = new Size(241, 49);
            btnViewProfiles.TabIndex = 1;
            btnViewProfiles.Text = "View Profiles";
            btnViewProfiles.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.FromArgb(130, 130, 130);
            btnQuit.FlatAppearance.BorderSize = 2;
            btnQuit.FlatStyle = FlatStyle.Popup;
            btnQuit.Font = new Font("Minecraftia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQuit.ForeColor = SystemColors.Control;
            btnQuit.Location = new Point(308, 264);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(182, 49);
            btnQuit.TabIndex = 2;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = false;
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuit);
            Controls.Add(btnViewProfiles);
            Controls.Add(btnEditProfile);
            Name = "frmMainMenu";
            Text = "Main Menu";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private Button btnEditProfile;
        private Button btnViewProfiles;
        private Button btnQuit;
    }
}
