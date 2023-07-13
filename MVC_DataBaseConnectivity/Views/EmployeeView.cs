using MVC_DataBaseConnectivity.Models;
using System;
using System.Numerics;
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
            Console.WriteLine("ID : " + employee.Id);
            if (employee.Lname == null || employee.Lname == "")
            {
                Console.WriteLine("Full Name : " + employee.Fname);
            }
            else
            {
                Console.WriteLine("Full Name : " + employee.Fname + " " + employee.Lname);
            }
            Console.WriteLine("Email : " + employee.Email);
            Console.WriteLine("Phone Number : " + (employee.Phone == "" ? "NULL" : employee.Phone));
            Console.WriteLine("Hire Date : " + employee.HireDate);
            Console.WriteLine("Salary : " + (employee.Salary == -1 ? 0 : employee.Salary));
            Console.WriteLine("Commission : " + (employee.Comission == 0 ? "NULL" : employee.Comission));
            Console.WriteLine("Manager ID : " + (employee.ManagerId == -1 ? "EMPTY" : employee.ManagerId));
            Console.WriteLine("Job ID : " + employee.JobId);
            Console.WriteLine("Department ID : " + employee.DepartmentId);
            Console.WriteLine("==========================");
        }

        public EmployeeModel Insert()
        {
            Console.Write("\nInput Employee's ID : ");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Input Employee's First Name : ");
            string fname = Console.ReadLine();

            Console.Write("Input Employee's Last Name: ");
            string lname = Console.ReadLine();

            Console.Write("Input Employee's Email: ");
            string email = Console.ReadLine();

            Console.Write("Input Employee's Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Input Employee's Salary : $");
            int salary = Int32.Parse(Console.ReadLine());

            Console.Write("Input Employee's Commisiion PCT : ");
            decimal comiss = Decimal.Parse(Console.ReadLine());

            Console.Write("Input Employee's Manager ID : ");
            int managerId = Int32.Parse(Console.ReadLine());

            Console.Write("Input Employee's Job ID : ");
            string jobId = Console.ReadLine();

            Console.Write("Input Employee's Department ID : ");
            int departmentId = Int32.Parse(Console.ReadLine());

            return new EmployeeModel
            {
                Id = id,
                Fname = fname,
                Lname = lname,
                Email = email,
                Phone = phone,
                HireDate = DateTime.Now,
                Salary = salary,
                Comission = comiss,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            };
        }

        public EmployeeModel Update()
        {
            Console.Write("Input Employee's ID to Update : ");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Input Updated Employee's First Name : ");
            string fname = Console.ReadLine();

            Console.Write("Input Updated Employee's Last Name: ");
            string lname = Console.ReadLine();

            Console.Write("Input Updated Employee's Email: ");
            string email = Console.ReadLine();

            Console.Write("Input Updated Employee's Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Input Updated Employee's Salary : $");
            int salary = Int32.Parse(Console.ReadLine());

            Console.Write("Input Updated Employee's Commisiion PCT : ");
            decimal comiss = Decimal.Parse(Console.ReadLine());

            Console.Write("Input Updated Employee's Manager ID : ");
            int managerId = Int32.Parse(Console.ReadLine());

            Console.Write("Input Updated Employee's Job ID : ");
            string jobId = Console.ReadLine();

            Console.Write("Input Updated Employee's Department ID : ");
            int departmentId = Int32.Parse(Console.ReadLine());

            return new EmployeeModel
            {
                Id = id,
                Fname = fname,
                Lname = lname,
                Email = email,
                Phone = phone,
                HireDate = DateTime.Now,
                Salary = salary,
                Comission = comiss,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            };
        }

        public EmployeeModel Delete()
        {
            Console.Write("Input Employee ID To Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return new EmployeeModel
            {
                Id = id,
                Fname = "",
                Lname = "",
                Email = "",
                Phone = "",
                HireDate = DateTime.Now,
                Salary = 0,
                Comission = 0,
                ManagerId = -1,
                JobId = "",
                DepartmentId = -1
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

