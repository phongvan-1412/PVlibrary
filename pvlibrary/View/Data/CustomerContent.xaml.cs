using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class CustomerContent : UserControl
    {
        public static DataGrid dataGrid;
        private readonly PVLibraryEntities pv = new PVLibraryEntities();
        
        public CustomerContent()
        {
            InitializeComponent();
            ShowData();
        }
        private void ShowData()
        {
            dataGrid = dgCusList;
            foreach (var item in pv.Customers)
            {
                dgCusList.Items.Add(item);
            }
        }
        private void BtnCusSubmit_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer
            {
                cus_name = tbCusName.Text,
                cus_address = tbCusAddress.Text,
                cus_contact = tbCusContact.Text,
                cus_email = tbCusEmail.Text,
                cus_status = true
            };

            customer = ModelMaker.Instance.InsertCustomer(customer);
            dgCusList.Items.Add(customer);

            tbCusName.Text = string.Empty;
            tbCusAddress.Text = string.Empty;
            tbCusContact.Text = string.Empty;
            tbCusEmail.Text = string.Empty;
        }
        private void BtnCusUpdate_Click(object sender, RoutedEventArgs e)
        {
            int cusId = (dgCusList.SelectedItem as Customer).cus_id;
            CustomerUpdate cusUpdate = new CustomerUpdate(cusId);
            cusUpdate.ShowDialog();
        }
        private void TBSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchCustomer(tbSearchText.Text);
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }

    }
}
