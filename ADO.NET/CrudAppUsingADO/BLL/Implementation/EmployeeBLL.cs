using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using DataLayer.Implementation;

namespace BLL.Implementation
{
    public class EmployeeBLL
    {
        public bool SaveEmployee(EmployeeInfo employeeInfo)
        {
            bool result = false;
            if (employeeInfo != null)
            {
                EmployeeDLL employeeDLL = new EmployeeDLL();
                result = employeeDLL.SaveEmployee(employeeInfo);
               // new EmployeeDLL().SaveEmployee(employeeInfo);
            }
            return result;
        }

        public List<EmployeeInfo> GetEmployeesBLL()
        {
                EmployeeDLL employeeDLL = new EmployeeDLL();
                return employeeDLL.GetEmployeesDAL();
        }

        public void DeleteEmployeeBLL(int id)
        {
            EmployeeDLL employeeDLL = new EmployeeDLL();
            employeeDLL.DeleteEmployeeDLL(id);
        }

        public EmployeeInfo GetEmployeeByIdBLL(int id)
        {
            EmployeeDLL employeeDLL = new EmployeeDLL();
            return employeeDLL.GetEmployeeByIdDLL(id);
        }

        public EmployeeInfo EditEmployeeBLL(int id)
        {
            EmployeeDLL employeeDLL = new EmployeeDLL();
            employeeDLL.EditEmployeeDLL(id);
            return new EmployeeInfo();
        }

    }
}
