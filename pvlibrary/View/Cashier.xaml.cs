using MahApps.Metro.Controls;
using pvlibrary.Controller;
using pvlibrary.Dumb;
using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace pvlibrary.View
{
    public partial class Cashier : UserControl
    {
        private readonly PVLibraryEntities pvLibrary = new PVLibraryEntities();

        public static List<BillDisplay> waitList = new List<BillDisplay>();
        public static List<BillDetail> bid = new List<BillDetail>();
        public static List<BillDetailDisplay> lst = new List<BillDetailDisplay>();
        public static List<Customer> cus = new List<Customer>();

        public static ListView lvBid;

        public static string billTotal;

        public Cashier()
        {
            InitializeComponent();
            LoadData();
        }
        //Book Data
        private void LoadData()
        {
            tblEmployee.Text = Application.GetCookie(PageControl.pvLibraryApp);
            lvBid = lvBillDetailView;

            if (lst.Count > 0 && lst != null)
            {
                foreach (var item in lst)
                {
                    lvBillDetailView.Items.Add(item);
                }
                tblQuantity.Text = lst.Sum(lstItem => lstItem.BidAmount).ToString();
                tblTotal.Text = $"{lst.Sum(lstItem => lstItem.BidPayment):C}";
            }

            foreach (var item in pvLibrary.Books)
            {
                if (item.book_status == true)
                {
                    lvBookView.Items.Add(item);
                }
            }
        }
        private void TBBookSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key is Key.Enter)
            {
                var searchText = tbSearchBook.Text;
                var searchArray = (from b in pvLibrary.Books
                                   where b.book_name.Contains(searchText)
                                        || b.book_sale_price.ToString().Contains(searchText)
                                   select b).ToList();

                lvBookView.Items.Clear();

                foreach (var item in searchArray)
                {
                    lvBookView.Items.Add(item);
                }
            }
        }
        
        //Add To Cart
        private void AddToCart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CartController.AddToCart(sender);
            CartController.DisplayCart(tblQuantity, tblTotal);
        }
        private void BtnIncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            CartController.CartAction(sender, CartEnum.IncreaseQuantity, "tblBookId");
            CartController.DisplayCart(tblQuantity, tblTotal);
        }
        private void BtnDecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            CartController.CartAction(sender, CartEnum.DecreaseQuantity, "tblBookId");
            CartController.DisplayCart(tblQuantity, tblTotal);
        }
        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            CartController.CartAction(sender, CartEnum.DeleteItem, "tblbookid");
            CartController.DisplayCart(tblQuantity, tblTotal);
        }

        //Customer Combobox
        private void LoadCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key is Key.Enter)
            {
                var p = pvLibrary.Customers.Where(c => c.cus_contact.Contains(CboCustomer.Text)
                                                    || c.cus_email.Contains(CboCustomer.Text)
                                                    || c.cus_name.Contains(CboCustomer.Text)).ToList();
                CboCustomer.IsDropDownOpen = true;
                CboCustomer.ItemsSource = p;
            }
        }
        private void SelectCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var temp = sender as TextBlock;

            CboCustomer.Text = temp.Text;
            CboCustomer.IsDropDownOpen = false;
        }
     
        //Sale Actions
        private void BtnPaymentSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime createdTime = DateTime.Now;
            var cusArray = pvLibrary.Customers.First(c => c.cus_name == CboCustomer.Text);

            Bill bill = new Bill
            {
                created_time = createdTime.ToString(),
                bill_total = lst.Sum(bid => bid.BidPayment),
                cus_id = cusArray.cus_id,
                emp_id = Login.currentUserId,
                bill_status = (int)PageNumber.Paid,
            };

            ModelMaker.Instance.InsertBill(bill);

            lvBillDetailView.Items.Clear();
            lst.Clear();
            tblQuantity.Text = string.Empty;
            tblTotal.Text = string.Empty;
            CboCustomer.Text = string.Empty;
        }
        private void BtnWaitSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime createdTime = DateTime.Now;

            BillDisplay billDisplay = new BillDisplay();
            billDisplay.BillId = waitList.Count() + 1;
            billDisplay.CreatedTime = createdTime.ToString();
            billDisplay.BillTotal = lst.Sum(bid => bid.BidPayment);
            billDisplay.BillStatus = "Pending";
            billDisplay.BidDisplays = new List<BillDetailDisplay>();
            billDisplay.BidDisplays.AddRange(lst);
            

            waitList.Add(billDisplay);

            lvBillDetailView.Items.Clear();
            lst.Clear();
            tblQuantity.Text = string.Empty;
            tblTotal.Text = string.Empty;
            CboCustomer.Text = string.Empty;
        }

        //Close
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }
    }
}
