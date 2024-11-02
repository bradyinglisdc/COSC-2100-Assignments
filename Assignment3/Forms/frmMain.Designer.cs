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
            lblCharacterStatsHeader = new Label();
            lblLevel = new Label();
            pbrLevelProgress = new ProgressBar();
            btnExitApplication = new Button();
            btnNewCharacter = new Button();
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
            // lblCharacterStatsHeader
            // 
            lblCharacterStatsHeader.BackColor = Color.FromArgb(13, 13, 13);
            lblCharacterStatsHeader.Font = new Font("Algerian", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCharacterStatsHeader.ForeColor = Color.White;
            lblCharacterStatsHeader.Location = new Point(586, 118);
            lblCharacterStatsHeader.Name = "lblCharacterStatsHeader";
            lblCharacterStatsHeader.Size = new Size(320, 37);
            lblCharacterStatsHeader.TabIndex = 0;
            lblCharacterStatsHeader.Text = "Character's Stats";
            lblCharacterStatsHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLevel
            // 
            lblLevel.BackColor = Color.FromArgb(13, 13, 13);
            lblLevel.ForeColor = Color.White;
            lblLevel.Location = new Point(601, 177);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(208, 17);
            lblLevel.TabIndex = 1;
            lblLevel.Text = "Level: 13 (10000/30000 XP to level 14)";
            lblLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbrLevelProgress
            // 
            pbrLevelProgress.BackColor = SystemColors.ControlLight;
            pbrLevelProgress.Location = new Point(601, 197);
            pbrLevelProgress.Name = "pbrLevelProgress";
            pbrLevelProgress.Size = new Size(292, 23);
            pbrLevelProgress.TabIndex = 2;
            // 
            // btnExitApplication
            // 
            btnExitApplication.Location = new Point(391, 553);
            btnExitApplication.Name = "btnExitApplication";
            btnExitApplication.Size = new Size(116, 37);
            btnExitApplication.TabIndex = 3;
            btnExitApplication.Text = "Exit";
            btnExitApplication.UseVisualStyleBackColor = true;
            // 
            // btnNewCharacter
            // 
            btnNewCharacter.Location = new Point(529, 553);
            btnNewCharacter.Name = "btnNewCharacter";
            btnNewCharacter.Size = new Size(116, 37);
            btnNewCharacter.TabIndex = 4;
            btnNewCharacter.Text = "New Character";
            btnNewCharacter.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 635);
            Controls.Add(btnNewCharacter);
            Controls.Add(btnExitApplication);
            Controls.Add(lblLevel);
            Controls.Add(pbrLevelProgress);
            Controls.Add(lblCharacterStatsHeader);
            Controls.Add(pbxMainBackground);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "D&D: Character View";
            ((System.ComponentModel.ISupportInitialize)pbxMainBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxMainBackground;
        private Label lblCharacterStatsHeader;
        private Label lblLevel;
        private ProgressBar pbrLevelProgress;
        private Button btnExitApplication;
        private Button btnNewCharacter;
    }
}