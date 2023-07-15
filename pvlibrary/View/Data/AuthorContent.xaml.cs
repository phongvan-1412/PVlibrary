using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class AuthorContent : UserControl
    {
        public static DataGrid datagrid;
        private readonly PVLibraryEntities pv = new PVLibraryEntities();
        private Author author = new Author();
        public AuthorContent()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            datagrid = dgAuthList;
            dgAuthList.IsReadOnly = true;
            foreach (var item in pv.Authors)
            {
                dgAuthList.Items.Add(item);
            }
        }
        private void BtnAuthSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbAuthorInfo.Document.ContentStart, rtbAuthorInfo.Document.ContentEnd);
            Author author = new Author
            {
                auth_name = tbAuthorName.Text,
                auth_information = range.Text,
                auth_status = true
            };

            author = ModelMaker.Instance.InsertAuthor(author);
            dgAuthList.Items.Add(author);

            tbAuthorName.Text = string.Empty;
            range.Text = string.Empty;
        }
        private void BtnAuthUpdate_Click(object sender, RoutedEventArgs e)
        {
            int authId = (dgAuthList.SelectedItem as Author).auth_id;
            AuthorUpdate authUpdate = new AuthorUpdate(authId);
            authUpdate.ShowDialog();
        }
        private void TBSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchAuthor(tbSearchText.Text);
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }

        //get all columns
        //dgAuthList.ItemsSource = pvLibrary.Authors.ToList();

        //các loại kết nối db
        //private void bindDataGrid()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PVLibraryEntities"].ConnectionString;
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "select * from [Author]";
        //    cmd.Connection= conn;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable("Author");
        //    da.Fill(dt);

        //    dgAuthList.ItemsSource = dt.DefaultView;
        //}

        //refresh db after submit
        //PVLibraryEntities pvLibrary = new PVLibraryEntities();
        //List<Author> authorlist = new List<Author>();
        //dgAuthList.ItemsSource = pvLibrary.Authors.ToList();
    }
}
