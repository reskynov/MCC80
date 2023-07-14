using MVC_DataBaseConnectivity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Views
{
    public class LinqDepartmentView
    {
        public void JoinedDataEmployee(List<LinqDepartment> joinedData)
        {
            if (joinedData != null)
            {
                foreach (var data in joinedData)
                {
                    Console.WriteLine("Department Name : " + data.DepartmentName);
                    Console.WriteLine("Employee Count : " + data.EmployeeCount);
                    Console.WriteLine("Min Salary : " + data.MinSalary);
                    Console.WriteLine("Max Salary : " + data.MaxSalary);
                    Console.WriteLine("Average Salary : " + data.AverageSalary);
                    Console.WriteLine("========================================");
                }
            }
            else
            {
                Console.WriteLine("DATA IS EMPTY");
            }
        }
    }
}
