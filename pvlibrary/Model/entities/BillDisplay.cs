using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvlibrary.Model.entities
{
    public partial class BillDisplay
    {
        public BillDisplay() { }
        public int BillId { get; set; }
        public string CreatedTime { get; set; }
        public decimal BillTotal { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string BillStatus { get; set; }
        public virtual List<BillDetailDisplay> BidDisplays { get; set; }

    }
}
