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
            components = new System.ComponentModel.Container();
            pbxSplashBackground = new PictureBox();
            btnAccessCharacterCreator = new Button();
            btnExitApplication = new Button();
            SplashScreenToolTips = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pbxSplashBackground).BeginInit();
            SuspendLayout();
            // 
            // pbxSplashBackground
            // 
            pbxSplashBackground.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxSplashBackground.Image = Properties.Resources.SplashBackgroundFinal_v1;
            pbxSplashBackground.Location = new Point(0, 0);
            pbxSplashBackground.Name = "pbxSplashBackground";
            pbxSplashBackground.Size = new Size(1038, 638);
            pbxSplashBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxSplashBackground.TabIndex = 0;
            pbxSplashBackground.TabStop = false;
            // 
            // btnAccessCharacterCreator
            // 
            btnAccessCharacterCreator.Anchor = AnchorStyles.None;
            btnAccessCharacterCreator.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnAccessCharacterCreator.FlatAppearance.BorderColor = Color.Black;
            btnAccessCharacterCreator.FlatAppearance.BorderSize = 2;
            btnAccessCharacterCreator.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnAccessCharacterCreator.FlatStyle = FlatStyle.Flat;
            btnAccessCharacterCreator.Font = new Font("Algerian", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAccessCharacterCreator.Location = new Point(409, 274);
            btnAccessCharacterCreator.Name = "btnAccessCharacterCreator";
            btnAccessCharacterCreator.Size = new Size(241, 49);
            btnAccessCharacterCreator.TabIndex = 0;
            btnAccessCharacterCreator.Text = "Enter &Character Creator";
            SplashScreenToolTips.SetToolTip(btnAccessCharacterCreator, "Click here, or press 'ALT + C' to enter Character Creator.");
            btnAccessCharacterCreator.UseVisualStyleBackColor = true;
            btnAccessCharacterCreator.Click += btnAccessCharacterCreator_Click;
            btnAccessCharacterCreator.MouseEnter += btnGeneric_MouseEnter;
            btnAccessCharacterCreator.MouseLeave += btnGeneric_MouseLeave;
            // 
            // btnExitApplication
            // 
            btnExitApplication.Anchor = AnchorStyles.None;
            btnExitApplication.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnExitApplication.FlatAppearance.BorderColor = Color.Black;
            btnExitApplication.FlatAppearance.BorderSize = 2;
            btnExitApplication.FlatAppearance.MouseOverBackColor = Color.Black;
            btnExitApplication.FlatStyle = FlatStyle.Flat;
            btnExitApplication.Font = new Font("Algerian", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExitApplication.Location = new Point(475, 329);
            btnExitApplication.Name = "btnExitApplication";
            btnExitApplication.Size = new Size(109, 39);
            btnExitApplication.TabIndex = 1;
            btnExitApplication.Text = "Exit";
            SplashScreenToolTips.SetToolTip(btnExitApplication, "Click here, or press 'ALT + X' to exit the application.");
            btnExitApplication.UseVisualStyleBackColor = true;
            btnExitApplication.MouseEnter += btnGeneric_MouseEnter;
            btnExitApplication.MouseLeave += btnGeneric_MouseLeave;
            // 
            // frmSplash
            // 
            AcceptButton = btnAccessCharacterCreator;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitApplication;
            ClientSize = new Size(1037, 635);
            Controls.Add(btnExitApplication);
            Controls.Add(btnAccessCharacterCreator);
            Controls.Add(pbxSplashBackground);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "D&D: Character Creator";
            ((System.ComponentModel.ISupportInitialize)pbxSplashBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxSplashBackground;
        private Button btnAccessCharacterCreator;
        private Button btnExitApplication;
        private ToolTip SplashScreenToolTips;
    }
}
