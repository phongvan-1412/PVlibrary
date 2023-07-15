using System.Windows;

namespace pvlibrary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageControl.Instance.SetMainWindow(this);
            PageControl.Instance.Login(new View.Login());
        }

    }
}
