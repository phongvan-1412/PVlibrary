using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvlibrary.Model.entities
{
    public partial class BookDisplay
    {
        
        public BookDisplay()
        {
            //Book_id = book.book_id;
            //Book_name = book.book_name;
            //Book_amount = (int)book.book_amount;
            //Book_price = (decimal)book.book_price;
            //Book_description = book.book_description;
            //Auth_name = auth.auth_name;
            //Cate_name = cate.cate_name;
            //Pub_name = pub.pub_name;
            //book_status = (bool)book.book_status;
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookAmount { get; set; }
        public decimal BookPrice { get; set; }
        public decimal BookSalePrice { get; set; }
        public string BookDescription { get; set; }
        public string AuthName { get; set; }
        public string CateName { get; set; }
        public string PubName { get; set; }
        public string BookCover { get; set; }
        public Nullable<bool> BookStatus { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
