using MahApps.Metro.Controls;
using pvlibrary.Dumb;
using pvlibrary.Model.entities;
using pvlibrary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace pvlibrary.Controller
{
    internal class CartController
    {
        private static int Quantity => Cashier.lst.Sum(bid => bid.BidAmount);
        private static decimal Total => Cashier.lst.Sum(bid => bid.BidPayment);
        public static void AddToCart(object sender)
        {
            var addToCart = sender as Grid;
            var bookId = addToCart.FindChild<Grid>().FindChild<TextBlock>("tblBookId").Text;
            var bookCover = addToCart.FindChild<Grid>().FindChild<TextBlock>("imbBookCover").Text;
            var bookName = addToCart.FindChild<Grid>().FindChild<TextBlock>("tblBookName").Text;
            var bookSalePrice = addToCart.FindChild<Grid>().FindChild<TextBlock>("tblBookSalePrice").Text;

            BillDetailDisplay bookItem = new BillDetailDisplay
            {
                BidId = Cashier.lst.Count() + 1,
                BookId = int.Parse(bookId),
                BookCover = bookCover,
                BookName = bookName,
                BidSalePrice = decimal.Parse(bookSalePrice),
                BidAmount = 1,
                BidPayment = decimal.Parse(bookSalePrice)
            };
            bool ck = Cashier.lst.Any(a => a.BookId == bookItem.BookId);
            if (ck)
            {
                var temp = Cashier.lst.First(a => a.BookId == bookItem.BookId);
                temp.BidAmount++;
                temp.BidPayment = temp.BidSalePrice * temp.BidAmount;
            }
            else
            {
                Cashier.lst.Add(bookItem);
            }
        }
        public static void CartAction(object sender, CartEnum action, string tblId)
        {
            var btn = sender as Button;
            var bookId = btn.TryFindParent<Grid>().FindChild<TextBlock>(tblId).Text;
            var temp = Cashier.lst.First(a => a.BookId == int.Parse(bookId));

            switch (action)
            {
                case CartEnum.IncreaseQuantity:
                    temp.BidAmount++;
                    temp.BidPayment = temp.BidSalePrice * temp.BidAmount;
                    break;
                case CartEnum.DecreaseQuantity:
                    temp.BidAmount--;
                    temp.BidPayment = temp.BidSalePrice * temp.BidAmount;
                    break;
                case CartEnum.DeleteItem:
                    Cashier.lst.Remove(temp);
                    break;
            }
        }
        public static void DisplayCart(TextBlock quantity, TextBlock total)
        {
            Cashier.lvBid.Items.Clear();

            foreach (var item in Cashier.lst)
            {
                BillDetail bDetail = new BillDetail();
                bDetail.book_id = item.BookId;
                bDetail.bid_id = Cashier.lst.Count() + 1;

                bDetail.bid_amount = item.BidAmount;
                bDetail.bid_payment = item.BidPayment;

                Cashier.lvBid.Items.Add(item);
            }

            quantity.Text = Quantity.ToString();
            total.Text = $"{Total:C}";
        }
    }
}
