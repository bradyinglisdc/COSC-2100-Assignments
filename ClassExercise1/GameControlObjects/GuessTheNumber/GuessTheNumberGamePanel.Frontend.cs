/*
 * Title: GuessTheNumberGamePanel Frontend
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This class contains the front-end design for the guess the number game.
 * It is a child of the Panel class to promote modularity within the main form's logic.
 * 
 * Essentially, this class serves as a premade panel for quickly and cleany instantiating
 * new instances of the Guess The Number Game.
 * 
 * This portion of the partial class contains the fronted/UI for the game.
 * The backend/logic is contained within the second partial definition of this class (GuessTheNumberGamePanel.Backend.cs).
 */

#region Namespaces Used
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definiton
    public partial class GuessTheNumberGamePanel : GenericGamePanel
    {
        #region Properties
        // Controls/tooltip
        private Label lblGameHeader { get; set; }
        private GroupBox gbxSettings { get; set; }
        private ComboBox cbxDifficultySelection { get; set; }
        private Label lblDifficultyLabel { get; set; }
        private Label lblMinimumGuessLabel { get; set; }
        private Label lblMaximumGuessNumber { get; set; }
        private Label lblMinimumGuess { get; set; }
        private Label lblMaximumGuess { get; set; }
        private Button btnBegin { get; set; }
        private Button btnExitGame { get; set; }
        private Label lblOpenGamePrompt { get; set; }
        private Button btnExitProgram { get; set; }
        private Label lblGuessNumberPrompt { get; set; }
        private NumericUpDown nudUserGuess { get; set; }
        private Panel pnlPlayArea { get; set; }
        private Button btnSubmitGuess { get; set; }
        private Panel pnlOutputArea { get; set; }
        private Label lblAttempts { get; set; }
        private Label lblGuessOutput { get; set; }
        private ToolTip mainFrmToolTip { get; set; }
        private ToolTip pnlGuessTheNumberToolTips { get; set; }
        private Container Components { get; set; }
        private Button btnPlayAgain { get; set; }
        #endregion

        #region Control Setup/Styling Methods
        /// <summary>
        /// Instantiates each control property and name property for this instance of the game.
        /// </summary>
        private void SetAllProperties()
        {
            // Game name
            GameName = "Guess The Number";

            // Tool tips/components
            lblGameHeader = new System.Windows.Forms.Label();
            Components = new System.ComponentModel.Container();
            mainFrmToolTip = new System.Windows.Forms.ToolTip(Components);
            pnlGuessTheNumberToolTips = new System.Windows.Forms.ToolTip(Components);
            btnExitGame = new System.Windows.Forms.Button();
            btnBegin = new System.Windows.Forms.Button();

            // Settings/start area/header
            gbxSettings = new System.Windows.Forms.GroupBox();
            cbxDifficultySelection = new System.Windows.Forms.ComboBox();
            lblDifficultyLabel = new System.Windows.Forms.Label();
            lblMaximumGuess = new System.Windows.Forms.Label();
            lblMinimumGuess = new System.Windows.Forms.Label();
            lblMaximumGuessNumber = new System.Windows.Forms.Label();
            lblMinimumGuessLabel = new System.Windows.Forms.Label();

            // Play area
            pnlPlayArea = new System.Windows.Forms.Panel();
            btnSubmitGuess = new System.Windows.Forms.Button();
            lblGuessNumberPrompt = new System.Windows.Forms.Label();
            nudUserGuess = new System.Windows.Forms.NumericUpDown();
            btnPlayAgain = new System.Windows.Forms.Button();

            // Output area
            pnlOutputArea = new System.Windows.Forms.Panel();
            lblAttempts = new System.Windows.Forms.Label();
            lblGuessOutput = new System.Windows.Forms.Label();
        }

        /// <summary>
        /// Sets up styling and positioning for each of this game instances control properties.
        /// </summary>
        private void StyleAllControls()
        {
            // Styling for game panel itself
            StyleGamePanel();

            // pnlOutputArea
            pnlOutputArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            pnlOutputArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            pnlOutputArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlOutputArea.Controls.Add(lblGuessOutput);
            pnlOutputArea.Controls.Add(lblAttempts);
            pnlOutputArea.Location = new System.Drawing.Point(5, 242);
            pnlOutputArea.Name = "pnlOutputArea";
            pnlOutputArea.Size = new System.Drawing.Size(652, 162);
            pnlOutputArea.TabIndex = 8;
            
            // lblGuessOutput
            lblGuessOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblGuessOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            lblGuessOutput.Location = new System.Drawing.Point(139, 35);
            lblGuessOutput.Size = new System.Drawing.Size(380, 120);
            lblGuessOutput.TabIndex = 1;
            lblGuessOutput.Text = "BEGIN THE GAME BY PRESSING \'Begin\'!\n";
            lblGuessOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            pnlGuessTheNumberToolTips.SetToolTip(lblGuessOutput, "Your guess output will be displayed here, indicating if you should guess higher o" +
        "r lower.");

            // lblAttempts
            lblAttempts.AutoSize = true;
            lblAttempts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblAttempts.Location = new System.Drawing.Point(4, 4);
            lblAttempts.Size = new System.Drawing.Size(39, 13);
            lblAttempts.TabIndex = 0;
            lblAttempts.Text = $"Attempts: {Attempts}";

            // pnlPlayArea
            pnlPlayArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            pnlPlayArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            pnlPlayArea.Controls.Add(btnSubmitGuess);
            pnlPlayArea.Controls.Add(lblGuessNumberPrompt);
            pnlPlayArea.Controls.Add(nudUserGuess);
            pnlPlayArea.Location = new System.Drawing.Point(5, 180);
            pnlPlayArea.Name = "pnlPlayArea";
            pnlPlayArea.Size = new System.Drawing.Size(300, 49);
            pnlPlayArea.TabIndex = 7;
            pnlPlayArea.Hide();

            // btnSubmitGuess
            btnSubmitGuess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            btnSubmitGuess.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btnSubmitGuess.Location = new System.Drawing.Point(211, 16);
            btnSubmitGuess.Name = "btnSubmitGuess";
            btnSubmitGuess.Size = new System.Drawing.Size(75, 23);
            btnSubmitGuess.TabIndex = 7;
            btnSubmitGuess.Text = "Guess!";
            pnlGuessTheNumberToolTips.SetToolTip(btnSubmitGuess, "Submit your guess here.");
            btnSubmitGuess.UseVisualStyleBackColor = false;

            // lblGuessNumberPrompt
            lblGuessNumberPrompt.AutoSize = true;
            lblGuessNumberPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblGuessNumberPrompt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblGuessNumberPrompt.Location = new System.Drawing.Point(6, 16);
            lblGuessNumberPrompt.Name = "lblGuessNumberPrompt";
            lblGuessNumberPrompt.Size = new System.Drawing.Size(122, 18);
            lblGuessNumberPrompt.TabIndex = 5;
            lblGuessNumberPrompt.Text = "Guess a number:";

            // nudUserGuess
            nudUserGuess.Location = new System.Drawing.Point(134, 16);
            nudUserGuess.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            nudUserGuess.Minimum = 1;
            nudUserGuess.Name = "nudUserGuess";
            nudUserGuess.Size = new System.Drawing.Size(63, 20);
            nudUserGuess.TabIndex = 6;
            pnlGuessTheNumberToolTips.SetToolTip(nudUserGuess, "Enter your guess here.");
            
            // btnExitGame
            btnExitGame.Location = new System.Drawing.Point(82, 146);
            btnExitGame.Name = "btnExitGame";
            btnExitGame.Size = new System.Drawing.Size(71, 23);
            btnExitGame.TabIndex = 4;
            btnExitGame.Text = "Exit &Game";
            pnlGuessTheNumberToolTips.SetToolTip(btnExitGame, "To exit this game, click here.");
            btnExitGame.UseVisualStyleBackColor = true;
            
            // btnPlayAgain 
            btnPlayAgain.Location = new System.Drawing.Point(255, 146);
            btnPlayAgain.Size = new System.Drawing.Size(71, 23);
            btnPlayAgain.TabIndex = 4;
            btnPlayAgain.Text = "Play Again?";
            btnPlayAgain.UseVisualStyleBackColor = true;
            btnPlayAgain.Visible = false;
            
            // btnBegin 
            btnBegin.Location = new System.Drawing.Point(5, 146);
            btnBegin.Name = "btnBegin";
            btnBegin.Size = new System.Drawing.Size(71, 23);
            btnBegin.TabIndex = 3;
            btnBegin.Text = "&Begin";
            pnlGuessTheNumberToolTips.SetToolTip(btnBegin, "Click here to begin the game.");
            btnBegin.UseVisualStyleBackColor = true;
            
            // gbxSettings
            gbxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            gbxSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            gbxSettings.Controls.Add(lblMaximumGuess);
            gbxSettings.Controls.Add(lblMinimumGuess);
            gbxSettings.Controls.Add(lblMaximumGuessNumber);
            gbxSettings.Controls.Add(lblMinimumGuessLabel);
            gbxSettings.Controls.Add(lblDifficultyLabel);
            gbxSettings.Controls.Add(cbxDifficultySelection);
            gbxSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            gbxSettings.Location = new System.Drawing.Point(5, 58);
            gbxSettings.Name = "gbxSettings";
            gbxSettings.Size = new System.Drawing.Size(320, 82);
            gbxSettings.TabIndex = 2;
            gbxSettings.TabStop = false;
            gbxSettings.Text = "Settings";
            
            // lblMaximumGuess
            lblMaximumGuess.AutoSize = true;
            lblMaximumGuess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblMaximumGuess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            lblMaximumGuess.Location = new System.Drawing.Point(273, 53);
            lblMaximumGuess.Name = "lblMaximumGuess";
            lblMaximumGuess.Size = new System.Drawing.Size(13, 13);
            lblMaximumGuess.TabIndex = 5;
            lblMaximumGuess.Text = "1";
            pnlGuessTheNumberToolTips.SetToolTip(lblMaximumGuess, "Maximum allowed guess displayed here");
            
            // lblMinimumGuess
            lblMinimumGuess.AutoSize = true;
            lblMinimumGuess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblMinimumGuess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            lblMinimumGuess.Location = new System.Drawing.Point(273, 24);
            lblMinimumGuess.Name = "lblMinimumGuess";
            lblMinimumGuess.Size = new System.Drawing.Size(13, 13);
            lblMinimumGuess.TabIndex = 4;
            lblMinimumGuess.Text = "1";
            pnlGuessTheNumberToolTips.SetToolTip(lblMinimumGuess, "Minimum allowed guess displayed here");
            
            // lblMaximumGuessNumber
            lblMaximumGuessNumber.AutoSize = true;
            lblMaximumGuessNumber.Location = new System.Drawing.Point(186, 53);
            lblMaximumGuessNumber.Name = "lblMaximumGuessNumber";
            lblMaximumGuessNumber.Size = new System.Drawing.Size(84, 13);
            lblMaximumGuessNumber.TabIndex = 3;
            lblMaximumGuessNumber.Text = "Maximum Guess";
            
            // lblMinimumGuessLabel
            lblMinimumGuessLabel.AutoSize = true;
            lblMinimumGuessLabel.Location = new System.Drawing.Point(186, 24);
            lblMinimumGuessLabel.Name = "lblMinimumGuessLabel";
            lblMinimumGuessLabel.Size = new System.Drawing.Size(81, 13);
            lblMinimumGuessLabel.TabIndex = 2;
            lblMinimumGuessLabel.Text = "Minimum Guess";
            
            // lblDifficultyLabel
            lblDifficultyLabel.AutoSize = true;
            lblDifficultyLabel.Location = new System.Drawing.Point(6, 24);
            lblDifficultyLabel.Name = "lblDifficultyLabel";
            lblDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            lblDifficultyLabel.TabIndex = 1;
            lblDifficultyLabel.Text = "Difficulty";
            
            // cbxDifficultySelection
            cbxDifficultySelection.FormattingEnabled = true;
            cbxDifficultySelection.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            cbxDifficultySelection.Location = new System.Drawing.Point(59, 19);
            cbxDifficultySelection.Name = "cbxDifficultySelection";
            cbxDifficultySelection.Size = new System.Drawing.Size(100, 21);
            cbxDifficultySelection.TabIndex = 0;
            pnlGuessTheNumberToolTips.SetToolTip(cbxDifficultySelection, "Click here to select a difficulty.");

            // lblGameHeader
            lblGameHeader.AutoSize = true;
            lblGameHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblGameHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            lblGameHeader.Location = new System.Drawing.Point(0, 24);
            lblGameHeader.Name = "lblGameHeader";
            lblGameHeader.Size = new System.Drawing.Size(247, 29);
            lblGameHeader.TabIndex = 0;
            lblGameHeader.Text = "Guess The Number!";
        }

        /// <summary>
        /// Simply applies the needed styles and positioning to the game panel.
        /// </summary>
        private void StyleGamePanel()
        {
            // Firstly, add each control to this instance of the game's controls
            Controls.Add(pnlOutputArea);
            Controls.Add(pnlPlayArea);
            Controls.Add(btnExitGame);
            Controls.Add(btnBegin);
            Controls.Add(btnPlayAgain);
            Controls.Add(gbxSettings);
            Controls.Add(lblGameHeader);

            // Next, styling and positioning applied for the panel itself
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            Location = new System.Drawing.Point(12, 12);
            Name = "pnlGuessTheNumber";
            Size = new System.Drawing.Size(660, 416);
            TabIndex = 0;
        }
        #endregion

    }
    #endregion
}
#endregion