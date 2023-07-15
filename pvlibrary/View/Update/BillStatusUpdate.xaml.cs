using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;

namespace pvlibrary.View.Update
{
    public partial class BillStatusUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int bsId;
        public BillStatusUpdate(int bsId)
        {
            InitializeComponent();
            this.bsId = bsId;
            ShowTextData();
        }
        private void ShowTextData()
        {
            var temp = (from bs in pv.BillStatus where bs.bs_id == bsId select bs).First();
            tbBsName.Text = temp.bs_name;
        }
        private void BtnBsUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            BillStatu bsUpdate = (from bs in pv.BillStatus where bs.bs_id == bsId select bs).Single();

            bsUpdate.bs_name = tbBsName.Text;
            bsUpdate.bs_status = ckBsStatus.IsChecked;

            bsUpdate = ModelMaker.Instance.UpdateBillStatus(bsUpdate);

            BillContent.dataGridBs.Items.Clear();
            foreach (var item in pv.BillStatus)
            {
                BillContent.dataGridBs.Items.Add(item);
            }

            Close();
        }
    }
}
