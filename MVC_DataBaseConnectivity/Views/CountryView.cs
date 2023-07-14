using MVC_DataBaseConnectivity.Models;
using System;

namespace MVC_DataBaseConnectivity.Views
{
    public class CountryView
    {
        public void GetAll(List<Country> countries)
        {
            foreach (var country in countries)
            {
                GetById(country);
            }
        }

        public void GetById(Country country)
        {
            if (country.Id is null)
            {
                DataNotFound();
            }
            else
            {
                Console.WriteLine("Id: " + country.Id);
                Console.WriteLine("Name: " + country.Name);
                Console.WriteLine("==========================");
            }
        }

        public Country Insert()
        {
            Console.Write("Input Country ID : ");
            string id = Console.ReadLine();
            Console.Write("\nInput Country Name : ");
            string name = Console.ReadLine();
            Console.Write("Input Country Region ID : ");
            int regionId = Convert.ToInt32(Console.ReadLine());
            return new Country
            {
                Id = id,
                Name = name,
                RegionId = regionId
            };
        }

        public Country Update()
        {
            Console.Write("Input Country ID to Update : ");
            string id = Console.ReadLine();
            Console.Write("\nInput Updated Country Name : ");
            string name = Console.ReadLine();
            Console.Write("Input Updated Country Region ID : ");
            int regionId = Convert.ToInt32(Console.ReadLine());
            return new Country
            {
                Id = id,
                Name = name,
                RegionId = regionId
            };
        }

        public Country Delete()
        {
            Console.Write("Input Country ID To Delete : ");
            string id = Console.ReadLine();
            return new Country
            {
                Id = id,
                Name = "",
                RegionId = 0
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