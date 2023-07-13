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
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "7":
                        Console.Clear();
                        backToMain = RegionMenu("regions", backToMain);
                        Console.Clear();
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

        public static bool CountryMenu(string menuName, bool backToMain)
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
                            return backToMain;
                            break;
                        default:

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
                            return backToMain;
                            break;
                        default:

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