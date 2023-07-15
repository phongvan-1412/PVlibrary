using pvlibrary.Model.entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace pvlibrary.View
{
    public partial class Inventory : UserControl
    {
        private static BillDisplay billDisplay = new BillDisplay();
        public Inventory()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dgBillList.Items.Clear();
            foreach (var item in Cashier.waitList)
            {
                dgBillList.Items.Add(item);
            }
        }
        private void BtnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            billDisplay = dgBillList.SelectedItem as BillDisplay;
            WaitListDetail bDetail = new WaitListDetail(billDisplay);
            bDetail.Show();
        }
        private void BtnTakeBack_Click(object sender, RoutedEventArgs e)
        {
            Cashier.waitList.Remove(dgBillList.SelectedItem as BillDisplay);
            Cashier.lst.AddRange((dgBillList.SelectedItem as BillDisplay).BidDisplays);
            LoadData();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }
    }
}
