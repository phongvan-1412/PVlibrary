using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace pvlibrary.View.Update
{
    public partial class AuthorUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int authId;
        public AuthorUpdate(int authId)
        {
            InitializeComponent();
            this.authId = authId;
            ShowTextData();
        }
        private void ShowTextData()
        {
            TextRange range = new TextRange(rtbAuthInfo.Document.ContentStart, rtbAuthInfo.Document.ContentEnd);

            var temp = (from a in pv.Authors where a.auth_id == authId select a).First();
            tbAuthName.Text = temp.auth_name;
            range.Text = temp.auth_information;
        }
        private void BtnAuthUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbAuthInfo.Document.ContentStart, rtbAuthInfo.Document.ContentEnd);
            Author authorUpdate = (from a in pv.Authors where a.auth_id == authId select a).Single();

            authorUpdate.auth_name = tbAuthName.Text;
            authorUpdate.auth_information = range.Text;
            authorUpdate.auth_status = ckAuthStatus.IsChecked;

            authorUpdate = ModelMaker.Instance.UpdateAuthor(authorUpdate);

            AuthorContent.datagrid.Items.Clear();

            foreach (var item in pv.Authors)
            {
                AuthorContent.datagrid.Items.Add(item);
            }

            Close();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
