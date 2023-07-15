using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace pvlibrary.Model.Business
{
    internal class BillDetailManager : AFacadeDb<BillDetail>
    {
        public override bool InsertDb(BillDetail db)
        {
            try
            {
                entities.BillDetails.Add(db);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public override bool UpdateDb(BillDetail db)
        {
            throw new NotImplementedException();
        }
        public override List<BillDetail> SearchDb(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
