using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class EmployeeStorage : IEmployeeRepository
    {
        public void RemoveEmployee(int id)
        {
            var employeeContext = new EmployeeContext();

            var employee = employeeContext.Employees.Find(id);
            employeeContext.Employees.Remove(employee);
            employeeContext.SaveChanges();
        }
    }
}
