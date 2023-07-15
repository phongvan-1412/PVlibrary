using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;

namespace pvlibrary.View.Update
{
    public partial class CustomerUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int cusId;
        public CustomerUpdate(int cusId)
        {
            InitializeComponent();
            this.cusId = cusId;
            ShowTextData();
        }
        private void ShowTextData()
        {
            var temp = (from cu in pv.Customers where cu.cus_id == cusId select cu).First();
            tbCusName.Text = temp.cus_name;
            tbCusAddress.Text = temp.cus_address;
            tbCusEmail.Text = temp.cus_email;
            tbCusContact.Text = (temp.cus_contact).ToString();
        }
        private void BtnCusUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            Customer cusUpdate = (from cu in pv.Customers where cu.cus_id == cusId select cu).Single();

            cusUpdate.cus_name = tbCusName.Text;
            cusUpdate.cus_address = tbCusAddress.Text;
            cusUpdate.cus_email = tbCusEmail.Text;
            cusUpdate.cus_contact = tbCusContact.Text;
            cusUpdate.cus_status = ckCusStatus.IsChecked;

            cusUpdate = ModelMaker.Instance.UpdateCustomer(cusUpdate);

            CustomerContent.dataGrid.Items.Clear();
            foreach (var item in pv.Customers)
            {
                CustomerContent.dataGrid.Items.Add(item);
            }

            Close();
        }
    }
}
