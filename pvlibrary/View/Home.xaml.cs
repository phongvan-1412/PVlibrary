using System.Windows;
using System.Windows.Controls;

namespace pvlibrary.View
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            PageControl.Instance.MainView(new Cashier(), contentLayout);
        }

        private void BtnInsertData_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.MainView(new DataContent(), homeLayout);
        }
        private void BtnCashier_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.MainView(new Cashier(), contentLayout);
        }
        private void BtnInventory_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.MainView(new Inventory(), contentLayout);
        }
        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.MainView(new Dashboard(), contentLayout);
        }
        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Login(new Login());
        }
    }
}
