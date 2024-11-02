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
            pictureBox1 = new PictureBox();
            btnAccessCharacterCreator = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.SplashBackgroundFinal_v1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1038, 638);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            btnAccessCharacterCreator.TabIndex = 1;
            btnAccessCharacterCreator.Text = "Enter Character Creator";
            btnAccessCharacterCreator.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.CharacterCreatorButton;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseOverBackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Algerian", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(475, 329);
            button1.Name = "button1";
            button1.Size = new Size(109, 39);
            button1.TabIndex = 2;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 635);
            Controls.Add(button1);
            Controls.Add(btnAccessCharacterCreator);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Character Creator";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAccessCharacterCreator;
        private Button button1;
    }
}
