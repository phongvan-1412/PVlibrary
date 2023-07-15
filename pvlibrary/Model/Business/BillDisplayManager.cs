using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pvlibrary.Model.Business
{
    internal class BillDisplayManager : AFacadeDb<BillDisplay>
    {
        public override bool InsertDb(BillDisplay db)
        {
            throw new NotImplementedException();
        }
        public override bool UpdateDb(BillDisplay db)
        {
            throw new NotImplementedException();
        }
        public override List<BillDisplay> SearchDb(string searchText)
        {
            try
            {

                var searchArray = BillContent.bDisplay.Where(b => b.CreatedTime.Contains(searchText)
                                        || b.BillTotal.ToString().Contains(searchText)
                                        || b.BillStatus.ToString().Contains(searchText)
                                        || b.CustomerName.ToLower().Contains(searchText)
                                        || b.EmployeeName.ToLower().Contains(searchText)).ToList();
                BillContent.dataGridBill.Items.Clear();
                foreach (var item in searchArray)
                {
                    BillContent.dataGridBill.Items.Add(item);
                }
                return searchArray;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}
