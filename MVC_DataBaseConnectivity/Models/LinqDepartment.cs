using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Models
{
    public class LinqDepartment
    {
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public int? MinSalary { get; set;}
        public int? MaxSalary { get; set; }
        public double? AverageSalary { get; set; }

}
}
