using MVC_DataBaseConnectivity.Controllers;
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
                Console.WriteLine("8. Exit");
                Console.Write("Input Menu : ");
                string inputMainMenu = Console.ReadLine();
                switch (inputMainMenu)
                {
                    case "1":
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        backToMain = JobMenu("jobs", backToMain);
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        backToMain = CountryMenu("countries", backToMain);
                        break;
                    case "7":
                        Console.Clear();
                        backToMain = RegionMenu("regions", backToMain);
                        break;
                    case "8":
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("\nINVALID INPUT!!! TRY AGAIN!!");
                        PressAnyKey();
                        backToMain = true;
                        break;
                }
            }
        }

        public static bool JobMenu(string menuName, bool backToMain)
        {
            JobModel job = new JobModel();
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
                            Console.Write("Input ID Region to Search : ");
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
                            Console.WriteLine("INVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("INVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        public static bool CountryMenu(string menuName, bool backToMain)
        {
            CountryModel country = new CountryModel();
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
                            Console.Write("Input ID Region to Search : ");
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
                            Console.WriteLine("INVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("INVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

        public static bool RegionMenu(string menuName, bool backToMain)
        {
            RegionModel region = new RegionModel();
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
                            Console.WriteLine("INVALID INPUT!!! RETRY AGAIN!!");
                            backToSub = true;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("INVALID INPUT!!! RETRY AGAIN!!");
                }
            }
            return backToMain;
        }

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

        public static void PressAnyKey()
        {
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}