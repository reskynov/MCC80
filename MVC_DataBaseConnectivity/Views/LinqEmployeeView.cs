using MVC_DataBaseConnectivity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Views
{
    public class LinqEmployeeView
    {
        public void JoinedDataEmployee(List<LinqEmployee> joinedData)
        {
            if(joinedData != null) 
            {
                foreach (var data in joinedData)
                {
                    Console.WriteLine("ID Employee : " + data.Id);
                    Console.WriteLine("Full Name : " + data.FullName);
                    Console.WriteLine("Email : " + data.Email);
                    Console.WriteLine("Phone Number : " + data.Phone);
                    Console.WriteLine("Salary : " + data.Salary);
                    Console.WriteLine("Department Name : " + data.DepartmentName);
                    Console.WriteLine("Street Address : " + data.Street);
                    Console.WriteLine("Country Name : " + data.Country);
                    Console.WriteLine("Region Name : " + data.Region);
                    Console.WriteLine("===============================");
                }
            }
            else
            {
                Console.WriteLine("DATA IS EMPTY");
            }
        }
    }
}
