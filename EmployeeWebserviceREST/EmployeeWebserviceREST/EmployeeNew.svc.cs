using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeWebserviceREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeNew.svc or EmployeeNew.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeNew : IEmployee
    {
        EmployeeDataDataContext db = new EmployeeDataDataContext();
        public bool AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                Employee employeeDelete =
                    (from employee in db.Employees where employee.empID == id select employee).Single();
                db.Employees.DeleteOnSubmit(employeeDelete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetProductList()
        {
            try
            {
                return (from employee in db.Employees select employee).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool PutEmployee(Employee emp)
        {
            Employee employeeToModify =
                (from employee in db.Employees where employee.empID == emp.empID select employee).Single();
            employeeToModify.age = emp.age;
            employeeToModify.address = emp.address;
            employeeToModify.firstName = emp.firstName;
            employeeToModify.lastName = emp.lastName;
            db.SubmitChanges();
            return true;
        }
    }
}
