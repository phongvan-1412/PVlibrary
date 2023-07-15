using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using MahApps.Metro.Actions;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class BillContent : UserControl
    {
        public static DataGrid dataGridBs;
        public static DataGrid dataGridBill;
        public static List<BillDisplay> bDisplay = new List<BillDisplay>();
        private readonly PVLibraryEntities pv = new PVLibraryEntities();

        public BillContent()
        {
            InitializeComponent();
            LoadBsData();
            LoadBillData();
        }
        //Load Data
        private void LoadBsData()
        {
            dataGridBs = dgBsList;
            dgBsList.IsReadOnly = true;
            foreach (var item in pv.BillStatus)
            {
                dgBsList.Items.Add(item);
            }
        }
        private void LoadBillData()
        {
            dataGridBill = dgBillList;
            dgBillList.IsReadOnly = true;

            bDisplay.Clear();
            dgBillList.Items.Clear();

            foreach (var item in pv.Bills)
            {
                BillDisplay billDipslay = new BillDisplay();

                billDipslay.BillId = item.bill_id;
                billDipslay.CreatedTime = item.created_time;
                billDipslay.BillTotal = item.bill_total;
                billDipslay.CustomerName = item.Customer.cus_name;
                billDipslay.EmployeeName = item.Employee.emp_name;
                billDipslay.BillStatus = item.BillStatu.bs_name;

                bDisplay.Add(billDipslay);
                dgBillList.Items.Add(billDipslay);
            }
        }
        private void BtnViewBid_Click(object sender, RoutedEventArgs e)
        {
            int billId = (dgBillList.SelectedItem as BillDisplay).BillId;
            System.Console.WriteLine(billId);
            BillDetailContent bDetail = new BillDetailContent(billId);
            bDetail.ShowDialog();
        }

        //Insert
        private void BtnBsSubmit_Click(object sender, RoutedEventArgs e)
        {
            BillStatu bs = new BillStatu
            {
                bs_name = tbBsName.Text,
                bs_status = true
            };

            bs = ModelMaker.Instance.InsertBillStatus(bs);
            dgBsList.Items.Add(bs);

            tbBsName.Text = string.Empty;
        }

        //Update
        private void BtnBsUpdate_Click(object sender, RoutedEventArgs e)
        {
            int bsId = (dgBsList.SelectedItem as BillStatu).bs_id;
            BillStatusUpdate bsUpdate = new BillStatusUpdate(bsId);
            bsUpdate.ShowDialog();
        }

        //Search
        private void TBBsSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchBillStatus(tbBsSearchText.Text);
        }
        private void TBBillSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchBill(tbBillSearchText.Text);
        }

        //Close
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }
    }
}
