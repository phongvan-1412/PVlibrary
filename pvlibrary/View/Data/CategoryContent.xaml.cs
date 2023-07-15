using DevExpress.XtraReports.Parameters;
using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class CategoryContent : UserControl
    {
        public static DataGrid dataGrid;
        private readonly PVLibraryEntities pv = new PVLibraryEntities();
        public CategoryContent()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dataGrid = dgCateList;
            dgCateList.IsReadOnly = true;
            foreach (var item in pv.Categories)
            {
                dgCateList.Items.Add(item);
            }
        }
        private void BtnCateSubmit_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category
            {
                cate_name = tbCateName.Text,
                cate_status = true
            };

            category = ModelMaker.Instance.InsertCategory(category);
            dgCateList.Items.Add(category);

            category.cate_name = string.Empty;
        }
        private void BtnCateUpdate_Click(object sender, RoutedEventArgs e)
        {
            int cateId = (dgCateList.SelectedItem as Category).cate_id;
            CategoryUpdate cateUpdate = new CategoryUpdate(cateId);
            cateUpdate.ShowDialog();
        }
        private void TBSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchCategory(tbSearchText.Text);
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }

    }
}
