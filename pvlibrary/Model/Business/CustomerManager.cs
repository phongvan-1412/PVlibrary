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
    internal class CustomerManager : AFacadeDb<Customer>
    {
        public override bool InsertDb(Customer db)
        {
            try
            {
                entities.Customers.Add(db);
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
        public override bool UpdateDb(Customer db)
        {
            try
            {
                entities.Customers.AddOrUpdate(db);
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
        public override List<Customer> SearchDb(string searchText)
        {
            try
            {
                var searchArray = entities.Customers.Where(cus =>
                                   cus.cus_name.ToLower().Contains(searchText)
                                || cus.cus_name.Contains(searchText)
                                || cus.cus_contact.ToString().Contains(searchText)
                                || cus.cus_address.ToLower().Contains(searchText)
                                || cus.cus_email.ToLower().Contains(searchText)).ToList();

                CustomerContent.dataGrid.Items.Clear();
                foreach (var item in searchArray)
                {
                    CustomerContent.dataGrid.Items.Add(item);
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
