namespace Assignment3
{ 
    partial class frmCharacterEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharacterEditor));
            pbxCharacterEditorBackground = new PictureBox();
            lblRemainingPoints = new Label();
            lblNameTag = new Label();
            tbxName = new TextBox();
            lblGenderTag = new Label();
            cbxGender = new ComboBox();
            nudArmourClass = new NumericUpDown();
            lblArmourClassTag = new Label();
            lblXPTag = new Label();
            nudXP = new NumericUpDown();
            lblClassTag = new Label();
            cbxClass = new ComboBox();
            cbxRace = new ComboBox();
            lblRaceTag = new Label();
            lblAlignmentTag = new Label();
            cbxAlignment = new ComboBox();
            lblStrengthDigitTwo = new Label();
            lblStrength = new Label();
            lblStrengthDigitOne = new Label();
            lblCharismaDigitOne = new Label();
            lblCharisma = new Label();
            lblCharismaDigitTwo = new Label();
            lblWisdomDigitOne = new Label();
            lblWisdom = new Label();
            lblWisdomDigitTwo = new Label();
            lblIntelligenceDigitOne = new Label();
            lblIntelligence = new Label();
            lblIntelligenceDigitTwo = new Label();
            lblConstitutionDigitOne = new Label();
            lblConstitution = new Label();
            lblConstitutionDigitTwo = new Label();
            lblDexterityDigitOne = new Label();
            lblDexterity = new Label();
            lblDexterityDigitTwo = new Label();
            btnIncreaseStrength = new Button();
            btnDecreaseStrength = new Button();
            btnDecreaseCharisma = new Button();
            btnIncreaseCharisma = new Button();
            btnDecreaseWisdom = new Button();
            btnIncreaseWisdom = new Button();
            btnDecreaseIntelligence = new Button();
            btnIncreaseIntelligence = new Button();
            btnDecreaseConstitution = new Button();
            btnIncreaseConstitution = new Button();
            btnDecreaseDexterity = new Button();
            btnIncreaseDexterity = new Button();
            lblCharacterSummary = new Label();
            btnCancel = new Button();
            btnSaveCharacter = new Button();
            btnRandomize = new Button();
            btnSaveAttributes = new Button();
            lblBonusPointDisclaimer = new Label();
            lblLevelTag = new Label();
            lblHPTag = new Label();
            lblInitiativeTag = new Label();
            lblSpeedTag = new Label();
            lblLevel = new Label();
            lblHP = new Label();
            lblSpeed = new Label();
            lblInitiative = new Label();
            CharacterEditToolTIps = new ToolTip(components);
            lblRaceBonus = new Label();
            lblGenderBonus = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxCharacterEditorBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudArmourClass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudXP).BeginInit();
            SuspendLayout();
            // 
            // pbxCharacterEditorBackground
            // 
            pbxCharacterEditorBackground.Image = Properties.Resources.CharacterEditorFormBackgroundV1;
            pbxCharacterEditorBackground.Location = new Point(-1, -3);
            pbxCharacterEditorBackground.Name = "pbxCharacterEditorBackground";
            pbxCharacterEditorBackground.Size = new Size(1042, 642);
            pbxCharacterEditorBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCharacterEditorBackground.TabIndex = 0;
            pbxCharacterEditorBackground.TabStop = false;
            // 
            // lblRemainingPoints
            // 
            lblRemainingPoints.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRemainingPoints.Location = new Point(830, 289);
            lblRemainingPoints.Name = "lblRemainingPoints";
            lblRemainingPoints.Size = new Size(179, 25);
            lblRemainingPoints.TabIndex = 1;
            lblRemainingPoints.Text = "Points Remaining: 27";
            lblRemainingPoints.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNameTag
            // 
            lblNameTag.BackColor = Color.FromArgb(13, 13, 13);
            lblNameTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNameTag.ForeColor = Color.White;
            lblNameTag.Location = new Point(36, 134);
            lblNameTag.Name = "lblNameTag";
            lblNameTag.Size = new Size(47, 23);
            lblNameTag.TabIndex = 2;
            lblNameTag.Text = "Name:";
            lblNameTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxName
            // 
            tbxName.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxName.Location = new Point(36, 160);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(105, 23);
            tbxName.TabIndex = 0;
            CharacterEditToolTIps.SetToolTip(tbxName, "Click here, or navigate to tab index 0 to enter name");
            tbxName.TextChanged += DetailControl_Change;
            // 
            // lblGenderTag
            // 
            lblGenderTag.BackColor = Color.FromArgb(13, 13, 13);
            lblGenderTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenderTag.ForeColor = Color.White;
            lblGenderTag.Location = new Point(163, 134);
            lblGenderTag.Name = "lblGenderTag";
            lblGenderTag.Size = new Size(59, 23);
            lblGenderTag.TabIndex = 4;
            lblGenderTag.Text = "Gender:";
            lblGenderTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbxGender
            // 
            cbxGender.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxGender.FormattingEnabled = true;
            cbxGender.Location = new Point(163, 160);
            cbxGender.Name = "cbxGender";
            cbxGender.Size = new Size(108, 22);
            cbxGender.TabIndex = 1;
            CharacterEditToolTIps.SetToolTip(cbxGender, "Tap here, or navigate to tab index 1 to begin entering gender");
            cbxGender.TextChanged += DetailControl_Change;
            // 
            // nudArmourClass
            // 
            nudArmourClass.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudArmourClass.Location = new Point(36, 221);
            nudArmourClass.Maximum = new decimal(new int[] { 36, 0, 0, 0 });
            nudArmourClass.Name = "nudArmourClass";
            nudArmourClass.Size = new Size(105, 23);
            nudArmourClass.TabIndex = 2;
            CharacterEditToolTIps.SetToolTip(nudArmourClass, "Tap here, or navigate to tab index 2 to begin entering armour class");
            nudArmourClass.ValueChanged += DetailControl_Change;
            // 
            // lblArmourClassTag
            // 
            lblArmourClassTag.BackColor = Color.FromArgb(13, 13, 13);
            lblArmourClassTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArmourClassTag.ForeColor = Color.White;
            lblArmourClassTag.Location = new Point(36, 195);
            lblArmourClassTag.Name = "lblArmourClassTag";
            lblArmourClassTag.Size = new Size(105, 23);
            lblArmourClassTag.TabIndex = 7;
            lblArmourClassTag.Text = "Armour Class:";
            lblArmourClassTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblXPTag
            // 
            lblXPTag.BackColor = Color.FromArgb(13, 13, 13);
            lblXPTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblXPTag.ForeColor = Color.White;
            lblXPTag.Location = new Point(163, 195);
            lblXPTag.Name = "lblXPTag";
            lblXPTag.Size = new Size(76, 23);
            lblXPTag.TabIndex = 8;
            lblXPTag.Text = "XP To Add:";
            lblXPTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudXP
            // 
            nudXP.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudXP.Location = new Point(163, 221);
            nudXP.Maximum = new decimal(new int[] { 360000, 0, 0, 0 });
            nudXP.Name = "nudXP";
            nudXP.Size = new Size(105, 23);
            nudXP.TabIndex = 3;
            CharacterEditToolTIps.SetToolTip(nudXP, "Tap here, or navigate to tab index 3 to begin entering xp");
            nudXP.ValueChanged += DetailControl_Change;
            // 
            // lblClassTag
            // 
            lblClassTag.BackColor = Color.FromArgb(13, 13, 13);
            lblClassTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClassTag.ForeColor = Color.White;
            lblClassTag.Location = new Point(36, 258);
            lblClassTag.Name = "lblClassTag";
            lblClassTag.Size = new Size(55, 23);
            lblClassTag.TabIndex = 10;
            lblClassTag.Text = "Class:";
            lblClassTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbxClass
            // 
            cbxClass.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxClass.FormattingEnabled = true;
            cbxClass.Location = new Point(36, 284);
            cbxClass.Name = "cbxClass";
            cbxClass.Size = new Size(105, 22);
            cbxClass.TabIndex = 4;
            CharacterEditToolTIps.SetToolTip(cbxClass, "Tap here, or navigate to tab index 4 to begin entering class");
            cbxClass.TextChanged += DetailControl_Change;
            // 
            // cbxRace
            // 
            cbxRace.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxRace.FormattingEnabled = true;
            cbxRace.Location = new Point(163, 284);
            cbxRace.Name = "cbxRace";
            cbxRace.Size = new Size(105, 22);
            cbxRace.TabIndex = 5;
            CharacterEditToolTIps.SetToolTip(cbxRace, "Tap here, or navigate to tab index 5 to begin entering race");
            cbxRace.TextChanged += DetailControl_Change;
            // 
            // lblRaceTag
            // 
            lblRaceTag.BackColor = Color.FromArgb(13, 13, 13);
            lblRaceTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRaceTag.ForeColor = Color.White;
            lblRaceTag.Location = new Point(163, 258);
            lblRaceTag.Name = "lblRaceTag";
            lblRaceTag.Size = new Size(44, 23);
            lblRaceTag.TabIndex = 12;
            lblRaceTag.Text = "Race:";
            lblRaceTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlignmentTag
            // 
            lblAlignmentTag.BackColor = Color.FromArgb(13, 13, 13);
            lblAlignmentTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAlignmentTag.ForeColor = Color.White;
            lblAlignmentTag.Location = new Point(289, 258);
            lblAlignmentTag.Name = "lblAlignmentTag";
            lblAlignmentTag.Size = new Size(82, 23);
            lblAlignmentTag.TabIndex = 14;
            lblAlignmentTag.Text = "Alignment:";
            lblAlignmentTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbxAlignment
            // 
            cbxAlignment.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxAlignment.FormattingEnabled = true;
            cbxAlignment.Location = new Point(289, 284);
            cbxAlignment.Name = "cbxAlignment";
            cbxAlignment.Size = new Size(105, 22);
            cbxAlignment.TabIndex = 6;
            CharacterEditToolTIps.SetToolTip(cbxAlignment, "Tap here, or navigate to tab index 6 to begin entering alignment");
            cbxAlignment.TextChanged += DetailControl_Change;
            // 
            // lblStrengthDigitTwo
            // 
            lblStrengthDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStrengthDigitTwo.Image = Properties.Resources.CharacterCreatorButton;
            lblStrengthDigitTwo.Location = new Point(629, 126);
            lblStrengthDigitTwo.Name = "lblStrengthDigitTwo";
            lblStrengthDigitTwo.Size = new Size(28, 22);
            lblStrengthDigitTwo.TabIndex = 17;
            lblStrengthDigitTwo.Text = "0";
            lblStrengthDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStrength
            // 
            lblStrength.BackColor = Color.FromArgb(13, 13, 13);
            lblStrength.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStrength.ForeColor = Color.White;
            lblStrength.Location = new Point(547, 126);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(76, 22);
            lblStrength.TabIndex = 18;
            lblStrength.Text = "STR";
            lblStrength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStrengthDigitOne
            // 
            lblStrengthDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStrengthDigitOne.Image = Properties.Resources.CharacterCreatorButton;
            lblStrengthDigitOne.Location = new Point(658, 126);
            lblStrengthDigitOne.Name = "lblStrengthDigitOne";
            lblStrengthDigitOne.Size = new Size(28, 22);
            lblStrengthDigitOne.TabIndex = 19;
            lblStrengthDigitOne.Text = "8";
            lblStrengthDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCharismaDigitOne
            // 
            lblCharismaDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCharismaDigitOne.Image = Properties.Resources.CharacterCreatorButton;
            lblCharismaDigitOne.Location = new Point(658, 275);
            lblCharismaDigitOne.Name = "lblCharismaDigitOne";
            lblCharismaDigitOne.Size = new Size(28, 22);
            lblCharismaDigitOne.TabIndex = 22;
            lblCharismaDigitOne.Text = "8";
            lblCharismaDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCharisma
            // 
            lblCharisma.BackColor = Color.FromArgb(13, 13, 13);
            lblCharisma.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCharisma.ForeColor = Color.White;
            lblCharisma.Location = new Point(547, 275);
            lblCharisma.Name = "lblCharisma";
            lblCharisma.Size = new Size(76, 22);
            lblCharisma.TabIndex = 21;
            lblCharisma.Text = "CHA";
            lblCharisma.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCharismaDigitTwo
            // 
            lblCharismaDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCharismaDigitTwo.Image = Properties.Resources.CharacterCreatorButton;
            lblCharismaDigitTwo.Location = new Point(629, 275);
            lblCharismaDigitTwo.Name = "lblCharismaDigitTwo";
            lblCharismaDigitTwo.Size = new Size(28, 22);
            lblCharismaDigitTwo.TabIndex = 20;
            lblCharismaDigitTwo.Text = "0";
            lblCharismaDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWisdomDigitOne
            // 
            lblWisdomDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWisdomDigitOne.Image = Properties.Resources.CharacterCreatorButton;
            lblWisdomDigitOne.Location = new Point(658, 245);
            lblWisdomDigitOne.Name = "lblWisdomDigitOne";
            lblWisdomDigitOne.Size = new Size(28, 22);
            lblWisdomDigitOne.TabIndex = 25;
            lblWisdomDigitOne.Text = "8";
            lblWisdomDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWisdom
            // 
            lblWisdom.BackColor = Color.FromArgb(13, 13, 13);
            lblWisdom.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWisdom.ForeColor = Color.White;
            lblWisdom.Location = new Point(547, 245);
            lblWisdom.Name = "lblWisdom";
            lblWisdom.Size = new Size(76, 22);
            lblWisdom.TabIndex = 24;
            lblWisdom.Text = "WIS";
            lblWisdom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWisdomDigitTwo
            // 
            lblWisdomDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWisdomDigitTwo.Image = Properties.Resources.CharacterCreatorButton;
            lblWisdomDigitTwo.Location = new Point(629, 245);
            lblWisdomDigitTwo.Name = "lblWisdomDigitTwo";
            lblWisdomDigitTwo.Size = new Size(28, 22);
            lblWisdomDigitTwo.TabIndex = 23;
            lblWisdomDigitTwo.Text = "0";
            lblWisdomDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIntelligenceDigitOne
            // 
            lblIntelligenceDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIntelligenceDigitOne.Image = Properties.Resources.CharacterCreatorButton;
            lblIntelligenceDigitOne.Location = new Point(658, 215);
            lblIntelligenceDigitOne.Name = "lblIntelligenceDigitOne";
            lblIntelligenceDigitOne.Size = new Size(28, 22);
            lblIntelligenceDigitOne.TabIndex = 28;
            lblIntelligenceDigitOne.Text = "8";
            lblIntelligenceDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIntelligence
            // 
            lblIntelligence.BackColor = Color.FromArgb(13, 13, 13);
            lblIntelligence.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIntelligence.ForeColor = Color.White;
            lblIntelligence.Location = new Point(547, 215);
            lblIntelligence.Name = "lblIntelligence";
            lblIntelligence.Size = new Size(76, 22);
            lblIntelligence.TabIndex = 27;
            lblIntelligence.Text = "INT";
            lblIntelligence.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIntelligenceDigitTwo
            // 
            lblIntelligenceDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIntelligenceDigitTwo.Image = Properties.Resources.CharacterCreatorButton;
            lblIntelligenceDigitTwo.Location = new Point(629, 215);
            lblIntelligenceDigitTwo.Name = "lblIntelligenceDigitTwo";
            lblIntelligenceDigitTwo.Size = new Size(28, 22);
            lblIntelligenceDigitTwo.TabIndex = 26;
            lblIntelligenceDigitTwo.Text = "0";
            lblIntelligenceDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConstitutionDigitOne
            // 
            lblConstitutionDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConstitutionDigitOne.Image = Properties.Resources.CharacterCreatorButton;
            lblConstitutionDigitOne.Location = new Point(658, 185);
            lblConstitutionDigitOne.Name = "lblConstitutionDigitOne";
            lblConstitutionDigitOne.Size = new Size(28, 22);
            lblConstitutionDigitOne.TabIndex = 31;
            lblConstitutionDigitOne.Text = "8";
            lblConstitutionDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConstitution
            // 
            lblConstitution.BackColor = Color.FromArgb(13, 13, 13);
            lblConstitution.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConstitution.ForeColor = Color.White;
            lblConstitution.Location = new Point(547, 185);
            lblConstitution.Name = "lblConstitution";
            lblConstitution.Size = new Size(76, 22);
            lblConstitution.TabIndex = 30;
            lblConstitution.Text = "CON";
            lblConstitution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConstitutionDigitTwo
            // 
            lblConstitutionDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConstitutionDigitTwo.Image = Properties.Resources.CharacterCreatorButton;
            lblConstitutionDigitTwo.Location = new Point(629, 185);
            lblConstitutionDigitTwo.Name = "lblConstitutionDigitTwo";
            lblConstitutionDigitTwo.Size = new Size(28, 22);
            lblConstitutionDigitTwo.TabIndex = 29;
            lblConstitutionDigitTwo.Text = "0";
            lblConstitutionDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDexterityDigitOne
            // 
            lblDexterityDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDexterityDigitOne.Image = Properties.Resources.CharacterCreatorButton;
            lblDexterityDigitOne.Location = new Point(658, 155);
            lblDexterityDigitOne.Name = "lblDexterityDigitOne";
            lblDexterityDigitOne.Size = new Size(28, 22);
            lblDexterityDigitOne.TabIndex = 34;
            lblDexterityDigitOne.Text = "8";
            lblDexterityDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDexterity
            // 
            lblDexterity.BackColor = Color.FromArgb(13, 13, 13);
            lblDexterity.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDexterity.ForeColor = Color.White;
            lblDexterity.Location = new Point(547, 155);
            lblDexterity.Name = "lblDexterity";
            lblDexterity.Size = new Size(76, 22);
            lblDexterity.TabIndex = 33;
            lblDexterity.Text = "DEX";
            lblDexterity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDexterityDigitTwo
            // 
            lblDexterityDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDexterityDigitTwo.Image = Properties.Resources.CharacterCreatorButton;
            lblDexterityDigitTwo.Location = new Point(629, 155);
            lblDexterityDigitTwo.Name = "lblDexterityDigitTwo";
            lblDexterityDigitTwo.Size = new Size(28, 22);
            lblDexterityDigitTwo.TabIndex = 32;
            lblDexterityDigitTwo.Text = "0";
            lblDexterityDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnIncreaseStrength
            // 
            btnIncreaseStrength.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseStrength.Location = new Point(711, 124);
            btnIncreaseStrength.Name = "btnIncreaseStrength";
            btnIncreaseStrength.Size = new Size(17, 24);
            btnIncreaseStrength.TabIndex = 9;
            btnIncreaseStrength.Text = "+";
            CharacterEditToolTIps.SetToolTip(btnIncreaseStrength, "Click here, or navigate to tab index 9 to increase strength.");
            btnIncreaseStrength.UseVisualStyleBackColor = true;
            btnIncreaseStrength.Click += AttributeControl_Change;
            // 
            // btnDecreaseStrength
            // 
            btnDecreaseStrength.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseStrength.Location = new Point(692, 124);
            btnDecreaseStrength.Name = "btnDecreaseStrength";
            btnDecreaseStrength.Size = new Size(17, 24);
            btnDecreaseStrength.TabIndex = 8;
            btnDecreaseStrength.Text = "-";
            CharacterEditToolTIps.SetToolTip(btnDecreaseStrength, "Click here, or navigate to tab index 8 to decrease strength.");
            btnDecreaseStrength.UseVisualStyleBackColor = true;
            btnDecreaseStrength.Click += AttributeControl_Change;
            // 
            // btnDecreaseCharisma
            // 
            btnDecreaseCharisma.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseCharisma.Location = new Point(692, 273);
            btnDecreaseCharisma.Name = "btnDecreaseCharisma";
            btnDecreaseCharisma.Size = new Size(17, 24);
            btnDecreaseCharisma.TabIndex = 18;
            btnDecreaseCharisma.Text = "-";
            CharacterEditToolTIps.SetToolTip(btnDecreaseCharisma, "Click here, or navigate to tab index 18 to decrease charisma.");
            btnDecreaseCharisma.UseVisualStyleBackColor = true;
            btnDecreaseCharisma.Click += AttributeControl_Change;
            // 
            // btnIncreaseCharisma
            // 
            btnIncreaseCharisma.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseCharisma.Location = new Point(711, 273);
            btnIncreaseCharisma.Name = "btnIncreaseCharisma";
            btnIncreaseCharisma.Size = new Size(17, 24);
            btnIncreaseCharisma.TabIndex = 19;
            btnIncreaseCharisma.Text = "+";
            CharacterEditToolTIps.SetToolTip(btnIncreaseCharisma, "Click here, or navigate to tab index 19 to increase charisma.");
            btnIncreaseCharisma.UseVisualStyleBackColor = true;
            btnIncreaseCharisma.Click += AttributeControl_Change;
            // 
            // btnDecreaseWisdom
            // 
            btnDecreaseWisdom.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseWisdom.Location = new Point(692, 243);
            btnDecreaseWisdom.Name = "btnDecreaseWisdom";
            btnDecreaseWisdom.Size = new Size(17, 24);
            btnDecreaseWisdom.TabIndex = 16;
            btnDecreaseWisdom.Text = "-";
            CharacterEditToolTIps.SetToolTip(btnDecreaseWisdom, "Click here, or navigate to tab index 16 to decrease wisdom.");
            btnDecreaseWisdom.UseVisualStyleBackColor = true;
            btnDecreaseWisdom.Click += AttributeControl_Change;
            // 
            // btnIncreaseWisdom
            // 
            btnIncreaseWisdom.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseWisdom.Location = new Point(711, 243);
            btnIncreaseWisdom.Name = "btnIncreaseWisdom";
            btnIncreaseWisdom.Size = new Size(17, 24);
            btnIncreaseWisdom.TabIndex = 17;
            btnIncreaseWisdom.Text = "+";
            CharacterEditToolTIps.SetToolTip(btnIncreaseWisdom, "Click here, or navigate to tab index 17 to increase wisdom.");
            btnIncreaseWisdom.UseVisualStyleBackColor = true;
            btnIncreaseWisdom.Click += AttributeControl_Change;
            // 
            // btnDecreaseIntelligence
            // 
            btnDecreaseIntelligence.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseIntelligence.Location = new Point(692, 213);
            btnDecreaseIntelligence.Name = "btnDecreaseIntelligence";
            btnDecreaseIntelligence.Size = new Size(17, 24);
            btnDecreaseIntelligence.TabIndex = 14;
            btnDecreaseIntelligence.Text = "-";
            CharacterEditToolTIps.SetToolTip(btnDecreaseIntelligence, "Click here, or navigate to tab index 14 to decrease intelligence");
            btnDecreaseIntelligence.UseVisualStyleBackColor = true;
            btnDecreaseIntelligence.Click += AttributeControl_Change;
            // 
            // btnIncreaseIntelligence
            // 
            btnIncreaseIntelligence.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseIntelligence.Location = new Point(711, 213);
            btnIncreaseIntelligence.Name = "btnIncreaseIntelligence";
            btnIncreaseIntelligence.Size = new Size(17, 24);
            btnIncreaseIntelligence.TabIndex = 15;
            btnIncreaseIntelligence.Text = "+";
            CharacterEditToolTIps.SetToolTip(btnIncreaseIntelligence, "Click here, or navigate to tab index 15 to increase intelligence.");
            btnIncreaseIntelligence.UseVisualStyleBackColor = true;
            btnIncreaseIntelligence.Click += AttributeControl_Change;
            // 
            // btnDecreaseConstitution
            // 
            btnDecreaseConstitution.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseConstitution.Location = new Point(692, 183);
            btnDecreaseConstitution.Name = "btnDecreaseConstitution";
            btnDecreaseConstitution.Size = new Size(17, 24);
            btnDecreaseConstitution.TabIndex = 12;
            btnDecreaseConstitution.Text = "-";
            CharacterEditToolTIps.SetToolTip(btnDecreaseConstitution, "Click here, or navigate to tab index 12 to decrease constitution.");
            btnDecreaseConstitution.UseVisualStyleBackColor = true;
            btnDecreaseConstitution.Click += AttributeControl_Change;
            // 
            // btnIncreaseConstitution
            // 
            btnIncreaseConstitution.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseConstitution.Location = new Point(711, 183);
            btnIncreaseConstitution.Name = "btnIncreaseConstitution";
            btnIncreaseConstitution.Size = new Size(17, 24);
            btnIncreaseConstitution.TabIndex = 13;
            btnIncreaseConstitution.Text = "+";
            CharacterEditToolTIps.SetToolTip(btnIncreaseConstitution, "Click here, or navigate to tab index 13 to increase constitution.");
            btnIncreaseConstitution.UseVisualStyleBackColor = true;
            btnIncreaseConstitution.Click += AttributeControl_Change;
            // 
            // btnDecreaseDexterity
            // 
            btnDecreaseDexterity.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseDexterity.Location = new Point(692, 153);
            btnDecreaseDexterity.Name = "btnDecreaseDexterity";
            btnDecreaseDexterity.Size = new Size(17, 24);
            btnDecreaseDexterity.TabIndex = 10;
            btnDecreaseDexterity.Text = "-";
            CharacterEditToolTIps.SetToolTip(btnDecreaseDexterity, "Click here, or navigate to tab index 10  to decrease dexterity");
            btnDecreaseDexterity.UseVisualStyleBackColor = true;
            btnDecreaseDexterity.Click += AttributeControl_Change;
            // 
            // btnIncreaseDexterity
            // 
            btnIncreaseDexterity.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseDexterity.Location = new Point(711, 153);
            btnIncreaseDexterity.Name = "btnIncreaseDexterity";
            btnIncreaseDexterity.Size = new Size(17, 24);
            btnIncreaseDexterity.TabIndex = 11;
            btnIncreaseDexterity.Text = "+";
            CharacterEditToolTIps.SetToolTip(btnIncreaseDexterity, "Click here, or navigate to tab index 11 to increase dexterity.");
            btnIncreaseDexterity.UseVisualStyleBackColor = true;
            btnIncreaseDexterity.Click += AttributeControl_Change;
            // 
            // lblCharacterSummary
            // 
            lblCharacterSummary.BackColor = Color.FromArgb(13, 13, 13);
            lblCharacterSummary.Font = new Font("Baskerville Old Face", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCharacterSummary.ForeColor = Color.Black;
            lblCharacterSummary.Image = Properties.Resources.GenericRuggedPaper;
            lblCharacterSummary.ImageAlign = ContentAlignment.MiddleLeft;
            lblCharacterSummary.Location = new Point(36, 412);
            lblCharacterSummary.Name = "lblCharacterSummary";
            lblCharacterSummary.Size = new Size(972, 84);
            lblCharacterSummary.TabIndex = 47;
            lblCharacterSummary.Text = resources.GetString("lblCharacterSummary.Text");
            lblCharacterSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            btnCancel.FlatAppearance.BorderSize = 3;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Image = Properties.Resources.GenericRuggedPaper;
            btnCancel.Location = new Point(364, 536);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(147, 40);
            btnCancel.TabIndex = 48;
            btnCancel.Text = "&Cancel";
            CharacterEditToolTIps.SetToolTip(btnCancel, "Click here, or press 'ALT + C' to cancel");
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btnGeneric_MouseEnter;
            btnCancel.MouseLeave += btnGeneric_MouseExit;
            // 
            // btnSaveCharacter
            // 
            btnSaveCharacter.FlatAppearance.BorderColor = Color.Black;
            btnSaveCharacter.FlatAppearance.BorderSize = 3;
            btnSaveCharacter.FlatStyle = FlatStyle.Flat;
            btnSaveCharacter.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveCharacter.ForeColor = Color.Black;
            btnSaveCharacter.Image = Properties.Resources.GenericRuggedPaper;
            btnSaveCharacter.Location = new Point(525, 536);
            btnSaveCharacter.Name = "btnSaveCharacter";
            btnSaveCharacter.Size = new Size(147, 40);
            btnSaveCharacter.TabIndex = 50;
            btnSaveCharacter.Text = "&Save && Exit";
            CharacterEditToolTIps.SetToolTip(btnSaveCharacter, "Click here, or press 'ALT + S' to save changes");
            btnSaveCharacter.UseVisualStyleBackColor = true;
            btnSaveCharacter.Click += btnSaveCharacter_Click;
            btnSaveCharacter.MouseEnter += btnGeneric_MouseEnter;
            btnSaveCharacter.MouseLeave += btnGeneric_MouseExit;
            // 
            // btnRandomize
            // 
            btnRandomize.FlatAppearance.BorderColor = Color.Black;
            btnRandomize.FlatAppearance.BorderSize = 2;
            btnRandomize.FlatStyle = FlatStyle.Flat;
            btnRandomize.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRandomize.ForeColor = Color.Black;
            btnRandomize.Image = Properties.Resources.GenericRuggedPaper;
            btnRandomize.Location = new Point(369, 91);
            btnRandomize.Name = "btnRandomize";
            btnRandomize.Size = new Size(127, 40);
            btnRandomize.TabIndex = 7;
            btnRandomize.Text = "&Randomize";
            CharacterEditToolTIps.SetToolTip(btnRandomize, "Click here, or press 'ALT + R' to randomize details");
            btnRandomize.UseVisualStyleBackColor = true;
            btnRandomize.Click += btnRandomize_Click;
            btnRandomize.MouseEnter += btnGeneric_MouseEnter;
            btnRandomize.MouseLeave += btnGeneric_MouseExit;
            // 
            // btnSaveAttributes
            // 
            btnSaveAttributes.FlatAppearance.BorderColor = Color.Black;
            btnSaveAttributes.FlatAppearance.BorderSize = 2;
            btnSaveAttributes.FlatStyle = FlatStyle.Flat;
            btnSaveAttributes.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveAttributes.ForeColor = Color.Black;
            btnSaveAttributes.Image = Properties.Resources.GenericRuggedPaper;
            btnSaveAttributes.Location = new Point(859, 92);
            btnSaveAttributes.Name = "btnSaveAttributes";
            btnSaveAttributes.Size = new Size(149, 40);
            btnSaveAttributes.TabIndex = 52;
            btnSaveAttributes.Text = "Save &Attributes";
            CharacterEditToolTIps.SetToolTip(btnSaveAttributes, "Click here, or press 'ALT + A' to save current attributes");
            btnSaveAttributes.UseVisualStyleBackColor = true;
            btnSaveAttributes.Click += btnSaveAttributes_Click;
            btnSaveAttributes.MouseEnter += btnGeneric_MouseEnter;
            btnSaveAttributes.MouseLeave += btnGeneric_MouseExit;
            // 
            // lblBonusPointDisclaimer
            // 
            lblBonusPointDisclaimer.Font = new Font("Baskerville Old Face", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBonusPointDisclaimer.Image = Properties.Resources.GenericRuggedPaper;
            lblBonusPointDisclaimer.Location = new Point(741, 145);
            lblBonusPointDisclaimer.Name = "lblBonusPointDisclaimer";
            lblBonusPointDisclaimer.Size = new Size(267, 73);
            lblBonusPointDisclaimer.TabIndex = 53;
            lblBonusPointDisclaimer.Text = "To apply race and gender bonus points, all points must be spent and attributes must be saved.\r\nSaving attributes with all points spent will disable point decreasing.";
            // 
            // lblLevelTag
            // 
            lblLevelTag.BackColor = Color.FromArgb(13, 13, 13);
            lblLevelTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLevelTag.ForeColor = Color.White;
            lblLevelTag.Location = new Point(786, 228);
            lblLevelTag.Name = "lblLevelTag";
            lblLevelTag.Size = new Size(49, 23);
            lblLevelTag.TabIndex = 54;
            lblLevelTag.Text = "Level:";
            lblLevelTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHPTag
            // 
            lblHPTag.BackColor = Color.FromArgb(13, 13, 13);
            lblHPTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHPTag.ForeColor = Color.White;
            lblHPTag.Location = new Point(841, 228);
            lblHPTag.Name = "lblHPTag";
            lblHPTag.Size = new Size(26, 23);
            lblHPTag.TabIndex = 55;
            lblHPTag.Text = "HP:";
            lblHPTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInitiativeTag
            // 
            lblInitiativeTag.BackColor = Color.FromArgb(13, 13, 13);
            lblInitiativeTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInitiativeTag.ForeColor = Color.White;
            lblInitiativeTag.Location = new Point(927, 228);
            lblInitiativeTag.Name = "lblInitiativeTag";
            lblInitiativeTag.Size = new Size(82, 23);
            lblInitiativeTag.TabIndex = 56;
            lblInitiativeTag.Text = "Initiative:";
            lblInitiativeTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSpeedTag
            // 
            lblSpeedTag.BackColor = Color.FromArgb(13, 13, 13);
            lblSpeedTag.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpeedTag.ForeColor = Color.White;
            lblSpeedTag.Location = new Point(873, 228);
            lblSpeedTag.Name = "lblSpeedTag";
            lblSpeedTag.Size = new Size(49, 23);
            lblSpeedTag.TabIndex = 57;
            lblSpeedTag.Text = "Speed:";
            lblSpeedTag.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLevel
            // 
            lblLevel.BackColor = Color.FromArgb(13, 13, 13);
            lblLevel.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = Color.Black;
            lblLevel.Image = Properties.Resources.CharacterCreatorButton;
            lblLevel.Location = new Point(786, 251);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(49, 23);
            lblLevel.TabIndex = 58;
            lblLevel.Text = "0";
            lblLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHP
            // 
            lblHP.BackColor = Color.FromArgb(13, 13, 13);
            lblHP.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHP.ForeColor = Color.Black;
            lblHP.Image = Properties.Resources.CharacterCreatorButton;
            lblHP.Location = new Point(841, 251);
            lblHP.Name = "lblHP";
            lblHP.Size = new Size(26, 23);
            lblHP.TabIndex = 59;
            lblHP.Text = "0";
            lblHP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpeed
            // 
            lblSpeed.BackColor = Color.FromArgb(13, 13, 13);
            lblSpeed.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpeed.ForeColor = Color.Black;
            lblSpeed.Image = Properties.Resources.CharacterCreatorButton;
            lblSpeed.Location = new Point(873, 251);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(48, 23);
            lblSpeed.TabIndex = 60;
            lblSpeed.Text = "0";
            lblSpeed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInitiative
            // 
            lblInitiative.BackColor = Color.FromArgb(13, 13, 13);
            lblInitiative.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInitiative.ForeColor = Color.Black;
            lblInitiative.Image = Properties.Resources.CharacterCreatorButton;
            lblInitiative.Location = new Point(927, 251);
            lblInitiative.Name = "lblInitiative";
            lblInitiative.Size = new Size(82, 23);
            lblInitiative.TabIndex = 61;
            lblInitiative.Text = "0";
            lblInitiative.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRaceBonus
            // 
            lblRaceBonus.Font = new Font("Baskerville Old Face", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRaceBonus.Image = Properties.Resources.GenericRuggedPaper;
            lblRaceBonus.Location = new Point(304, 139);
            lblRaceBonus.Name = "lblRaceBonus";
            lblRaceBonus.Size = new Size(191, 38);
            lblRaceBonus.TabIndex = 62;
            lblRaceBonus.Text = "Race Bonus: ";
            // 
            // lblGenderBonus
            // 
            lblGenderBonus.Font = new Font("Baskerville Old Face", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenderBonus.Image = Properties.Resources.GenericRuggedPaper;
            lblGenderBonus.Location = new Point(304, 183);
            lblGenderBonus.Name = "lblGenderBonus";
            lblGenderBonus.Size = new Size(191, 38);
            lblGenderBonus.TabIndex = 63;
            lblGenderBonus.Text = "Gender Bonus:";
            // 
            // frmCharacterEditor
            // 
            AcceptButton = btnSaveCharacter;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(1037, 635);
            Controls.Add(lblGenderBonus);
            Controls.Add(lblRaceBonus);
            Controls.Add(lblInitiative);
            Controls.Add(lblSpeed);
            Controls.Add(lblHP);
            Controls.Add(lblLevel);
            Controls.Add(lblSpeedTag);
            Controls.Add(lblInitiativeTag);
            Controls.Add(lblHPTag);
            Controls.Add(lblLevelTag);
            Controls.Add(lblBonusPointDisclaimer);
            Controls.Add(btnSaveAttributes);
            Controls.Add(btnRandomize);
            Controls.Add(btnSaveCharacter);
            Controls.Add(btnCancel);
            Controls.Add(lblCharacterSummary);
            Controls.Add(btnDecreaseDexterity);
            Controls.Add(btnIncreaseDexterity);
            Controls.Add(btnDecreaseConstitution);
            Controls.Add(btnIncreaseConstitution);
            Controls.Add(btnDecreaseIntelligence);
            Controls.Add(btnIncreaseIntelligence);
            Controls.Add(btnDecreaseWisdom);
            Controls.Add(btnIncreaseWisdom);
            Controls.Add(btnDecreaseCharisma);
            Controls.Add(btnIncreaseCharisma);
            Controls.Add(btnDecreaseStrength);
            Controls.Add(btnIncreaseStrength);
            Controls.Add(lblDexterityDigitOne);
            Controls.Add(lblDexterity);
            Controls.Add(lblDexterityDigitTwo);
            Controls.Add(lblConstitutionDigitOne);
            Controls.Add(lblConstitution);
            Controls.Add(lblConstitutionDigitTwo);
            Controls.Add(lblIntelligenceDigitOne);
            Controls.Add(lblIntelligence);
            Controls.Add(lblIntelligenceDigitTwo);
            Controls.Add(lblWisdomDigitOne);
            Controls.Add(lblWisdom);
            Controls.Add(lblWisdomDigitTwo);
            Controls.Add(lblCharismaDigitOne);
            Controls.Add(lblCharisma);
            Controls.Add(lblCharismaDigitTwo);
            Controls.Add(lblStrengthDigitOne);
            Controls.Add(lblStrength);
            Controls.Add(lblStrengthDigitTwo);
            Controls.Add(cbxAlignment);
            Controls.Add(lblAlignmentTag);
            Controls.Add(cbxRace);
            Controls.Add(lblRaceTag);
            Controls.Add(cbxClass);
            Controls.Add(lblClassTag);
            Controls.Add(nudXP);
            Controls.Add(lblXPTag);
            Controls.Add(lblArmourClassTag);
            Controls.Add(nudArmourClass);
            Controls.Add(cbxGender);
            Controls.Add(lblGenderTag);
            Controls.Add(tbxName);
            Controls.Add(lblNameTag);
            Controls.Add(lblRemainingPoints);
            Controls.Add(pbxCharacterEditorBackground);
            MaximumSize = new Size(1053, 674);
            MinimumSize = new Size(1053, 674);
            Name = "frmCharacterEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "D&D: Edit Character";
            Load += frmCharacterEditor_Load;
            ((System.ComponentModel.ISupportInitialize)pbxCharacterEditorBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudArmourClass).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudXP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxCharacterEditorBackground;
        private Label lblRemainingPoints;
        private Label lblNameTag;
        private TextBox tbxName;
        private Label lblGenderTag;
        private ComboBox cbxGender;
        private NumericUpDown nudArmourClass;
        private Label lblArmourClassTag;
        private Label lblXPTag;
        private NumericUpDown nudXP;
        private Label lblClassTag;
        private ComboBox cbxClass;
        private ComboBox cbxRace;
        private Label lblRaceTag;
        private Label lblAlignmentTag;
        private ComboBox cbxAlignment;
        private Label lblStrengthDigitTwo;
        private Label lblStrength;
        private Label lblStrengthDigitOne;
        private Label lblCharismaDigitOne;
        private Label lblCharisma;
        private Label lblCharismaDigitTwo;
        private Label lblWisdomDigitOne;
        private Label lblWisdom;
        private Label lblWisdomDigitTwo;
        private Label lblIntelligenceDigitOne;
        private Label lblIntelligence;
        private Label lblIntelligenceDigitTwo;
        private Label lblConstitutionDigitOne;
        private Label lblConstitution;
        private Label lblConstitutionDigitTwo;
        private Label lblDexterityDigitOne;
        private Label lblDexterity;
        private Label lblDexterityDigitTwo;
        private Button btnIncreaseStrength;
        private Button btnDecreaseStrength;
        private Button btnDecreaseCharisma;
        private Button btnIncreaseCharisma;
        private Button btnDecreaseWisdom;
        private Button btnIncreaseWisdom;
        private Button btnDecreaseIntelligence;
        private Button btnIncreaseIntelligence;
        private Button btnDecreaseConstitution;
        private Button btnIncreaseConstitution;
        private Button btnDecreaseDexterity;
        private Button btnIncreaseDexterity;
        private Label lblCharacterSummary;
        private Button btnCancel;
        private Button btnSaveCharacter;
        private Button btnRandomize;
        private Button btnSaveAttributes;
        private Label lblBonusPointDisclaimer;
        private Label lblLevelTag;
        private Label lblHPTag;
        private Label lblInitiativeTag;
        private Label lblSpeedTag;
        private Label lblLevel;
        private Label lblHP;
        private Label lblSpeed;
        private Label lblInitiative;
        private ToolTip CharacterEditToolTIps;
        private Label lblRaceBonus;
        private Label lblGenderBonus;
    }
}