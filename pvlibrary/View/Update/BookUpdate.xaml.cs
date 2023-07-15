using Microsoft.Win32;
using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace pvlibrary.View.Update
{
    public partial class BookUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int bookId;
        public BookUpdate(int bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            ShowTextData();
            CboDataContent();
        }
        private void ShowTextData()
        {
            TextRange range = new TextRange(rtbBookDes.Document.ContentStart, rtbBookDes.Document.ContentEnd);

            var temp = (from b in pv.Books where b.book_id == bookId select b).First();
            tbBookName.Text = temp.book_name;
            tbBookCover.Text = temp.book_cover;
            tbBookAmount.Text = (temp.book_amount).ToString();
            tbBookPrice.Text = (temp.book_price).ToString();
            tbBookSalePrice.Text = (temp.book_sale_price).ToString();
            range.Text = temp.book_description;
        }
        private void CboDataContent()
        {
            var p = pv.Authors.ToList();
            CboBookAuth.ItemsSource = p;

            var q = pv.Categories.ToList();
            CboBookCate.ItemsSource = q;

            var r = pv.Publishers.ToList();
            CboBookPublisher.ItemsSource = r;

        }
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
        private void BtnUpdateBookCover_Click(object sender, RoutedEventArgs e)
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
        private void BtnBookUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbBookDes.Document.ContentStart, rtbBookDes.Document.ContentEnd);

            Book updateBookDisplay = (from bd in pv.Books where bd.book_id == bookId select bd).Single();
            updateBookDisplay.book_cover = tbBookCover.Text;
            updateBookDisplay.book_name = tbBookName.Text;
            updateBookDisplay.book_amount = int.Parse(tbBookAmount.Text);
            updateBookDisplay.book_price = decimal.Parse(tbBookPrice.Text);
            updateBookDisplay.book_sale_price = decimal.Parse(tbBookSalePrice.Text);
            updateBookDisplay.book_description = range.Text;

            var bookAuth = CboBookAuth.SelectedItem as Author;
            updateBookDisplay.auth_id = bookAuth.auth_id;

            var bookCate = CboBookCate.SelectedItem as Category;
            updateBookDisplay.cate_id = bookCate.cate_id;

            var bookPub = CboBookPublisher.SelectedItem as Publisher;
            updateBookDisplay.pub_id = bookPub.pub_id;

            updateBookDisplay.book_status = ckBookStatus.IsChecked;

            updateBookDisplay = ModelMaker.Instance.UpdateBook(updateBookDisplay);

            BookContent.datagrid.Items.Clear();
            foreach (var item in pv.Books)
            {
                BookDisplay bookList = new BookDisplay
                {
                    BookId = item.book_id,
                    BookCover = item.book_cover,
                    BookName = item.book_name,
                    BookAmount = (int)item.book_amount,
                    BookPrice = (decimal)item.book_price,
                    BookSalePrice = (decimal)item.book_sale_price,
                    BookDescription = item.book_description,
                    AuthName = item.Author.auth_name,
                    CateName = item.Category.cate_name,
                    PubName = item.Publisher.pub_name,
                    BookStatus = (bool)item.book_status
                };

                BookContent.datagrid.Items.Add(bookList);
            }

            MessageBox.Show("Update Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
