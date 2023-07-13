﻿using MVC_DataBaseConnectivity.Models;
using System;

namespace MVC_DataBaseConnectivity.Views
{
    public class DepartmentView
    {
        public void GetAll(List<DepartmentModel> departments)
        {
            foreach (var department in departments)
            {
                GetById(department);
            }
        }

        public void GetById(DepartmentModel department)
        {
            Console.WriteLine("Id : " + department.Id);
            Console.WriteLine("Name : " + department.Name);
            Console.WriteLine("Location ID : " + department.LocationId);
            Console.WriteLine("Manager ID : " + (department.ManagerId == -1 ? "EMPTY" : department.ManagerId));
            Console.WriteLine("==========================");
        }

        public DepartmentModel Insert()
        {
            Console.Write("Input Department ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput Department Name : ");
            string name = Console.ReadLine();
            Console.Write("Input Department Location ID : ");
            int locationId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Department Manager ID : ");
            int? managerId = Convert.ToInt32(Console.ReadLine());

            return new DepartmentModel
            {
                Id = id,
                Name = name,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public DepartmentModel Update()
        {
            Console.Write("Input Department ID to Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput Updated Department Name : ");
            string name = Console.ReadLine();
            Console.Write("Input Updated Department Location ID : ");
            int locationId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Updated Department Manager ID : ");
            int? managerId = Convert.ToInt32(Console.ReadLine());

            return new DepartmentModel
            {
                Id = id,
                Name = name,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public DepartmentModel Delete()
        {
            Console.Write("Input Department ID to Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return new DepartmentModel
            {
                Id = id,
                Name = "",
                LocationId = 0,
                ManagerId = 0
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
