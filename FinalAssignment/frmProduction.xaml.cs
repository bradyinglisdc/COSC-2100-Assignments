using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmProduction : Window
    {
        public frmProduction()
        {
            InitializeComponent();
            Note.FillParents();
        }

        private void grdMainContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinmimize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}