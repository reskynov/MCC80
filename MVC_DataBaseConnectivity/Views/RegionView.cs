using MVC_DataBaseConnectivity.Models;
using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Views
{
    public class RegionView
    {
        public void GetAll(List<RegionModel> regions)
        {
            foreach (var region in regions)
            {
                GetById(region);
            }
        }

        public void GetById(RegionModel region)
        {
            Console.WriteLine("Id: " + region.Id);
            Console.WriteLine("Name : " + region.Name);
            Console.WriteLine("==========================");
        }

        public RegionModel Insert()
        {
            Console.Write("Input Region Name : ");
            string name = Console.ReadLine();
            return new RegionModel
            {
                Id = 0,
                Name = name,
            };
        }

        public RegionModel Update()
        {
            Console.Write("Input Region ID To Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput Region Updated Name : ");
            string name = Console.ReadLine();
            return new RegionModel
            {
                Id = id,
                Name = name,
            };
        }

        public RegionModel Delete()
        {
            Console.Write("Input Region ID To Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return new RegionModel
            {
                Id = id,
                Name = "",
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
            Console.WriteLine("\nDATA REGION IS EMPTY");
        }

        public void DataNotFound()
        {
            Console.WriteLine("\nDATA REGION NOT FOUND");
        }

        public void ErrorDatabase()
        {
            Console.WriteLine("\nError Connecting to Database");
        }
    }
}
