using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Update;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pvlibrary.View.Data
{
    public partial class EmployeeContent : UserControl
    {
        public static DataGrid dataGrid;
        private readonly PVLibraryEntities pv = new PVLibraryEntities();

        public EmployeeContent()
        {
            InitializeComponent();
            ShowData();
        }
        private void ShowData()
        {
            dataGrid = dgEmpList;
            foreach (var item in pv.Employees)
            {
                dgEmpList.Items.Add(item);
            }
        }
        private void BtnEmpSubmit_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee
            {
                emp_name = tbEmpName.Text,
                emp_email = tbEmpEmail.Text
            };

            if (emp.emp_password != "")
            {
                emp.emp_password = tbEmpPwd.Text;
            }
            else
            {
                emp.emp_password = "123";
            }

            emp.emp_status = true;

            emp = ModelMaker.Instance.InsertEmployee(emp);
            dgEmpList.Items.Add(emp);

            tbEmpName.Text = string.Empty;
            tbEmpEmail.Text = string.Empty;
        }
        private void BtnEmpUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            int empId = (dgEmpList.SelectedItem as Employee).emp_id;
            EmployeeUpdate empUpdate = new EmployeeUpdate(empId);
            empUpdate.ShowDialog();
        }
        private void TBSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _ = ModelMaker.Instance.SearchEmployee(tbSearchText.Text);
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }
    }
}
