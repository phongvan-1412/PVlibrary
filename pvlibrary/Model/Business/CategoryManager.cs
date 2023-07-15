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
    internal class CategoryManager : AFacadeDb<Category>
    {
        public override bool InsertDb(Category db)
        {
            try
            {
                entities.Categories.Add(db);
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
        public override bool UpdateDb(Category db)
        {
            try
            {
                entities.Categories.AddOrUpdate(db);
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
        public override List<Category> SearchDb(string searchText)
        {
            try
            {
                var searchArray = entities.Categories.Where(c => c.cate_name.ToLower().Contains(searchText) || c.cate_name.Contains(searchText)).ToList();

                CategoryContent.dataGrid.Items.Clear();
                foreach (var item in searchArray)
                {
                    CategoryContent.dataGrid.Items.Add(item);
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
