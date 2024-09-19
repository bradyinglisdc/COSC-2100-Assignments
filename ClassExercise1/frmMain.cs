using System;
using System.Windows.Forms;

namespace ClassExercise1
{
    public partial class frmMain : Form
    {
        private MainMenuPanel pnlMainMenu
        {
            get; set;
        }
        public frmMain()
        {
            InitializeComponent();
        }

        public void InitializeMenu()
        {
            Controls.Add(new MainMenuPanel(Height));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeMenu();
        }
    }
}
