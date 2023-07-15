using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pvlibrary.Model.Business
{
    internal class BookDisplayManager : AFacadeDb<BookDisplay>
    {
        public override bool InsertDb(BookDisplay db)
        {
            throw new NotImplementedException();
        }
        public override bool UpdateDb(BookDisplay db)
        {
            throw new NotImplementedException();
        }
        public override List<BookDisplay> SearchDb(string searchText)
        {
            try
            {
                var searchArray = BookContent.bDisplay.Where(b => b.BookName.ToLower().Contains(searchText)
                                    || b.BookAmount.ToString().Contains(searchText)
                                    || b.BookPrice.ToString().Contains(searchText)
                                    || b.BookSalePrice.ToString().Contains(searchText)
                                    || b.BookDescription.ToLower().Contains(searchText)
                                    || b.AuthName.ToLower().Contains(searchText)
                                    || b.AuthName.Contains(searchText)
                                    || b.CateName.Contains(searchText)
                                    || b.CateName.ToLower().Contains(searchText)
                                    || b.PubName.ToLower().Contains(searchText)
                                    || b.PubName.Contains(searchText)).ToList();

                BookContent.datagrid.Items.Clear();
                foreach (var item in searchArray)
                {
                    BookContent.datagrid.Items.Add(item);
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
