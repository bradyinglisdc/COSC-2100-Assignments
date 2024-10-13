namespace Assignment2
{
    partial class frmChangeDifficulty
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
            panel1 = new Panel();
            lblHeader = new Label();
            pnlDifficulties = new Panel();
            btnStartGame = new Button();
            btnExit = new Button();
            rbtnHard = new RadioButton();
            rbtnEasy = new RadioButton();
            ToolTips = new ToolTip(components);
            panel1.SuspendLayout();
            pnlDifficulties.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(lblHeader);
            panel1.Controls.Add(pnlDifficulties);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 171);
            panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.FromArgb(150, 150, 150);
            lblHeader.BorderStyle = BorderStyle.Fixed3D;
            lblHeader.Font = new Font("Impact", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(30, 20, 0);
            lblHeader.Location = new Point(82, 12);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(243, 36);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "CHOOSE A DIFFICULTY";
            // 
            // pnlDifficulties
            // 
            pnlDifficulties.BackColor = SystemColors.ActiveBorder;
            pnlDifficulties.BorderStyle = BorderStyle.Fixed3D;
            pnlDifficulties.Controls.Add(btnStartGame);
            pnlDifficulties.Controls.Add(btnExit);
            pnlDifficulties.Controls.Add(rbtnHard);
            pnlDifficulties.Controls.Add(rbtnEasy);
            pnlDifficulties.Location = new Point(57, 34);
            pnlDifficulties.Name = "pnlDifficulties";
            pnlDifficulties.Size = new Size(292, 118);
            pnlDifficulties.TabIndex = 2;
            // 
            // btnStartGame
            // 
            btnStartGame.BackColor = SystemColors.ActiveCaptionText;
            btnStartGame.ForeColor = SystemColors.ControlLightLight;
            btnStartGame.Location = new Point(147, 79);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(75, 23);
            btnStartGame.TabIndex = 3;
            btnStartGame.Text = "&Start Game";
            ToolTips.SetToolTip(btnStartGame, "Click here, or press 'ALT + S' to start the game with the selected difficulty.");
            btnStartGame.UseVisualStyleBackColor = false;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.ActiveCaptionText;
            btnExit.ForeColor = SystemColors.ControlLightLight;
            btnExit.Location = new Point(66, 79);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 2;
            btnExit.Text = "E&xit";
            ToolTips.SetToolTip(btnExit, "Click here, or press 'ALT + X' to exit.");
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // rbtnHard
            // 
            rbtnHard.AutoSize = true;
            rbtnHard.Location = new Point(146, 43);
            rbtnHard.Name = "rbtnHard";
            rbtnHard.Size = new Size(51, 19);
            rbtnHard.TabIndex = 1;
            rbtnHard.TabStop = true;
            rbtnHard.Text = "&Hard";
            ToolTips.SetToolTip(rbtnHard, "Click here, or press 'ALT + H' to select hard.");
            rbtnHard.UseVisualStyleBackColor = true;
            // 
            // rbtnEasy
            // 
            rbtnEasy.AutoSize = true;
            rbtnEasy.Location = new Point(92, 43);
            rbtnEasy.Name = "rbtnEasy";
            rbtnEasy.Size = new Size(48, 19);
            rbtnEasy.TabIndex = 0;
            rbtnEasy.TabStop = true;
            rbtnEasy.Text = "&Easy";
            ToolTips.SetToolTip(rbtnEasy, "Click here, or press 'ALT + E' to select easy.");
            rbtnEasy.UseVisualStyleBackColor = true;
            // 
            // frmChangeDifficulty
            // 
            AcceptButton = btnStartGame;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            CancelButton = btnExit;
            ClientSize = new Size(431, 195);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "frmChangeDifficulty";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Choose a difficulty";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlDifficulties.ResumeLayout(false);
            pnlDifficulties.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Panel pnlDifficulties;
        private RadioButton rbtnEasy;
        private RadioButton rbtnHard;
        private Button btnExit;
        private Button btnStartGame;
        private ToolTip ToolTips;
    }
}