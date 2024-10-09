namespace Assignment2
{
    partial class frmWinningScreen
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
            pnlGameOverview = new Panel();
            btnExit = new Button();
            btnPlayAgain = new Button();
            lblScore = new Label();
            lblMissilesFired = new Label();
            lblWinner = new Label();
            pnlOptionArea = new Panel();
            ToolTips = new ToolTip(components);
            pnlGameOverview.SuspendLayout();
            pnlOptionArea.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGameOverview
            // 
            pnlGameOverview.BackColor = SystemColors.ActiveBorder;
            pnlGameOverview.BorderStyle = BorderStyle.Fixed3D;
            pnlGameOverview.Controls.Add(btnExit);
            pnlGameOverview.Controls.Add(btnPlayAgain);
            pnlGameOverview.Controls.Add(lblScore);
            pnlGameOverview.Controls.Add(lblMissilesFired);
            pnlGameOverview.Location = new Point(87, 35);
            pnlGameOverview.Name = "pnlGameOverview";
            pnlGameOverview.Size = new Size(267, 171);
            pnlGameOverview.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.ActiveCaptionText;
            btnExit.ForeColor = SystemColors.ControlLightLight;
            btnExit.Location = new Point(4, 141);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 3;
            btnExit.Text = "E&xit";
            ToolTips.SetToolTip(btnExit, "Click here, or press 'ALT +X' to exit the application. ");
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.BackColor = SystemColors.ActiveCaptionText;
            btnPlayAgain.ForeColor = SystemColors.ControlLightLight;
            btnPlayAgain.Location = new Point(185, 141);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(75, 23);
            btnPlayAgain.TabIndex = 2;
            btnPlayAgain.Text = "&Play Again";
            ToolTips.SetToolTip(btnPlayAgain, "Click here, or press 'ALT + P' to play again.");
            btnPlayAgain.UseVisualStyleBackColor = false;
            btnPlayAgain.Click += btnPlayAgain_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(16, 67);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(63, 23);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: ";
            // 
            // lblMissilesFired
            // 
            lblMissilesFired.AutoSize = true;
            lblMissilesFired.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMissilesFired.Location = new Point(16, 29);
            lblMissilesFired.Name = "lblMissilesFired";
            lblMissilesFired.Size = new Size(121, 23);
            lblMissilesFired.TabIndex = 0;
            lblMissilesFired.Text = "Missiles Fired: ";
            // 
            // lblWinner
            // 
            lblWinner.AutoSize = true;
            lblWinner.BackColor = Color.FromArgb(150, 150, 150);
            lblWinner.BorderStyle = BorderStyle.Fixed3D;
            lblWinner.Font = new Font("Impact", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWinner.ForeColor = Color.FromArgb(30, 20, 0);
            lblWinner.Location = new Point(163, 10);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(117, 36);
            lblWinner.TabIndex = 0;
            lblWinner.Text = "YOU WIN!";
            // 
            // pnlOptionArea
            // 
            pnlOptionArea.BackColor = Color.FromArgb(30, 30, 30);
            pnlOptionArea.Controls.Add(lblWinner);
            pnlOptionArea.Controls.Add(pnlGameOverview);
            pnlOptionArea.Location = new Point(12, 12);
            pnlOptionArea.Name = "pnlOptionArea";
            pnlOptionArea.Size = new Size(440, 238);
            pnlOptionArea.TabIndex = 0;
            // 
            // frmWinningScreen
            // 
            AcceptButton = btnPlayAgain;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            CancelButton = btnExit;
            ClientSize = new Size(464, 262);
            ControlBox = false;
            Controls.Add(pnlOptionArea);
            MaximizeBox = false;
            MaximumSize = new Size(480, 301);
            MinimizeBox = false;
            MinimumSize = new Size(480, 301);
            Name = "frmWinningScreen";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "You Win!";
            pnlGameOverview.ResumeLayout(false);
            pnlGameOverview.PerformLayout();
            pnlOptionArea.ResumeLayout(false);
            pnlOptionArea.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlGameOverview;
        private Label lblMissilesFired;
        private Label lblWinner;
        private Panel pnlOptionArea;
        private Button btnPlayAgain;
        private Label lblScore;
        private Button btnExit;
        private ToolTip ToolTips;
    }
}