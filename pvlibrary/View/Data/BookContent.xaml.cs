using Microsoft.Win32;
using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class BookContent : UserControl
    {
        public static DataGrid datagrid;
        public static List<BookDisplay> bDisplay = new List<BookDisplay>();
        private readonly PVLibraryEntities pv = new PVLibraryEntities();

        public BookContent()
        {
            InitializeComponent();
            LoadBookContent();
        }
        private void LoadBookContent()
        {
            datagrid = dgBookList;
            dgBookList.IsReadOnly = true;

            var p = pv.Authors.ToList();
            CboBookAuth.ItemsSource = p;

            var q = pv.Categories.ToList();
            CboBookCate.ItemsSource = q;

            var r = pv.Publishers.ToList();
            CboBookPublisher.ItemsSource = r;

            bDisplay.Clear();
            dgBookList.Items.Clear();

            foreach (var item in pv.Books)
            {
                BookDisplay bookList = new BookDisplay();
                bookList.BookId = item.book_id;
                bookList.BookCover = item.book_cover;
                bookList.BookName = item.book_name;
                bookList.BookAmount = (int)item.book_amount;
                bookList.BookPrice = (decimal)item.book_price;
                bookList.BookSalePrice = (decimal)item.book_sale_price;
                bookList.AuthName = item.Author.auth_name;
                bookList.CateName = item.Category.cate_name;
                bookList.PubName = item.Publisher.pub_name;
                bookList.BookStatus = (bool)item.book_status;

                bDisplay.Add(bookList);
                dgBookList.Items.Add(bookList);
            }
        }
        private void BtnUploadBookCover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select an Image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png";
            if (op.ShowDialog() == true)
            {
                var bookCover = op.FileName;
                tbBookCover.Text = bookCover;
            }
        }
        private void BtnBookSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbBookDes.Document.ContentStart, rtbBookDes.Document.ContentEnd);

            Book book = new Book
            {
                book_cover = tbBookCover.Text,
                book_name = tbBookName.Text,
                book_amount = int.Parse(tbBookAmount.Text),
                book_price = decimal.Parse(tbBookPrice.Text),
                book_sale_price = decimal.Parse(tbBookSalePrice.Text),
                book_description = range.Text
            };

            var bookAuth = CboBookAuth.SelectedItem as Author;
            book.auth_id = bookAuth.auth_id;

            var bookCate = CboBookCate.SelectedItem as Category;
            book.cate_id = bookCate.cate_id;

            var bookPub = CboBookPublisher.SelectedItem as Publisher;
            book.pub_id = bookPub.pub_id;
            book.book_status = true;

            book = ModelMaker.Instance.InsertBook(book);

            BookDisplay bookList = new BookDisplay
            {
                BookId = book.book_id,
                BookCover = book.book_cover,
                BookName = book.book_name,
                BookAmount = (int)book.book_amount,
                BookPrice = (decimal)book.book_price,
                BookSalePrice = (decimal)book.book_sale_price,
                BookDescription = book.book_description,
                AuthName = bookAuth.auth_name,
                CateName = bookCate.cate_name,
                PubName = bookPub.pub_name,
                BookStatus = (bool)book.book_status
            };

            dgBookList.Items.Add(bookList);

            tbBookCover.Text = string.Empty;
            tbBookName.Text = string.Empty;
            tbBookAmount.Text = string.Empty;
            tbBookPrice.Text = string.Empty;
            tbBookSalePrice.Text = string.Empty;
            range.Text = string.Empty;
        }

        //ComboBox
        private void CboBookAuth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = CboBookAuth.SelectedItem as Author;
            _ = currentItem.auth_name;
        }
        private void CboBookCate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = CboBookCate.SelectedItem as Category;
            _ = currentItem.cate_name;
        }
        private void CboBookPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = CboBookPublisher.SelectedItem as Publisher;
            _ = currentItem.pub_name;
        }
        private void BtnBookUpdate_Click(object sender, RoutedEventArgs e)
        {
            int bookId = (dgBookList.SelectedItem as BookDisplay).BookId;
            BookUpdate bookUpdate = new BookUpdate(bookId);
            bookUpdate.ShowDialog();
        }

        //Search
        private void TBSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchBook(tbSearchText.Text);
        }

        //Close
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }

    }
}
