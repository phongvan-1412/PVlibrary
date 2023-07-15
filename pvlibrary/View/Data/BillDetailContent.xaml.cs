using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class BillDetailContent : Window
    {
        public static DataGrid datagrid;
        public static List<BillDetailDisplay> bidDisplayArray = new List<BillDetailDisplay>();
        private readonly PVLibraryEntities pv = new PVLibraryEntities();
        
        public BillDetailContent(int billId)
        {
            InitializeComponent();
            LoadData(billId);
        }
        private void LoadData(int billId)
        {
            datagrid = dgBidList;
            dgBidList.IsReadOnly = true;

            bidDisplayArray.Clear();
            dgBidList.Items.Clear();

            foreach (var item in pv.BillDetails.Where(bid => bid.bill_id == billId))
            {
                BillDetailDisplay bidDisplay = new BillDetailDisplay
                {
                    BidId = item.bid_id,
                    BookName = item.Book.book_name,
                    BidAmount = item.bid_amount,
                    BidPayment = item.bid_payment
                };
                bidDisplayArray.Add(bidDisplay);
                dgBidList.Items.Add(bidDisplay);
            }
        }
        private void TBBidSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = ModelMaker.Instance.SearchBillDetail(tbBidSearchText.Text);
            }
        }
    }
}
