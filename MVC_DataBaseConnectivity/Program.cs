﻿using MVC_DataBaseConnectivity.Controllers;
using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity
{
    public class Program
    {
        public static void Main()
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            bool backToMain = true;
            while (backToMain)
            {
                backToMain = false;
                Console.WriteLine("== DATABASE EKY BERSAMA ==");
                Console.WriteLine("== Menu Database HR == ");
                Console.WriteLine("1. Employees");
                Console.WriteLine("2. Departments");
                Console.WriteLine("3. Jobs");
                Console.WriteLine("4. Histories");
                Console.WriteLine("5. Locations");
                Console.WriteLine("6. Countries");
                Console.WriteLine("7. Regions");
                Console.WriteLine("8. Filtered Employee");
                Console.WriteLine("9. Employee Group By Department");
                Console.WriteLine("10. Exit");
                Console.Write("Input Menu : ");
                string inputMainMenu = Console.ReadLine();
                switch (inputMainMenu)
                {
                    //employee
                    case "1":
                        Console.Clear();
                        backToMain = EmployeeMenu("employees", backToMain);
                        break;
                    //department
                    case "2":
                        Console.Clear();
                        backToMain = DepartmentMenu("departments", backToMain);
                        break;
                    //job
                    case "3":
                        Console.Clear();
                        backToMain = JobMenu("jobs", backToMain);
                        break;
                    //history
                    case "4":
                        Console.Clear();
                        backToMain = HistoryMenu("histories", backToMain);
                        break;
                    //location
                    case "5":
                        Console.Clear();
                        backToMain = LocationMenu("locations", backToMain);
                        break;
                    //country
                    case "6":
                        Console.Clear();
                        backToMain = CountryMenu("countries", backToMain);
                        break;
                    //region
                    case "7":
                        Console.Clear();
                        backToMain = RegionMenu("regions", backToMain);
                        break;
                    //exit
                    case "8":
                        Console.Clear();
                        Employee employee = new Employee();
                        Department department = new Department();
                        Location location = new Location();
                        Country country = new Country();
                        Region region = new Region();

                        LinqEmployeeController linqE = new LinqEmployeeController(employee, department, location, country, region);
                        linqE.JoinedDataEmployee();
                        break;

                    case "9":
                        Console.Clear();
                        Employee employees = new Employee();
                        Department departments = new Department();
                        LinqDepartmentController linqD = new LinqDepartmentController(employees, departments);
                        linqD.JoinedDataDepartment();
                        break;
                    case "10":
                        System.Environment.Exit(1);
                        break;
                    //different input
                    default:
                        Console.WriteLine("\nINVALID INPUT!!! TRY AGAIN!!");
                        PressAnyKey();
                        backToMain = true;
                        break;
                }
            }
        }

        //Menu 1
        public static bool EmployeeMenu(string menuName, bool backToMain)
        {
            Employee employee = new Employee();
            EmployeeView vEmployee = new EmployeeView();
            EmployeeController employeeController = new EmployeeController(employee, vEmployee);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            employeeController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Department to Search : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            employeeController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            employeeController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            employeeController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            employeeController.Delete();
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Menu 2
        public static bool DepartmentMenu(string menuName, bool backToMain)
        {
            Department department = new Department();
            DepartmentView vDepartment = new DepartmentView();
            DepartmentController departmentController = new DepartmentController(department, vDepartment);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            departmentController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Department to Search : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            departmentController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            departmentController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            departmentController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            departmentController.Delete();
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Menu 3
        public static bool JobMenu(string menuName, bool backToMain)
        {
            Job job = new Job();
            JobView vJob = new JobView();
            JobController jobController = new JobController(job, vJob);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            jobController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Job to Search : ");
                            string id = Console.ReadLine();
                            jobController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            jobController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            jobController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            jobController.Delete();
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Menu 4
        public static bool HistoryMenu(string menuName, bool backToMain)
        {
            History history = new History();
            HistoryView vHistory = new HistoryView();
            HistoryController historyController = new HistoryController(history, vHistory);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            historyController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Employee to Search History : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            historyController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            historyController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            historyController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            historyController.Delete();
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Menu 5
        public static bool LocationMenu(string menuName, bool backToMain)
        {
            Location location = new Location();
            LocationView vLocation = new LocationView();
            LocationController locationController = new LocationController(location, vLocation);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            locationController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Country to Search : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            locationController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            locationController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            locationController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            locationController.Delete();
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Menu 6
        public static bool CountryMenu(string menuName, bool backToMain)
        {
            Country country = new Country();
            CountryView vCountry = new CountryView();
            CountryController countryController = new CountryController(country, vCountry);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            countryController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Country to Search : ");
                            string id = Console.ReadLine();
                            countryController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            countryController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            countryController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            countryController.Delete();
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Menu 7
        public static bool RegionMenu(string menuName, bool backToMain)
        {
            Region region = new Region();
            RegionView vRegion = new RegionView();  
            RegionController regionController = new RegionController(region, vRegion);

            bool backToSub = true;
            while (backToSub)
            {
                PrintSubMenu(menuName);

                Console.Write("Input Menu : ");
                try
                {
                    string inputSubMenu = Console.ReadLine();
                    switch (inputSubMenu)
                    {
                        case "1":
                            Console.Clear();
                            regionController.GetAll();
                            PressAnyKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Input ID Region to Search : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            regionController.GetById(id);
                            PressAnyKey();
                            break;
                        case "3":
                            Console.Clear();
                            regionController.Insert();
                            PressAnyKey();
                            break;
                        case "4":
                            Console.Clear();
                            regionController.Update();
                            PressAnyKey();
                            break;
                        case "5":
                            Console.Clear();
                            regionController.Delete();  
                            PressAnyKey();
                            break;
                        case "6":
                            backToMain = true;
                            backToSub = false;
                            Console.Clear();
                            return backToMain;
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nINVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        //Print Sub Menu
        public static void PrintSubMenu(string menuName)
        {
            Console.WriteLine("== MENU " + menuName.ToUpper() + " ==");
            Console.WriteLine("1. Show All Data");
            Console.WriteLine("2. Search Data");
            Console.WriteLine("3. Insert Data");
            Console.WriteLine("4. Update Data");
            Console.WriteLine("5. Delete Data");
            Console.WriteLine("6. Back");
        }

        //Waiting for user Pressed any Key
        public static void PressAnyKey()
        {
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}