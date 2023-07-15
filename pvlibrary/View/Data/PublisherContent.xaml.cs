using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class PublisherContent : UserControl
    {
        public static DataGrid dataGrid;
        private readonly PVLibraryEntities pv = new PVLibraryEntities();

        public PublisherContent()
        {
            InitializeComponent();
            ShowData();
        }
        private void ShowData()
        {
            dataGrid = dgPubList;
            foreach (var item in pv.Publishers)
            {
                dgPubList.Items.Add(item);
            }
        }
        private void BtnPubSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbPubInfo.Document.ContentStart, rtbPubInfo.Document.ContentEnd);
            Publisher publisher = new Publisher
            {
                pub_name = tbPubName.Text,
                pub_information = range.Text,
                pub_status = true
            };

            publisher = ModelMaker.Instance.InsertPublisher(publisher);
            dgPubList.Items.Add(publisher);

            tbPubName.Text = string.Empty;
            range.Text = string.Empty;
        }
        private void BtnPubUpdate_Click(object sender, RoutedEventArgs e)
        {
            int pubId = (dgPubList.SelectedItem as Publisher).pub_id;
            PublisherUpdate pubUpdate = new PublisherUpdate(pubId);
            pubUpdate.ShowDialog();
        }
        private void TBSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchPublisher(tbSearchText.Text);
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }

    }
}
