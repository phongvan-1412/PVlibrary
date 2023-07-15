using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pvlibrary.View
{
    public partial class DataContent : UserControl
    {
        public DataContent()
        {
            InitializeComponent();
            PageControl.Instance.SubView(new Data.BookContent(), DisplayContent);
        }
        private void BtnAuthor_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.AuthorContent(), DisplayContent);
        }
        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.CategoryContent(), DisplayContent);
        }
        private void BtnPublisher_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.PublisherContent(), DisplayContent);
        }
        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.BookContent(), DisplayContent);
        }
        private void BtnEmp_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.EmployeeContent(), DisplayContent);
        }
        private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.CustomerContent(), DisplayContent);
        }
        private void BtnBill_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.SubView(new Data.BillContent(), DisplayContent);
        }
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.HomeMenu(new Home());
        }
    }
}
