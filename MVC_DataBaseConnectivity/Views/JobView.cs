using MVC_DataBaseConnectivity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Views
{
    public class JobView
    {
        public void GetAll(List<JobModel> jobs)
        {
            foreach (var job in jobs)
            {
                GetById(job);
            }
        }

        public void GetById(JobModel job)
        {
            Console.WriteLine("Id : " + job.Id);
            Console.WriteLine("Title : " + job.Title);
            Console.WriteLine("Salary Range : $" + job.MinSalary + " - $" + job.MaxSalary);
            Console.WriteLine("==========================");
        }

        public JobModel Insert()
        {
            Console.Write("Input Job ID : ");
            string id = Console.ReadLine();
            Console.Write("\nInput Job Title : ");
            string title = Console.ReadLine();
            Console.Write("Input Min Salary : ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Max Salary : ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());
            return new JobModel
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public JobModel Update()
        {
            Console.Write("Input Job ID to Update: ");
            string id = Console.ReadLine();
            Console.Write("\nInput Updated Job Title : ");
            string title = Console.ReadLine();
            Console.Write("Input Updated Min Salary : ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Updated Max Salary : ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());
            return new JobModel
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public JobModel Delete()
        {
            Console.Write("Input Job ID To Delete : ");
            string id = Console.ReadLine();
            return new JobModel
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
