using MVC_DataBaseConnectivity.Models;
using System;
using System.Reflection.PortableExecutable;

namespace MVC_DataBaseConnectivity.Views
{
    public class EmployeeView
    {
        public void GetAll(List<EmployeeModel> employees)
        {
            foreach (var employee in employees)
            {
                GetById(employee);
            }
        }

        public void GetById(EmployeeModel employee)
        {
            Console.Write("ID : " + employee.Id);
            Console.Write("Full Name : " + employee.Fname + " "+ employee.Lname);
            Console.Write("Email : " + employee.Email);
            Console.Write("Phone Number : " + employee.Phone);
            Console.Write("Hire Date : " + employee.HireDate);
            Console.Write("Salary : " + employee.Salary);
            Console.Write("Commission : " + employee.Comission);

            int managerId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            string managerIdString = "";
            if (managerId == 0)
            {
                managerIdString = "EMPTY";
            }
            else
            {
                managerIdString = managerId.ToString();
            }
            Console.WriteLine(", Manager ID : " + managerIdString);

            Console.Write("Job ID : " + reader.GetString(9));
            Console.WriteLine("Department ID : " + reader.GetInt32(10));
            Console.WriteLine();
            Console.WriteLine("==========================");
        }

        public LocationModel Insert()
        {
            Console.Write("Input Location ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Location Street Address : ");
            string street = Console.ReadLine();
            Console.Write("Input Location Postal Code : ");
            string postal = Console.ReadLine();
            Console.Write("Input Location City : ");
            string city = Console.ReadLine();
            Console.Write("Input Location State Province : ");
            string state = Console.ReadLine();
            Console.Write("Input Location Country ID : ");
            string countryId = Console.ReadLine();
            return new LocationModel
            {
                Id = id,
                Street = street,
                Postal = postal,
                City = city,
                State = state,
                CountryId = countryId
            };
        }

        public LocationModel Update()
        {
            Console.Write("Input Location ID to Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Updated Location Street Address : ");
            string street = Console.ReadLine();
            Console.Write("Input Updated Location Postal Code : ");
            string postal = Console.ReadLine();
            Console.Write("Input Updated Location City : ");
            string city = Console.ReadLine();
            Console.Write("Input Updated Location State Province : ");
            string state = Console.ReadLine();
            Console.Write("Input Updated Location Country ID : ");
            string countryId = Console.ReadLine();
            return new LocationModel
            {
                Id = id,
                Street = street,
                Postal = postal,
                City = city,
                State = state,
                CountryId = countryId
            };
        }

        public LocationModel Delete()
        {
            Console.Write("Input Location ID To Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return new LocationModel
            {
                Id = id,
                Street = "",
                Postal = "",
                City = "",
                State = "",
                CountryId = ""
            };
        }

        public void Success()
        {
            Console.WriteLine("\nSUCCESS!!");
        }

        public void Failed()
        {
            Console.WriteLine("\nFAILED!!! Check Input Data Again!!");
        }

        public void DataEmpty()
        {
            Console.WriteLine("\nDATA IS EMPTY");
        }

        public void DataNotFound()
        {
            Console.WriteLine("\nDATA NOT FOUND");
        }

        public void ErrorDatabase()
        {
            Console.WriteLine("\nError Connecting to Database");
        }
    }
}

