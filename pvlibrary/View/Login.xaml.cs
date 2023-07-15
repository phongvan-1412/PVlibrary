using pvlibrary.Model.entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace pvlibrary.View
{
    public partial class Login : Page
    {
        public string currentUserName;
        public static int currentUserId;
        public Login()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            PVLibraryEntities pv = new PVLibraryEntities();
            var employee = pv.Employees.ToList();

            try
            {
                foreach (var item in employee)
                {
                    if (tbUser.Text == item.emp_email && tbPwd.Text == item.emp_password)
                    {
                        MessageBox.Show("Login Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        currentUserName = item.emp_name;
                        Application.SetCookie(PageControl.pvLibraryApp, currentUserName);

                        currentUserId = item.emp_id;

                        PageControl.Instance.HomeMenu(new Home());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrongs with server!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }
    }
}
