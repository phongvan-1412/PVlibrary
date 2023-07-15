using MahApps.Metro.Actions;
using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using pvlibrary.View.Update;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace pvlibrary.Model.Business
{
    internal class AuthorManager : AFacadeDb<Author>
    {
        public override bool InsertDb(Author db)
        {
            try
            {
                entities.Authors.Add(db);
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
        public override bool UpdateDb(Author db)
        {
            try
            {
                entities.Authors.AddOrUpdate(db);
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
        public override List<Author> SearchDb(string searchText)
        {
            try
            {
                var searchArray = entities.Authors.Where(a => a.auth_name.Contains(searchText)
                                                       || a.auth_information.Contains(searchText)).ToList();
                AuthorContent.datagrid.Items.Clear();
                foreach (var item in searchArray)
                {
                    AuthorContent.datagrid.Items.Add(item);
                }
                return searchArray;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
