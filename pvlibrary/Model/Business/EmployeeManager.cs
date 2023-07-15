using pvlibrary.Model.entities;
using pvlibrary.Model.ModelPattern;
using pvlibrary.View.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace pvlibrary.Model.Business
{
    internal class EmployeeManager : AFacadeDb<Employee>
    {
        public override bool InsertDb(Employee db)
        {
            try
            {
                entities.Employees.Add(db);
                entities.SaveChanges();
                MessageBox.Show("Add Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fail!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        public override bool UpdateDb(Employee db)
        {
            try
            {
                entities.Employees.AddOrUpdate(db);
                entities.SaveChanges();
                MessageBox.Show("Update Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fail!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        public override List<Employee> SearchDb(string searchText)
        {
            try
            {
                var searchArray = entities.Employees.Where(emp =>  
                                  emp.emp_name.Contains(searchText)
                               || emp.emp_email.Contains(searchText)
                               || emp.emp_password.Contains(searchText)).ToList();

                EmployeeContent.dataGrid.Items.Clear();
                foreach (var item in searchArray)
                {
                    EmployeeContent.dataGrid.Items.Add(item);
                }
                return searchArray;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}
