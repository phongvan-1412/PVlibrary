using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace pvlibrary.Model.Business
{
    internal class BillManager : AFacadeDb<Bill>
    {
        public override bool InsertDb(Bill db)
        {
            try
            {
                entities.Bills.Add(db);
                entities.SaveChanges();

                //Insert Bill Detail + Update Book Quantity
                foreach (var item in Cashier.lst)
                {
                    BillDetail billDetail = new BillDetail
                    {
                        book_id = item.BookId,
                        bid_amount = item.BidAmount,
                        bid_payment = item.BidPayment,
                        bill_id = db.bill_id,
                    };
                    ModelMaker.Instance.InsertBillDetail(billDetail);

                    var book = entities.Books.First(b => b.book_id == item.BookId);
                    book.book_amount -= item.BidAmount;
                    book.book_status = book.book_amount > 0;
                    ModelMaker.Instance.UpdateBook(book);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public override bool UpdateDb(Bill db)
        {
            throw new NotImplementedException();
        }
        public override List<Bill> SearchDb(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
