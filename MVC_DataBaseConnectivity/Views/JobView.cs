using MVC_DataBaseConnectivity.Models;
using System;
using System.Diagnostics.Metrics;

namespace MVC_DataBaseConnectivity.Views
{
    public class JobView
    {
        public void GetAll(List<Job> jobs)
        {
            foreach (var job in jobs)
            {
                GetById(job);
            }
        }

        public void GetById(Job job)
        {
            if (job.Id is null)
            {
                DataNotFound();
            }
            else
            {
                Console.WriteLine("Id : " + job.Id);
                Console.WriteLine("Title : " + job.Title);
                Console.WriteLine("Salary Range : $" + job.MinSalary + " - $" + job.MaxSalary);
                Console.WriteLine("==========================");
            }
        }

        public Job Insert()
        {
            Console.Write("Input Job ID : ");
            string id = Console.ReadLine();
            Console.Write("\nInput Job Title : ");
            string title = Console.ReadLine();
            Console.Write("Input Min Salary : ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Max Salary : ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());
            return new Job
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public Job Update()
        {
            Console.Write("Input Job ID to Update: ");
            string id = Console.ReadLine();
            Console.Write("\nInput Updated Job Title : ");
            string title = Console.ReadLine();
            Console.Write("Input Updated Min Salary : ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Updated Max Salary : ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());
            return new Job
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public Job Delete()
        {
            Console.Write("Input Job ID To Delete : ");
            string id = Console.ReadLine();
            return new Job
            {
                Id = id,
                Title = "",
                MinSalary = 0,
                MaxSalary = 0
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
