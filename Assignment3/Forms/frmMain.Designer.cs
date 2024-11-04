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
            components = new System.ComponentModel.Container();
            pbxMainBackground = new PictureBox();
            lblCharacterStatsHeader = new Label();
            lblLevel = new Label();
            btnExitApplication = new Button();
            btnNewCharacter = new Button();
            lblClass = new Label();
            lblRace = new Label();
            lblClassHPDice = new Label();
            lblAlignment = new Label();
            lblGender = new Label();
            lblArmourClass = new Label();
            lblInitiative = new Label();
            lblHitPoints = new Label();
            lblSpeed = new Label();
            btnViewAttributes = new Button();
            btnEditCharacter = new Button();
            btnNextPage = new Button();
            btnPreviousPage = new Button();
            btnDeleteCharacter = new Button();
            lblExperiencePoints = new Label();
            btnClassDescription = new Button();
            btnRaceDescription = new Button();
            lblRaceBonusAttributes = new Label();
            CharacterViewToolTips = new ToolTip(components);
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
            lblCharacterStatsHeader.Anchor = AnchorStyles.None;
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
            lblLevel.Anchor = AnchorStyles.None;
            lblLevel.BackColor = Color.FromArgb(13, 13, 13);
            lblLevel.ForeColor = Color.White;
            lblLevel.Location = new Point(601, 285);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(292, 17);
            lblLevel.TabIndex = 1;
            lblLevel.Text = "Level: 13";
            lblLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnExitApplication
            // 
            btnExitApplication.Anchor = AnchorStyles.None;
            btnExitApplication.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnExitApplication.FlatAppearance.BorderColor = Color.Black;
            btnExitApplication.FlatAppearance.BorderSize = 2;
            btnExitApplication.FlatStyle = FlatStyle.Flat;
            btnExitApplication.Font = new Font("Algerian", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExitApplication.Location = new Point(361, 553);
            btnExitApplication.Name = "btnExitApplication";
            btnExitApplication.Size = new Size(154, 37);
            btnExitApplication.TabIndex = 2;
            btnExitApplication.Text = "E&xit";
            CharacterViewToolTips.SetToolTip(btnExitApplication, "Click here, or press 'ALT + X' to exit");
            btnExitApplication.UseVisualStyleBackColor = true;
            btnExitApplication.Click += btnExitApplication_Click;
            btnExitApplication.MouseEnter += btnGeneric_MouseEnter;
            btnExitApplication.MouseLeave += btnGeneric_MouseLeave;
            // 
            // btnNewCharacter
            // 
            btnNewCharacter.Anchor = AnchorStyles.None;
            btnNewCharacter.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnNewCharacter.FlatAppearance.BorderColor = Color.Black;
            btnNewCharacter.FlatAppearance.BorderSize = 2;
            btnNewCharacter.FlatStyle = FlatStyle.Flat;
            btnNewCharacter.Font = new Font("Algerian", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNewCharacter.Location = new Point(521, 553);
            btnNewCharacter.Name = "btnNewCharacter";
            btnNewCharacter.Size = new Size(154, 37);
            btnNewCharacter.TabIndex = 3;
            btnNewCharacter.Text = "&New Character";
            CharacterViewToolTips.SetToolTip(btnNewCharacter, "Click here, or press 'ALT + N' to create a new character");
            btnNewCharacter.UseVisualStyleBackColor = true;
            btnNewCharacter.Click += btnNewCharacter_Click;
            btnNewCharacter.MouseEnter += btnGeneric_MouseEnter;
            btnNewCharacter.MouseLeave += btnGeneric_MouseLeave;
            // 
            // lblClass
            // 
            lblClass.Anchor = AnchorStyles.None;
            lblClass.BackColor = Color.FromArgb(13, 13, 13);
            lblClass.ForeColor = Color.White;
            lblClass.Location = new Point(601, 344);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(292, 17);
            lblClass.TabIndex = 5;
            lblClass.Text = "Class: Barbarian";
            lblClass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRace
            // 
            lblRace.Anchor = AnchorStyles.None;
            lblRace.BackColor = Color.FromArgb(13, 13, 13);
            lblRace.ForeColor = Color.White;
            lblRace.Location = new Point(601, 397);
            lblRace.Name = "lblRace";
            lblRace.Size = new Size(292, 17);
            lblRace.TabIndex = 7;
            lblRace.Text = "Race: Dwarf";
            lblRace.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblClassHPDice
            // 
            lblClassHPDice.Anchor = AnchorStyles.None;
            lblClassHPDice.Location = new Point(601, 361);
            lblClassHPDice.Name = "lblClassHPDice";
            lblClassHPDice.Size = new Size(292, 20);
            lblClassHPDice.TabIndex = 7;
            lblClassHPDice.Text = "HP Dice: 12";
            lblClassHPDice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlignment
            // 
            lblAlignment.Anchor = AnchorStyles.None;
            lblAlignment.BackColor = Color.FromArgb(13, 13, 13);
            lblAlignment.ForeColor = Color.White;
            lblAlignment.Location = new Point(601, 183);
            lblAlignment.Name = "lblAlignment";
            lblAlignment.Size = new Size(292, 17);
            lblAlignment.TabIndex = 9;
            lblAlignment.Text = "Alignment: Lawful Good";
            lblAlignment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGender
            // 
            lblGender.Anchor = AnchorStyles.None;
            lblGender.BackColor = Color.FromArgb(13, 13, 13);
            lblGender.ForeColor = Color.White;
            lblGender.Location = new Point(601, 166);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(292, 17);
            lblGender.TabIndex = 10;
            lblGender.Text = "Gender: Male";
            lblGender.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblArmourClass
            // 
            lblArmourClass.Anchor = AnchorStyles.None;
            lblArmourClass.BackColor = Color.FromArgb(13, 13, 13);
            lblArmourClass.ForeColor = Color.White;
            lblArmourClass.Location = new Point(601, 217);
            lblArmourClass.Name = "lblArmourClass";
            lblArmourClass.Size = new Size(292, 17);
            lblArmourClass.TabIndex = 11;
            lblArmourClass.Text = "Armour Class: 12";
            lblArmourClass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInitiative
            // 
            lblInitiative.Anchor = AnchorStyles.None;
            lblInitiative.BackColor = Color.FromArgb(13, 13, 13);
            lblInitiative.ForeColor = Color.White;
            lblInitiative.Location = new Point(601, 200);
            lblInitiative.Name = "lblInitiative";
            lblInitiative.Size = new Size(292, 17);
            lblInitiative.TabIndex = 12;
            lblInitiative.Text = "Initiative: 14";
            lblInitiative.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHitPoints
            // 
            lblHitPoints.Anchor = AnchorStyles.None;
            lblHitPoints.BackColor = Color.FromArgb(13, 13, 13);
            lblHitPoints.ForeColor = Color.White;
            lblHitPoints.Location = new Point(601, 234);
            lblHitPoints.Name = "lblHitPoints";
            lblHitPoints.Size = new Size(292, 17);
            lblHitPoints.TabIndex = 13;
            lblHitPoints.Text = "Hit Points: 20";
            lblHitPoints.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSpeed
            // 
            lblSpeed.Anchor = AnchorStyles.None;
            lblSpeed.BackColor = Color.FromArgb(13, 13, 13);
            lblSpeed.ForeColor = Color.White;
            lblSpeed.Location = new Point(601, 251);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(292, 17);
            lblSpeed.TabIndex = 14;
            lblSpeed.Text = "Speed: 16";
            lblSpeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnViewAttributes
            // 
            btnViewAttributes.Anchor = AnchorStyles.None;
            btnViewAttributes.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnViewAttributes.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnViewAttributes.FlatAppearance.BorderSize = 2;
            btnViewAttributes.FlatStyle = FlatStyle.Flat;
            btnViewAttributes.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewAttributes.Location = new Point(601, 447);
            btnViewAttributes.Name = "btnViewAttributes";
            btnViewAttributes.Size = new Size(135, 42);
            btnViewAttributes.TabIndex = 4;
            btnViewAttributes.Text = "&View\r\nAttributes";
            CharacterViewToolTips.SetToolTip(btnViewAttributes, "Click here, or press 'ALT + V' to view attributes");
            btnViewAttributes.UseVisualStyleBackColor = true;
            btnViewAttributes.Click += btnViewAttributes_Click;
            btnViewAttributes.MouseEnter += btnGeneric_MouseEnter;
            btnViewAttributes.MouseLeave += btnGeneric_MouseLeave;
            // 
            // btnEditCharacter
            // 
            btnEditCharacter.Anchor = AnchorStyles.None;
            btnEditCharacter.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnEditCharacter.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnEditCharacter.FlatAppearance.BorderSize = 2;
            btnEditCharacter.FlatStyle = FlatStyle.Flat;
            btnEditCharacter.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditCharacter.Location = new Point(758, 447);
            btnEditCharacter.Name = "btnEditCharacter";
            btnEditCharacter.Size = new Size(135, 42);
            btnEditCharacter.TabIndex = 5;
            btnEditCharacter.Text = "&Edit\r\nCharacter";
            CharacterViewToolTips.SetToolTip(btnEditCharacter, "Click here, or press 'AlT + E' to edit the current character");
            btnEditCharacter.UseVisualStyleBackColor = true;
            btnEditCharacter.Click += btnEditCharacter_Click;
            btnEditCharacter.MouseEnter += btnGeneric_MouseEnter;
            btnEditCharacter.MouseLeave += btnGeneric_MouseLeave;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.None;
            btnNextPage.BackgroundImage = Properties.Resources.GenericRuggedPaper;
            btnNextPage.FlatAppearance.BorderColor = Color.Black;
            btnNextPage.FlatAppearance.BorderSize = 2;
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNextPage.Location = new Point(375, 493);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(154, 26);
            btnNextPage.TabIndex = 1;
            btnNextPage.Text = "&Next Page";
            CharacterViewToolTips.SetToolTip(btnNextPage, "Click here, or press 'ALT + N ' to navigate to next page");
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            btnNextPage.MouseEnter += btnGeneric_MouseEnter;
            btnNextPage.MouseLeave += btnGeneric_MouseLeave;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Anchor = AnchorStyles.None;
            btnPreviousPage.BackgroundImage = Properties.Resources.GenericRuggedPaper;
            btnPreviousPage.FlatAppearance.BorderColor = Color.Black;
            btnPreviousPage.FlatAppearance.BorderSize = 2;
            btnPreviousPage.FlatStyle = FlatStyle.Flat;
            btnPreviousPage.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPreviousPage.Location = new Point(199, 493);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(154, 26);
            btnPreviousPage.TabIndex = 0;
            btnPreviousPage.Text = "&Previous Page";
            CharacterViewToolTips.SetToolTip(btnPreviousPage, "Click here, or press 'ALT + P' to navigate to previous page.");
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            btnPreviousPage.MouseEnter += btnGeneric_MouseEnter;
            btnPreviousPage.MouseLeave += btnGeneric_MouseLeave;
            // 
            // btnDeleteCharacter
            // 
            btnDeleteCharacter.Anchor = AnchorStyles.None;
            btnDeleteCharacter.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            btnDeleteCharacter.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnDeleteCharacter.FlatAppearance.BorderSize = 2;
            btnDeleteCharacter.FlatStyle = FlatStyle.Flat;
            btnDeleteCharacter.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteCharacter.Location = new Point(677, 495);
            btnDeleteCharacter.Name = "btnDeleteCharacter";
            btnDeleteCharacter.Size = new Size(135, 24);
            btnDeleteCharacter.TabIndex = 6;
            btnDeleteCharacter.Text = "&Delete";
            CharacterViewToolTips.SetToolTip(btnDeleteCharacter, "Click here, or press 'ALT +D' to delete the selected character");
            btnDeleteCharacter.UseVisualStyleBackColor = true;
            btnDeleteCharacter.Click += btnDeleteCharacter_Click;
            btnDeleteCharacter.MouseEnter += btnGeneric_MouseEnter;
            btnDeleteCharacter.MouseLeave += btnGeneric_MouseLeave;
            // 
            // lblExperiencePoints
            // 
            lblExperiencePoints.Anchor = AnchorStyles.None;
            lblExperiencePoints.Location = new Point(601, 302);
            lblExperiencePoints.Name = "lblExperiencePoints";
            lblExperiencePoints.Size = new Size(292, 20);
            lblExperiencePoints.TabIndex = 20;
            lblExperiencePoints.Text = "Experience Points: 0";
            lblExperiencePoints.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClassDescription
            // 
            btnClassDescription.Anchor = AnchorStyles.None;
            btnClassDescription.BackgroundImage = Properties.Resources.GenericRuggedPaper;
            btnClassDescription.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnClassDescription.FlatAppearance.BorderSize = 2;
            btnClassDescription.FlatStyle = FlatStyle.Flat;
            btnClassDescription.Font = new Font("Algerian", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClassDescription.Location = new Point(758, 339);
            btnClassDescription.Name = "btnClassDescription";
            btnClassDescription.Size = new Size(135, 22);
            btnClassDescription.TabIndex = 8;
            btnClassDescription.Text = "View Des&cription";
            CharacterViewToolTips.SetToolTip(btnClassDescription, "Click here, or press 'ALT + C' to view the selected character's race description.");
            btnClassDescription.UseVisualStyleBackColor = true;
            btnClassDescription.Click += btnClassDescription_Click;
            // 
            // btnRaceDescription
            // 
            btnRaceDescription.Anchor = AnchorStyles.None;
            btnRaceDescription.BackgroundImage = Properties.Resources.GenericRuggedPaper;
            btnRaceDescription.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnRaceDescription.FlatAppearance.BorderSize = 2;
            btnRaceDescription.FlatStyle = FlatStyle.Flat;
            btnRaceDescription.Font = new Font("Algerian", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRaceDescription.Location = new Point(758, 392);
            btnRaceDescription.Name = "btnRaceDescription";
            btnRaceDescription.Size = new Size(135, 22);
            btnRaceDescription.TabIndex = 7;
            btnRaceDescription.Text = "View Desc&ription";
            CharacterViewToolTips.SetToolTip(btnRaceDescription, "Click here, or press 'ALT + R' to view the selected character's race description.");
            btnRaceDescription.UseVisualStyleBackColor = true;
            btnRaceDescription.Click += btnRaceDescription_Click;
            // 
            // lblRaceBonusAttributes
            // 
            lblRaceBonusAttributes.Anchor = AnchorStyles.None;
            lblRaceBonusAttributes.Location = new Point(601, 414);
            lblRaceBonusAttributes.Name = "lblRaceBonusAttributes";
            lblRaceBonusAttributes.Size = new Size(292, 20);
            lblRaceBonusAttributes.TabIndex = 8;
            lblRaceBonusAttributes.Text = "Ability Score Increase: See Description";
            lblRaceBonusAttributes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            AcceptButton = btnNewCharacter;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitApplication;
            ClientSize = new Size(1037, 635);
            Controls.Add(btnRaceDescription);
            Controls.Add(btnClassDescription);
            Controls.Add(lblExperiencePoints);
            Controls.Add(btnDeleteCharacter);
            Controls.Add(btnPreviousPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnEditCharacter);
            Controls.Add(btnViewAttributes);
            Controls.Add(lblSpeed);
            Controls.Add(lblHitPoints);
            Controls.Add(lblInitiative);
            Controls.Add(lblArmourClass);
            Controls.Add(lblGender);
            Controls.Add(lblAlignment);
            Controls.Add(lblRaceBonusAttributes);
            Controls.Add(lblClassHPDice);
            Controls.Add(lblRace);
            Controls.Add(lblClass);
            Controls.Add(btnNewCharacter);
            Controls.Add(btnExitApplication);
            Controls.Add(lblLevel);
            Controls.Add(lblCharacterStatsHeader);
            Controls.Add(pbxMainBackground);
            MaximumSize = new Size(1053, 674);
            MinimumSize = new Size(1053, 674);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "D&D: Character View";
            Activated += LoadCharacterPanelsByPage;
            FormClosed += frmMain_FormClosed;
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)pbxMainBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxMainBackground;
        private Label lblCharacterStatsHeader;
        private Label lblLevel;
        private Button btnExitApplication;
        private Button btnNewCharacter;
        private Label lblClass;
        private Label lblRace;
        private Label lblClassHPDice;
        private Label lblAlignment;
        private Label lblGender;
        private Label lblArmourClass;
        private Label lblInitiative;
        private Label lblHitPoints;
        private Label lblSpeed;
        private Button btnViewAttributes;
        private Button btnEditCharacter;
        private Button btnNextPage;
        private Button btnPreviousPage;
        private Button btnDeleteCharacter;
        private Label lblExperiencePoints;
        private Button btnClassDescription;
        private Button btnRaceDescription;
        private Label lblRaceBonusAttributes;
        private ToolTip CharacterViewToolTips;
    }
}