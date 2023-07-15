using pvlibrary.Model.entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace pvlibrary.Model.ModelPattern
{
    internal abstract class AFacadeDb<T>
    {
        protected PVLibraryEntities entities = new PVLibraryEntities();

        public abstract bool InsertDb(T db);
        public abstract bool UpdateDb(T db);
        public abstract List<T> SearchDb(string searchText);
    }
}
