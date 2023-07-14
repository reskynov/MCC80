using MVC_DataBaseConnectivity.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.IO;

namespace MVC_DataBaseConnectivity.Views
{
    public class LocationView
    {
        public void GetAll(List<Location> locations)
        {
            foreach (var location in locations)
            {
                GetById(location);
            }
        }

        public void GetById(Location location)
        {
            if (location.Id is 0)
            {
                DataNotFound();
            }
            else
            {
                Console.WriteLine("Id: " + location.Id);
                Console.WriteLine("Street Address : " + (location.Street == "" ? "EMPTY" : location.Street));
                Console.WriteLine("Postal Code : " + (location.Postal == "" ? "EMPTY" : location.Postal));
                Console.WriteLine("City : " + location.City);
                Console.WriteLine("State Province : " + (location.State == "" ? "EMPTY" : location.State));
                Console.WriteLine("Country ID : " + (location.CountryId == "" ? "EMPTY" : location.CountryId));
                Console.WriteLine("==========================");
            }
        }

        public Location Insert()
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
            return new Location
            {
                Id = id,
                Street = street,
                Postal = postal,
                City = city,
                State = state,
                CountryId = countryId
            };
        }

        public Location Update()
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
            return new Location
            {
                Id = id,
                Street = street,
                Postal = postal,
                City = city,
                State = state,
                CountryId = countryId
            };
        }

        public Location Delete()
        {
            Console.Write("Input Location ID To Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return new Location
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

