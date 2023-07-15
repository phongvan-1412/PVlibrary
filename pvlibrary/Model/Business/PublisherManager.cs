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
    internal class PublisherManager : AFacadeDb<Publisher>
    {
        public override bool InsertDb(Publisher db)
        {
            try
            {
                entities.Publishers.Add(db);
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
        public override bool UpdateDb(Publisher db)
        {
            try
            {
                entities.Publishers.AddOrUpdate(db);
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
        public override List<Publisher> SearchDb(string searchText)
        {
            try
            {
                var searchArray = entities.Publishers.Where(pub =>
                                   pub.pub_name.Contains(searchText)
                                || pub.pub_name.ToLower().Contains(searchText)
                                || pub.pub_information.Contains(searchText)).ToList();

                PublisherContent.dataGrid.Items.Clear();
                foreach (var item in searchArray)
                {
                    PublisherContent.dataGrid.Items.Add(item);
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
