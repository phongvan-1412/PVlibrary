using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvlibrary.Model.entities
{
    public partial class BillDetailDisplay
    {
        public BillDetailDisplay() { }
        public int BidId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookCover { get; set; }
        public int BidAmount { get; set; }
        public decimal BidPrice { get; set; }
        public decimal BidSalePrice { get; set; }
        public decimal BidPayment { get; set; }
       
        public int BillId { get; set; }
    }
}
