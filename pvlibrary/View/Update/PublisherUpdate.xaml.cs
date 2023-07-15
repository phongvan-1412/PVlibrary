using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace pvlibrary.View.Update
{
    public partial class PublisherUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int pubId;
        public PublisherUpdate(int pubId)
        {
            InitializeComponent();
            this.pubId = pubId;
            ShowTextData();
        }
        private void ShowTextData()
        {
            TextRange range = new TextRange(rtbPubInfo.Document.ContentStart, rtbPubInfo.Document.ContentEnd);

            var temp = (from pub in pv.Publishers where pub.pub_id == pubId select pub).First();
            tbPubName.Text = temp.pub_name;
            range.Text = temp.pub_information;
        }
        private void BtnPubUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbPubInfo.Document.ContentStart, rtbPubInfo.Document.ContentEnd);
            Publisher pubUpdate = (from pub in pv.Publishers where pub.pub_id == pubId select pub).Single();

            pubUpdate.pub_name = tbPubName.Text;
            pubUpdate.pub_information = range.Text;
            pubUpdate.pub_status = ckPubStatus.IsChecked;

            pubUpdate = ModelMaker.Instance.UpdatePublisher(pubUpdate);

            PublisherContent.dataGrid.Items.Clear();
            foreach (var item in pv.Publishers)
            {
                PublisherContent.dataGrid.Items.Add(item);
            }

            tbPubName.Text = string.Empty;
            range.Text = string.Empty;

            Close();
        }
    }
}
