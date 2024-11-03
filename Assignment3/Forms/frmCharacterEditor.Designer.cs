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
            lblWisdonDigitOne = new Label();
            lblWisdom = new Label();
            lblWisdonDigitTwo = new Label();
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
            lblRemainingPoints.Text = "Points Remaining: 13";
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
            tbxName.TabIndex = 3;
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
            cbxGender.DisplayMember = "Male";
            cbxGender.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxGender.FormattingEnabled = true;
            cbxGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cbxGender.Location = new Point(163, 160);
            cbxGender.Name = "cbxGender";
            cbxGender.Size = new Size(108, 22);
            cbxGender.TabIndex = 5;
            // 
            // nudArmourClass
            // 
            nudArmourClass.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudArmourClass.Location = new Point(36, 221);
            nudArmourClass.Maximum = new decimal(new int[] { 36, 0, 0, 0 });
            nudArmourClass.Name = "nudArmourClass";
            nudArmourClass.Size = new Size(105, 23);
            nudArmourClass.TabIndex = 6;
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
            nudXP.Maximum = new decimal(new int[] { 36, 0, 0, 0 });
            nudXP.Name = "nudXP";
            nudXP.Size = new Size(105, 23);
            nudXP.TabIndex = 9;
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
            cbxClass.TabIndex = 11;
            // 
            // cbxRace
            // 
            cbxRace.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxRace.FormattingEnabled = true;
            cbxRace.Location = new Point(163, 284);
            cbxRace.Name = "cbxRace";
            cbxRace.Size = new Size(105, 22);
            cbxRace.TabIndex = 13;
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
            cbxAlignment.TabIndex = 15;
            // 
            // lblStrengthDigitTwo
            // 
            lblStrengthDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblStrengthDigitOne.Location = new Point(658, 126);
            lblStrengthDigitOne.Name = "lblStrengthDigitOne";
            lblStrengthDigitOne.Size = new Size(28, 22);
            lblStrengthDigitOne.TabIndex = 19;
            lblStrengthDigitOne.Text = "0";
            lblStrengthDigitOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCharismaDigitOne
            // 
            lblCharismaDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCharismaDigitOne.Location = new Point(658, 275);
            lblCharismaDigitOne.Name = "lblCharismaDigitOne";
            lblCharismaDigitOne.Size = new Size(28, 22);
            lblCharismaDigitOne.TabIndex = 22;
            lblCharismaDigitOne.Text = "0";
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
            lblCharismaDigitTwo.Location = new Point(629, 275);
            lblCharismaDigitTwo.Name = "lblCharismaDigitTwo";
            lblCharismaDigitTwo.Size = new Size(28, 22);
            lblCharismaDigitTwo.TabIndex = 20;
            lblCharismaDigitTwo.Text = "0";
            lblCharismaDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWisdonDigitOne
            // 
            lblWisdonDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWisdonDigitOne.Location = new Point(658, 245);
            lblWisdonDigitOne.Name = "lblWisdonDigitOne";
            lblWisdonDigitOne.Size = new Size(28, 22);
            lblWisdonDigitOne.TabIndex = 25;
            lblWisdonDigitOne.Text = "0";
            lblWisdonDigitOne.TextAlign = ContentAlignment.MiddleCenter;
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
            // lblWisdonDigitTwo
            // 
            lblWisdonDigitTwo.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWisdonDigitTwo.Location = new Point(629, 245);
            lblWisdonDigitTwo.Name = "lblWisdonDigitTwo";
            lblWisdonDigitTwo.Size = new Size(28, 22);
            lblWisdonDigitTwo.TabIndex = 23;
            lblWisdonDigitTwo.Text = "0";
            lblWisdonDigitTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIntelligenceDigitOne
            // 
            lblIntelligenceDigitOne.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIntelligenceDigitOne.Location = new Point(658, 215);
            lblIntelligenceDigitOne.Name = "lblIntelligenceDigitOne";
            lblIntelligenceDigitOne.Size = new Size(28, 22);
            lblIntelligenceDigitOne.TabIndex = 28;
            lblIntelligenceDigitOne.Text = "0";
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
            lblConstitutionDigitOne.Location = new Point(658, 185);
            lblConstitutionDigitOne.Name = "lblConstitutionDigitOne";
            lblConstitutionDigitOne.Size = new Size(28, 22);
            lblConstitutionDigitOne.TabIndex = 31;
            lblConstitutionDigitOne.Text = "0";
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
            lblDexterityDigitOne.Location = new Point(658, 155);
            lblDexterityDigitOne.Name = "lblDexterityDigitOne";
            lblDexterityDigitOne.Size = new Size(28, 22);
            lblDexterityDigitOne.TabIndex = 34;
            lblDexterityDigitOne.Text = "0";
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
            btnIncreaseStrength.TabIndex = 35;
            btnIncreaseStrength.Text = "+";
            btnIncreaseStrength.UseVisualStyleBackColor = true;
            // 
            // btnDecreaseStrength
            // 
            btnDecreaseStrength.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseStrength.Location = new Point(692, 124);
            btnDecreaseStrength.Name = "btnDecreaseStrength";
            btnDecreaseStrength.Size = new Size(17, 24);
            btnDecreaseStrength.TabIndex = 36;
            btnDecreaseStrength.Text = "-";
            btnDecreaseStrength.UseVisualStyleBackColor = true;
            // 
            // btnDecreaseCharisma
            // 
            btnDecreaseCharisma.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseCharisma.Location = new Point(692, 273);
            btnDecreaseCharisma.Name = "btnDecreaseCharisma";
            btnDecreaseCharisma.Size = new Size(17, 24);
            btnDecreaseCharisma.TabIndex = 38;
            btnDecreaseCharisma.Text = "-";
            btnDecreaseCharisma.UseVisualStyleBackColor = true;
            // 
            // btnIncreaseCharisma
            // 
            btnIncreaseCharisma.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseCharisma.Location = new Point(711, 273);
            btnIncreaseCharisma.Name = "btnIncreaseCharisma";
            btnIncreaseCharisma.Size = new Size(17, 24);
            btnIncreaseCharisma.TabIndex = 37;
            btnIncreaseCharisma.Text = "+";
            btnIncreaseCharisma.UseVisualStyleBackColor = true;
            // 
            // btnDecreaseWisdom
            // 
            btnDecreaseWisdom.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseWisdom.Location = new Point(692, 243);
            btnDecreaseWisdom.Name = "btnDecreaseWisdom";
            btnDecreaseWisdom.Size = new Size(17, 24);
            btnDecreaseWisdom.TabIndex = 40;
            btnDecreaseWisdom.Text = "-";
            btnDecreaseWisdom.UseVisualStyleBackColor = true;
            // 
            // btnIncreaseWisdom
            // 
            btnIncreaseWisdom.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseWisdom.Location = new Point(711, 243);
            btnIncreaseWisdom.Name = "btnIncreaseWisdom";
            btnIncreaseWisdom.Size = new Size(17, 24);
            btnIncreaseWisdom.TabIndex = 39;
            btnIncreaseWisdom.Text = "+";
            btnIncreaseWisdom.UseVisualStyleBackColor = true;
            // 
            // btnDecreaseIntelligence
            // 
            btnDecreaseIntelligence.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseIntelligence.Location = new Point(692, 213);
            btnDecreaseIntelligence.Name = "btnDecreaseIntelligence";
            btnDecreaseIntelligence.Size = new Size(17, 24);
            btnDecreaseIntelligence.TabIndex = 42;
            btnDecreaseIntelligence.Text = "-";
            btnDecreaseIntelligence.UseVisualStyleBackColor = true;
            // 
            // btnIncreaseIntelligence
            // 
            btnIncreaseIntelligence.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseIntelligence.Location = new Point(711, 213);
            btnIncreaseIntelligence.Name = "btnIncreaseIntelligence";
            btnIncreaseIntelligence.Size = new Size(17, 24);
            btnIncreaseIntelligence.TabIndex = 41;
            btnIncreaseIntelligence.Text = "+";
            btnIncreaseIntelligence.UseVisualStyleBackColor = true;
            // 
            // btnDecreaseConstitution
            // 
            btnDecreaseConstitution.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseConstitution.Location = new Point(692, 183);
            btnDecreaseConstitution.Name = "btnDecreaseConstitution";
            btnDecreaseConstitution.Size = new Size(17, 24);
            btnDecreaseConstitution.TabIndex = 44;
            btnDecreaseConstitution.Text = "-";
            btnDecreaseConstitution.UseVisualStyleBackColor = true;
            // 
            // btnIncreaseConstitution
            // 
            btnIncreaseConstitution.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseConstitution.Location = new Point(711, 183);
            btnIncreaseConstitution.Name = "btnIncreaseConstitution";
            btnIncreaseConstitution.Size = new Size(17, 24);
            btnIncreaseConstitution.TabIndex = 43;
            btnIncreaseConstitution.Text = "+";
            btnIncreaseConstitution.UseVisualStyleBackColor = true;
            // 
            // btnDecreaseDexterity
            // 
            btnDecreaseDexterity.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDecreaseDexterity.Location = new Point(692, 153);
            btnDecreaseDexterity.Name = "btnDecreaseDexterity";
            btnDecreaseDexterity.Size = new Size(17, 24);
            btnDecreaseDexterity.TabIndex = 46;
            btnDecreaseDexterity.Text = "-";
            btnDecreaseDexterity.UseVisualStyleBackColor = true;
            // 
            // btnIncreaseDexterity
            // 
            btnIncreaseDexterity.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncreaseDexterity.Location = new Point(711, 153);
            btnIncreaseDexterity.Name = "btnIncreaseDexterity";
            btnIncreaseDexterity.Size = new Size(17, 24);
            btnIncreaseDexterity.TabIndex = 45;
            btnIncreaseDexterity.Text = "+";
            btnIncreaseDexterity.UseVisualStyleBackColor = true;
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
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveCharacter
            // 
            btnSaveCharacter.FlatAppearance.BorderSize = 3;
            btnSaveCharacter.FlatStyle = FlatStyle.Flat;
            btnSaveCharacter.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveCharacter.ForeColor = Color.Black;
            btnSaveCharacter.Image = Properties.Resources.GenericRuggedPaper;
            btnSaveCharacter.Location = new Point(525, 536);
            btnSaveCharacter.Name = "btnSaveCharacter";
            btnSaveCharacter.Size = new Size(147, 40);
            btnSaveCharacter.TabIndex = 50;
            btnSaveCharacter.Text = "&Save Character";
            btnSaveCharacter.UseVisualStyleBackColor = true;
            // 
            // btnRandomize
            // 
            btnRandomize.FlatAppearance.BorderSize = 2;
            btnRandomize.FlatStyle = FlatStyle.Flat;
            btnRandomize.Font = new Font("Algerian", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRandomize.ForeColor = Color.Black;
            btnRandomize.Image = Properties.Resources.GenericRuggedPaper;
            btnRandomize.Location = new Point(369, 91);
            btnRandomize.Name = "btnRandomize";
            btnRandomize.Size = new Size(127, 40);
            btnRandomize.TabIndex = 51;
            btnRandomize.Text = "&Randomize";
            btnRandomize.UseVisualStyleBackColor = true;
            // 
            // frmCharacterEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 635);
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
            Controls.Add(lblWisdonDigitOne);
            Controls.Add(lblWisdom);
            Controls.Add(lblWisdonDigitTwo);
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
        private Label lblWisdonDigitOne;
        private Label lblWisdom;
        private Label lblWisdonDigitTwo;
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
    }
}