using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace pvlibrary.Model.Business
{
    internal class BillStatuManager : AFacadeDb<BillStatu>
    {
        public override bool InsertDb(BillStatu db)
        {
            try
            {
                entities.BillStatus.Add(db);
                entities.SaveChanges();
                MessageBox.Show("Add Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fail!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        public override bool UpdateDb(BillStatu db)
        {
            try
            {
                entities.BillStatus.AddOrUpdate(db);
                entities.SaveChanges();
                MessageBox.Show("Update Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fail!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        public override List<BillStatu> SearchDb(string searchText)
        {
            try
            {
                var searchArray = (from bs in entities.BillStatus
                                   where bs.bs_name.Contains(searchText) || bs.bs_name.ToLower().Contains(searchText)
                                   select bs).ToList();

                BillContent.dataGridBs.Items.Clear();
                foreach (var item in searchArray)
                {
                    BillContent.dataGridBs.Items.Add(item);
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
