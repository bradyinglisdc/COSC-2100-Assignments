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
            this.lblOpenGamePrompt = new System.Windows.Forms.Label();
            this.btnExitProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.btnExitProgram.Location = new System.Drawing.Point(558, 432);
            this.btnExitProgram.Name = "btnExitProgram";
            this.btnExitProgram.Size = new System.Drawing.Size(112, 23);
            this.btnExitProgram.TabIndex = 2;
            this.btnExitProgram.Text = "E&xit My Games";
            this.btnExitProgram.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnExitProgram);
            this.Controls.Add(this.lblOpenGamePrompt);
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Games";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOpenGamePrompt;
        private System.Windows.Forms.Button btnExitProgram;
    }
}

