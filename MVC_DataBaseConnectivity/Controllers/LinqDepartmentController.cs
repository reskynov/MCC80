using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class LinqDepartmentController
    {
        private Employee _employee;
        private Department _department;

        public LinqDepartmentController(Employee employee, Department department)
        {
            _employee = employee;
            _department = department;
        }

        public void JoinedDataDepartment()
        {
            var getEmployee = _employee.GetAll();
            var getDepartment = _department.GetAll();

            var result = (from d in getDepartment
                         join empGroup in (
                            from e in getEmployee
                            group e by e.DepartmentId into g
                            select g
                         ) on d.Id equals empGroup.Key
                         where empGroup.Count() > 3
                         select new LinqDepartment
                         {
                             DepartmentName = d.Name,
                             EmployeeCount = empGroup.Count(),
                             MinSalary = empGroup.Min(e => e.Salary),
                             MaxSalary = empGroup.Max(e => e.Salary),
                             AverageSalary = empGroup.Average(e => e.Salary)
                         }).ToList();

            LinqDepartmentView departmentView = new LinqDepartmentView();
            departmentView.JoinedDataEmployee(result);
        }
    }
}
