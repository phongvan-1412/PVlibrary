using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pvlibrary.Model.Business
{
    internal class BookManager : AFacadeDb<Book>
    {
        public override bool InsertDb(Book db)
        {
            try
            {
                entities.Books.Add(db);
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

        public override List<Book> SearchDb(string searchText)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateDb(Book db)
        {
            try
            {
                entities.Books.AddOrUpdate(db);
                entities.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fail!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
    }
}
