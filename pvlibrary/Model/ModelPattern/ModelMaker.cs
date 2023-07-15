using pvlibrary.Model.Business;
using pvlibrary.Model.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;

namespace pvlibrary.Model.ModelPattern
{
    internal class ModelMaker
    {
        private static readonly Lazy<ModelMaker> lazy = new Lazy<ModelMaker>(() => new ModelMaker());
        public static ModelMaker Instance { get { return lazy.Value; } }

        private readonly AuthorManager _authorManager;
        private readonly CategoryManager _cateManager;
        private readonly CustomerManager _cusManager;
        private readonly EmployeeManager _empManager;
        private readonly PublisherManager _pubManager;
        private readonly BookManager _bookManager;
        private readonly BookDisplayManager _bookDisplayManager;
        private readonly BillDetailManager _bidManager;
        private readonly BillDetailDisplayManger _bidDisplayManager;
        private readonly BillStatuManager _bsManager;
        private readonly BillManager _billManager;
        private readonly BillDisplayManager _billDisplayManager;
        public ModelMaker()
        {
            _authorManager = new AuthorManager();
            _cateManager = new CategoryManager();
            _cusManager = new CustomerManager();
            _empManager = new EmployeeManager();
            _pubManager = new PublisherManager();
            _bookManager = new BookManager();
            _bookDisplayManager = new BookDisplayManager();
            _bidManager = new BillDetailManager();
            _bidDisplayManager = new BillDetailDisplayManger();
            _bsManager = new BillStatuManager();
            _billManager = new BillManager();
            _billDisplayManager = new BillDisplayManager();
        }

        //Insert
        public Author InsertAuthor(Author auth)
        {
            return _authorManager.InsertDb(auth) ? auth : null;
        }
        public Category InsertCategory(Category cate)
        {
            return _cateManager.InsertDb(cate) ? cate : null;

        }
        public Customer InsertCustomer(Customer cus)
        {
            return _cusManager.InsertDb(cus) ? cus : null;
        }
        public Employee InsertEmployee(Employee emp)
        {
            return _empManager.InsertDb(emp) ? emp : null;
        }
        public Publisher InsertPublisher(Publisher pub)
        {
            return _pubManager.InsertDb(pub) ? pub : null;
        }
        public Book InsertBook(Book book)
        {
            return _bookManager.InsertDb(book) ? book : null;
        }
        public BillDetail InsertBillDetail(BillDetail bid)
        {
            return _bidManager.InsertDb(bid) ? bid : null;
        }
        public BillStatu InsertBillStatus(BillStatu bs)
        {
            return _bsManager.InsertDb(bs) ? bs : null;
        }
        public Bill InsertBill(Bill bill)
        {
            return _billManager.InsertDb(bill) ? bill : null;
        }

        //Update
        public Author UpdateAuthor(Author auth)
        {
            return _authorManager.UpdateDb(auth) ? auth : null;
        }
        public BillDetail UpdateBillDetail(BillDetail bid)
        {
            return _bidManager.UpdateDb(bid) ? bid : null;
        }
        public BillStatu UpdateBillStatus(BillStatu bs)
        {
            return _bsManager.UpdateDb(bs) ? bs : null;
        }
        public Book UpdateBook(Book b)
        {
            return _bookManager.UpdateDb(b) ? b : null;
        }
        public Category UpdateCategory(Category c)
        {
            return _cateManager.UpdateDb(c) ? c : null;
        }
        public Customer UpdateCustomer(Customer cus)
        {
            return _cusManager.UpdateDb(cus) ? cus : null;
        }
        public Employee UpdateEmployee(Employee emp)
        {
            return _empManager.UpdateDb(emp) ? emp : null;
        }
        public Publisher UpdatePublisher(Publisher pub)
        {
            return _pubManager.UpdateDb(pub) ? pub : null;
        }

        //Search
        public List<Author> SearchAuthor(string searchText)
        {
            return _authorManager.SearchDb(searchText);
        }
        public List<BillDetailDisplay> SearchBillDetail(string searchText)
        {
            return _bidDisplayManager.SearchDb(searchText);
        }
        public List<BillStatu> SearchBillStatus(string searchText)
        {
            return _bsManager.SearchDb(searchText);
        }
        public List<BillDisplay> SearchBill(string searchText)
        {
            return _billDisplayManager.SearchDb(searchText);
        }
        public List<BookDisplay> SearchBook(string searchText)
        {
            return _bookDisplayManager.SearchDb(searchText);
        }
        public List<Category> SearchCategory(string searchText)
        {
            return _cateManager.SearchDb(searchText);
        }
        public List<Customer> SearchCustomer(string searchText)
        {
            return _cusManager.SearchDb(searchText);
        }
        public List<Employee> SearchEmployee(string searchText)
        {
            return _empManager.SearchDb(searchText);
        }
        public List<Publisher> SearchPublisher(string searchText)
        {
            return _pubManager.SearchDb(searchText);
        }
    }
}
