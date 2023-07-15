using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvlibrary.Model.entities
{
    public partial class CustomerStatistic
    {
        public int CusId { get; set; }
        public string CusName { get; set; }
        public decimal CusTotal { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }

        public CustomerStatistic() { }
        public CustomerStatistic(Customer customer)
        {
            CusName = customer.cus_name;
            CusTotal = customer.Bills.Sum(b => b.bill_total);
        }
    }
}
