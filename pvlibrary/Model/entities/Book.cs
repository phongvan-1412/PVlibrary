//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pvlibrary.Model.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.BillDetails = new HashSet<BillDetail>();
        }
    
        public int book_id { get; set; }
        public string book_name { get; set; }
        public int book_amount { get; set; }
        public Nullable<decimal> book_price { get; set; }
        public Nullable<decimal> book_sale_price { get; set; }
        public string book_cover { get; set; }
        public string book_description { get; set; }
        public Nullable<int> auth_id { get; set; }
        public Nullable<int> pub_id { get; set; }
        public Nullable<int> cate_id { get; set; }
        public Nullable<bool> book_status { get; set; }
    
        public virtual Author Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
