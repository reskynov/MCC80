using MVC_DataBaseConnectivity.Models;
using System;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace MVC_DataBaseConnectivity.Views
{
    public class HistoryView
    {
        public void GetAll(List<History> histories)
        {
            foreach (var history in histories)
            {
                GetById(history);
            }
        }

        public void GetById(History history)
        {
            if (history.EmployeeId == 0 )
            {
                DataNotFound();
            }
            else
            {
                Console.WriteLine("Start Date : " + history.StartDate);
                Console.WriteLine("Employee ID : " + history.EmployeeId);
                if (history.EndDate is null)
                {
                    Console.WriteLine("End Date : NULL");
                }
                else
                {
                    Console.WriteLine("End Date : " + history.EndDate);
                }
                Console.WriteLine("Department ID : " + history.DepartmentId);
                Console.WriteLine("Job ID : " + history.JobId);
                Console.WriteLine("==========================");
            }
        }

        public History Insert()
        {
            Console.Write("Input Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool wrongInput = true;
            DateTime? endDate = null;
            while (wrongInput)
            {
                wrongInput = false;
                Console.Write("Input End Date (mm/dd/yyyy) : ");
                string? endDateString = Console.ReadLine();
                //jika isian kosong maka buat value menjadi null
                if (endDateString == "" || endDateString == " ")
                {
                    endDate = null;
                }
                else
                {
                    if (DateValidation(endDateString))
                    {
                        endDate = DateTime.ParseExact(endDateString, "d", new CultureInfo("en-US"));
                    }
                    else
                    {
                        wrongInput = true;
                    }
                }
            }
            Console.Write("Department ID : ");
            int deparmentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Job ID : ");
            string jobId = Console.ReadLine();

            return new History
            {
                StartDate = DateTime.Now,
                EmployeeId = id,
                EndDate = endDate,
                DepartmentId = deparmentId,
                JobId = jobId
            };
        }

        public History Update()
        {
            Console.Write("Input Employee ID To Update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput Employee's Department ID To Update : ");
            int deparmentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Employee's Job ID to Update : ");
            string jobId = Console.ReadLine();

            bool wrongInput = true;
            DateTime? endDate = null;
            while (wrongInput)
            {
                wrongInput = false;
                Console.Write("Input Updated End Date (mm/dd/yyyy) : ");
                string? endDateString = Console.ReadLine();
                //jika isian kosong maka buat value menjadi null
                if (endDateString == "" || endDateString == " ")
                {
                    endDate = null;
                }
                else
                {
                    if (DateValidation(endDateString))
                    {
                        endDate = DateTime.ParseExact(endDateString, "d", new CultureInfo("en-US"));
                    }
                    else
                    {
                        wrongInput = true;
                    }
                }
            }

            return new History
            {
                StartDate = DateTime.Now,
                EmployeeId = id,
                DepartmentId = deparmentId,
                EndDate= endDate,
                JobId = jobId
            };
        }

        public History Delete()
        {
            Console.Write("Input Employee ID To Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput Employee's Department ID To Delete : ");
            int deparmentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Employee's Job ID to Delete : ");
            string jobId = Console.ReadLine();

            return new History
            {
                StartDate = DateTime.Now,
                EmployeeId = id,
                DepartmentId = deparmentId,
                EndDate = null,
                JobId = jobId
            };
        }

        public static bool DateValidation(string inputDate)
        {
            try
            {
                var userDate = DateTime.ParseExact(inputDate, "d", new CultureInfo("en-US"));

                if (userDate > DateTime.Now)
                {
                    return true;
                }
                else
                {
                    Console.Write("Invalid Date.\n");
                    return false;
                }
            }
            catch
            {
                Console.Write("Error. Invalid Date.  Please enter your date of birth (mm/dd/yyyy)\n");
                return false;
            }
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
