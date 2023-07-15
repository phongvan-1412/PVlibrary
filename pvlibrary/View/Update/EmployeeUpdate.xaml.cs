using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System.Linq;
using System.Windows;

namespace pvlibrary.View.Update
{
    public partial class EmployeeUpdate : Window
    {
        readonly PVLibraryEntities pv = new PVLibraryEntities();
        readonly int empId;
        public EmployeeUpdate(int empId)
        {
            InitializeComponent();
            this.empId = empId;
            ShowTextData();
        }
        private void ShowTextData()
        {
            var temp = (from emp in pv.Employees where emp.emp_id == empId select emp).First();
            tbEmpName.Text = temp.emp_name;
            tbEmpEmail.Text = temp.emp_email;
            tbEmpPwd.Text = temp.emp_password;
        }
        private void BtnEmpUpdateSubmit_Click(object sender, RoutedEventArgs e)
        {
            Employee empUpdate = (from emp in pv.Employees where emp.emp_id == empId select emp).Single();

            empUpdate.emp_name = tbEmpName.Text;
            empUpdate.emp_email = tbEmpEmail.Text;
            empUpdate.emp_password = tbEmpPwd.Text;
            empUpdate.emp_status = ckEmpStatus.IsChecked;

            empUpdate = ModelMaker.Instance.UpdateEmployee(empUpdate);

            EmployeeContent.dataGrid.Items.Clear();
            foreach (var item in pv.Employees)
            {
                EmployeeContent.dataGrid.Items.Add(item);
            }

            empUpdate.emp_name = string.Empty;
            empUpdate.emp_email = string.Empty;
            empUpdate.emp_password = string.Empty;

            Close();
        }
    }
}
