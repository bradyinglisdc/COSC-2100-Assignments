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
            lblRemainingPoints.Location = new Point(829, 289);
            lblRemainingPoints.Name = "lblRemainingPoints";
            lblRemainingPoints.Size = new Size(183, 25);
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
            cbxClass.FormattingEnabled = true;
            cbxClass.Location = new Point(36, 284);
            cbxClass.Name = "cbxClass";
            cbxClass.Size = new Size(105, 23);
            cbxClass.TabIndex = 11;
            // 
            // cbxRace
            // 
            cbxRace.FormattingEnabled = true;
            cbxRace.Location = new Point(163, 284);
            cbxRace.Name = "cbxRace";
            cbxRace.Size = new Size(105, 23);
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
            // frmCharacterEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 635);
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
    }
}