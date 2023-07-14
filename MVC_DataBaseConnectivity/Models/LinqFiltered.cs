using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Models
{
    public class LinqFiltered
    {
        public int Id {get; set;}
        public string FullName { get; set; }
        public string Email {get; set;}
        public string Phone {get; set;}
        public int? Salary {get; set;}
        public string DepartmentName {get; set;}
        public string Street {get; set;}
        public string Country {get; set;}
        public string Region {get; set;}
    }
}
