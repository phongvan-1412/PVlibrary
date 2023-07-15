using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvlibrary.Model.Business
{
    internal class BillDetailDisplayManger : AFacadeDb<BillDetailDisplay>
    {
        public override bool InsertDb(BillDetailDisplay db)
        {
            throw new NotImplementedException();
        }
        public override bool UpdateDb(BillDetailDisplay db)
        {
            throw new NotImplementedException();
        }
        public override List<BillDetailDisplay> SearchDb(string searchText)
        {
            try
            {
                var searchArray = BillDetailContent.bidDisplayArray.Where(bid => bid.BookName.ToLower().Contains(searchText)
                                                    || bid.BookName.Contains(searchText)
                                                    || bid.BidAmount.ToString().Contains(searchText)
                                                    || bid.BidPayment.ToString().Contains(searchText));

                BillDetailContent.datagrid.Items.Clear();

                foreach (var item in searchArray)
                {
                    BillDetailContent.datagrid.Items.Add(item);
                }
                return (List<BillDetailDisplay>) searchArray;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
