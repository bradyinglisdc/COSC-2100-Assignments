namespace ClassExercise1
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
            this.components = new System.ComponentModel.Container();
            this.pnlGuessTheNumber = new System.Windows.Forms.Panel();
            this.pnlOutputArea = new System.Windows.Forms.Panel();
            this.lblGuessOutput = new System.Windows.Forms.Label();
            this.lblOutputArea = new System.Windows.Forms.Label();
            this.pnlPlayArea = new System.Windows.Forms.Panel();
            this.btnSubmitGuess = new System.Windows.Forms.Button();
            this.lblGuessNumberPrompt = new System.Windows.Forms.Label();
            this.nudUserGuess = new System.Windows.Forms.NumericUpDown();
            this.btnExitGame = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.gbxSettings = new System.Windows.Forms.GroupBox();
            this.lblMaximumGuess = new System.Windows.Forms.Label();
            this.lblMinimumGuess = new System.Windows.Forms.Label();
            this.lblMaximumGuessNumber = new System.Windows.Forms.Label();
            this.lblMinimumGuessLabel = new System.Windows.Forms.Label();
            this.lblDifficultyLabel = new System.Windows.Forms.Label();
            this.cbxDifficultySelection = new System.Windows.Forms.ComboBox();
            this.lblGameHeader = new System.Windows.Forms.Label();
            this.lblOpenGamePrompt = new System.Windows.Forms.Label();
            this.btnExitProgram = new System.Windows.Forms.Button();
            this.mainFrmToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlGuessTheNumberToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.pnlGuessTheNumber.SuspendLayout();
            this.pnlOutputArea.SuspendLayout();
            this.pnlPlayArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUserGuess)).BeginInit();
            this.gbxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGuessTheNumber
            // 
            this.pnlGuessTheNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGuessTheNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlGuessTheNumber.Controls.Add(this.pnlOutputArea);
            this.pnlGuessTheNumber.Controls.Add(this.pnlPlayArea);
            this.pnlGuessTheNumber.Controls.Add(this.btnExitGame);
            this.pnlGuessTheNumber.Controls.Add(this.btnBegin);
            this.pnlGuessTheNumber.Controls.Add(this.gbxSettings);
            this.pnlGuessTheNumber.Controls.Add(this.lblGameHeader);
            this.pnlGuessTheNumber.Location = new System.Drawing.Point(12, 12);
            this.pnlGuessTheNumber.Name = "pnlGuessTheNumber";
            this.pnlGuessTheNumber.Size = new System.Drawing.Size(660, 416);
            this.pnlGuessTheNumber.TabIndex = 0;
            // 
            // pnlOutputArea
            // 
            this.pnlOutputArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlOutputArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOutputArea.Controls.Add(this.lblGuessOutput);
            this.pnlOutputArea.Controls.Add(this.lblOutputArea);
            this.pnlOutputArea.Location = new System.Drawing.Point(5, 242);
            this.pnlOutputArea.Name = "pnlOutputArea";
            this.pnlOutputArea.Size = new System.Drawing.Size(652, 162);
            this.pnlOutputArea.TabIndex = 8;
            // 
            // lblGuessOutput
            // 
            this.lblGuessOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.lblGuessOutput.Location = new System.Drawing.Point(139, 64);
            this.lblGuessOutput.Name = "lblGuessOutput";
            this.lblGuessOutput.Size = new System.Drawing.Size(370, 23);
            this.lblGuessOutput.TabIndex = 1;
            this.lblGuessOutput.Text = "BEGIN THE GAME BY PRESSING \'Begin\'!";
            this.lblGuessOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlGuessTheNumberToolTips.SetToolTip(this.lblGuessOutput, "Your guess output will be displayed here, indicating if you should guess higher o" +
        "r lower.");
            // 
            // lblOutputArea
            // 
            this.lblOutputArea.AutoSize = true;
            this.lblOutputArea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOutputArea.Location = new System.Drawing.Point(4, 4);
            this.lblOutputArea.Name = "lblOutputArea";
            this.lblOutputArea.Size = new System.Drawing.Size(39, 13);
            this.lblOutputArea.TabIndex = 0;
            this.lblOutputArea.Text = "Output";
            // 
            // pnlPlayArea
            // 
            this.pnlPlayArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlPlayArea.Controls.Add(this.btnSubmitGuess);
            this.pnlPlayArea.Controls.Add(this.lblGuessNumberPrompt);
            this.pnlPlayArea.Controls.Add(this.nudUserGuess);
            this.pnlPlayArea.Location = new System.Drawing.Point(5, 180);
            this.pnlPlayArea.Name = "pnlPlayArea";
            this.pnlPlayArea.Size = new System.Drawing.Size(300, 49);
            this.pnlPlayArea.TabIndex = 7;
            // 
            // btnSubmitGuess
            // 
            this.btnSubmitGuess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.btnSubmitGuess.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubmitGuess.Location = new System.Drawing.Point(211, 16);
            this.btnSubmitGuess.Name = "btnSubmitGuess";
            this.btnSubmitGuess.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitGuess.TabIndex = 7;
            this.btnSubmitGuess.Text = "Guess!";
            this.pnlGuessTheNumberToolTips.SetToolTip(this.btnSubmitGuess, "Submit your guess here.");
            this.btnSubmitGuess.UseVisualStyleBackColor = false;
            // 
            // lblGuessNumberPrompt
            // 
            this.lblGuessNumberPrompt.AutoSize = true;
            this.lblGuessNumberPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessNumberPrompt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGuessNumberPrompt.Location = new System.Drawing.Point(6, 16);
            this.lblGuessNumberPrompt.Name = "lblGuessNumberPrompt";
            this.lblGuessNumberPrompt.Size = new System.Drawing.Size(122, 18);
            this.lblGuessNumberPrompt.TabIndex = 5;
            this.lblGuessNumberPrompt.Text = "Guess a number:";
            // 
            // nudUserGuess
            // 
            this.nudUserGuess.Location = new System.Drawing.Point(134, 16);
            this.nudUserGuess.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudUserGuess.Name = "nudUserGuess";
            this.nudUserGuess.Size = new System.Drawing.Size(63, 20);
            this.nudUserGuess.TabIndex = 6;
            this.pnlGuessTheNumberToolTips.SetToolTip(this.nudUserGuess, "Enter your guess here.");
            // 
            // btnExitGame
            // 
            this.btnExitGame.Location = new System.Drawing.Point(82, 146);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(71, 23);
            this.btnExitGame.TabIndex = 4;
            this.btnExitGame.Text = "Exit &Game";
            this.pnlGuessTheNumberToolTips.SetToolTip(this.btnExitGame, "To exit this game, click here.");
            this.btnExitGame.UseVisualStyleBackColor = true;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(5, 146);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(71, 23);
            this.btnBegin.TabIndex = 3;
            this.btnBegin.Text = "&Begin";
            this.pnlGuessTheNumberToolTips.SetToolTip(this.btnBegin, "Click here to begin the game.");
            this.btnBegin.UseVisualStyleBackColor = true;
            // 
            // gbxSettings
            // 
            this.gbxSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gbxSettings.Controls.Add(this.lblMaximumGuess);
            this.gbxSettings.Controls.Add(this.lblMinimumGuess);
            this.gbxSettings.Controls.Add(this.lblMaximumGuessNumber);
            this.gbxSettings.Controls.Add(this.lblMinimumGuessLabel);
            this.gbxSettings.Controls.Add(this.lblDifficultyLabel);
            this.gbxSettings.Controls.Add(this.cbxDifficultySelection);
            this.gbxSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxSettings.Location = new System.Drawing.Point(5, 58);
            this.gbxSettings.Name = "gbxSettings";
            this.gbxSettings.Size = new System.Drawing.Size(300, 82);
            this.gbxSettings.TabIndex = 2;
            this.gbxSettings.TabStop = false;
            this.gbxSettings.Text = "Settings";
            // 
            // lblMaximumGuess
            // 
            this.lblMaximumGuess.AutoSize = true;
            this.lblMaximumGuess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMaximumGuess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblMaximumGuess.Location = new System.Drawing.Point(273, 53);
            this.lblMaximumGuess.Name = "lblMaximumGuess";
            this.lblMaximumGuess.Size = new System.Drawing.Size(13, 13);
            this.lblMaximumGuess.TabIndex = 5;
            this.lblMaximumGuess.Text = "0";
            this.pnlGuessTheNumberToolTips.SetToolTip(this.lblMaximumGuess, "Maximum allowed guess displayed here");
            // 
            // lblMinimumGuess
            // 
            this.lblMinimumGuess.AutoSize = true;
            this.lblMinimumGuess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMinimumGuess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblMinimumGuess.Location = new System.Drawing.Point(273, 24);
            this.lblMinimumGuess.Name = "lblMinimumGuess";
            this.lblMinimumGuess.Size = new System.Drawing.Size(13, 13);
            this.lblMinimumGuess.TabIndex = 4;
            this.lblMinimumGuess.Text = "0";
            this.pnlGuessTheNumberToolTips.SetToolTip(this.lblMinimumGuess, "Minimum allowed guess displayed here");
            // 
            // lblMaximumGuessNumber
            // 
            this.lblMaximumGuessNumber.AutoSize = true;
            this.lblMaximumGuessNumber.Location = new System.Drawing.Point(186, 53);
            this.lblMaximumGuessNumber.Name = "lblMaximumGuessNumber";
            this.lblMaximumGuessNumber.Size = new System.Drawing.Size(84, 13);
            this.lblMaximumGuessNumber.TabIndex = 3;
            this.lblMaximumGuessNumber.Text = "Maximum Guess";
            // 
            // lblMinimumGuessLabel
            // 
            this.lblMinimumGuessLabel.AutoSize = true;
            this.lblMinimumGuessLabel.Location = new System.Drawing.Point(186, 24);
            this.lblMinimumGuessLabel.Name = "lblMinimumGuessLabel";
            this.lblMinimumGuessLabel.Size = new System.Drawing.Size(81, 13);
            this.lblMinimumGuessLabel.TabIndex = 2;
            this.lblMinimumGuessLabel.Text = "Minimum Guess";
            // 
            // lblDifficultyLabel
            // 
            this.lblDifficultyLabel.AutoSize = true;
            this.lblDifficultyLabel.Location = new System.Drawing.Point(6, 24);
            this.lblDifficultyLabel.Name = "lblDifficultyLabel";
            this.lblDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.lblDifficultyLabel.TabIndex = 1;
            this.lblDifficultyLabel.Text = "Difficulty";
            // 
            // cbxDifficultySelection
            // 
            this.cbxDifficultySelection.FormattingEnabled = true;
            this.cbxDifficultySelection.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cbxDifficultySelection.Location = new System.Drawing.Point(59, 19);
            this.cbxDifficultySelection.Name = "cbxDifficultySelection";
            this.cbxDifficultySelection.Size = new System.Drawing.Size(100, 21);
            this.cbxDifficultySelection.TabIndex = 0;
            this.pnlGuessTheNumberToolTips.SetToolTip(this.cbxDifficultySelection, "Click here to select a difficulty.");
            // 
            // lblGameHeader
            // 
            this.lblGameHeader.AutoSize = true;
            this.lblGameHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.lblGameHeader.Location = new System.Drawing.Point(0, 24);
            this.lblGameHeader.Name = "lblGameHeader";
            this.lblGameHeader.Size = new System.Drawing.Size(247, 29);
            this.lblGameHeader.TabIndex = 0;
            this.lblGameHeader.Text = "Guess The Number!";
            // 
            // lblOpenGamePrompt
            // 
            this.lblOpenGamePrompt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOpenGamePrompt.Location = new System.Drawing.Point(170, 224);
            this.lblOpenGamePrompt.Name = "lblOpenGamePrompt";
            this.lblOpenGamePrompt.Size = new System.Drawing.Size(345, 13);
            this.lblOpenGamePrompt.TabIndex = 1;
            this.lblOpenGamePrompt.Text = "No game open...Press the \'+\' on the Game Picker menu to pick a game!";
            // 
            // btnExitProgram
            // 
            this.btnExitProgram.Location = new System.Drawing.Point(576, 434);
            this.btnExitProgram.Name = "btnExitProgram";
            this.btnExitProgram.Size = new System.Drawing.Size(96, 23);
            this.btnExitProgram.TabIndex = 2;
            this.btnExitProgram.Text = "E&xit My Games";
            this.mainFrmToolTip.SetToolTip(this.btnExitProgram, "Click here to exit program and close window.");
            this.btnExitProgram.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnExitProgram);
            this.Controls.Add(this.pnlGuessTheNumber);
            this.Controls.Add(this.lblOpenGamePrompt);
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Games";
            this.mainFrmToolTip.SetToolTip(this, "You can start a game by pressing the plus icon on the game picker menu.\r\n");
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlGuessTheNumber.ResumeLayout(false);
            this.pnlGuessTheNumber.PerformLayout();
            this.pnlOutputArea.ResumeLayout(false);
            this.pnlOutputArea.PerformLayout();
            this.pnlPlayArea.ResumeLayout(false);
            this.pnlPlayArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUserGuess)).EndInit();
            this.gbxSettings.ResumeLayout(false);
            this.gbxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGuessTheNumber;
        private System.Windows.Forms.Label lblGameHeader;
        private System.Windows.Forms.GroupBox gbxSettings;
        private System.Windows.Forms.ComboBox cbxDifficultySelection;
        private System.Windows.Forms.Label lblDifficultyLabel;
        private System.Windows.Forms.Label lblMinimumGuessLabel;
        private System.Windows.Forms.Label lblMaximumGuessNumber;
        private System.Windows.Forms.Label lblMinimumGuess;
        private System.Windows.Forms.Label lblMaximumGuess;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnExitGame;
        private System.Windows.Forms.Label lblOpenGamePrompt;
        private System.Windows.Forms.Button btnExitProgram;
        private System.Windows.Forms.Label lblGuessNumberPrompt;
        private System.Windows.Forms.NumericUpDown nudUserGuess;
        private System.Windows.Forms.Panel pnlPlayArea;
        private System.Windows.Forms.Button btnSubmitGuess;
        private System.Windows.Forms.Panel pnlOutputArea;
        private System.Windows.Forms.Label lblOutputArea;
        private System.Windows.Forms.Label lblGuessOutput;
        private System.Windows.Forms.ToolTip mainFrmToolTip;
        private System.Windows.Forms.ToolTip pnlGuessTheNumberToolTips;
    }
}

