using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;

namespace pvlibrary.View.Update
{
    public partial class CategoryUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int cateId;
        public CategoryUpdate(int cateId)
        {
            InitializeComponent();
            this.cateId = cateId;
            ShowTextData();
        }
        private void ShowTextData()
        {
            var temp = (from c in pv.Categories where c.cate_id == cateId select c).First();
            tbCateName.Text = temp.cate_name;
        }
        private void BtnCateUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            Category cateUpdate = (from c in pv.Categories where c.cate_id == cateId select c).Single();

            cateUpdate.cate_name = tbCateName.Text;
            cateUpdate.cate_status = ckCateStatus.IsChecked;

            cateUpdate = ModelMaker.Instance.UpdateCategory(cateUpdate);

            CategoryContent.dataGrid.Items.Clear();
            foreach (var item in pv.Categories)
            {
                CategoryContent.dataGrid.Items.Add(item);
            }

            Close();
        }
    }
}
