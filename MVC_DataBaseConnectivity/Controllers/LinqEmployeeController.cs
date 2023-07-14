using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class LinqEmployeeController
    {
        private Employee _employee;
        private Department _department;
        private Location _location;
        private Country _country;
        private Region _region;

        public LinqEmployeeController(Employee employee, Department department, Location location, Country country, Region region)
        {
            _employee = employee;
            _department = department;
            _location = location;
            _country = country;
            _region = region;
        }

        public void JoinedDataEmployee()
        {
            var getEmployee = _employee.GetAll();
            var getDepartment = _department.GetAll();
            var getLocation = _location.GetAll();
            var getCountry = _country.GetAll();
            var getRegion = _region.GetAll();

            var joinedData = (from r in getRegion
                              join c in getCountry on r.Id equals c.RegionId
                              join l in getLocation on c.Id equals l.CountryId
                              join d in getDepartment on l.Id equals d.LocationId
                              join e in getEmployee on d.Id equals e.DepartmentId
                              select new LinqEmployee
                              {
                                  Id = e.Id,
                                  FullName = e.Fname + " " + e.Lname,
                                  Email = e.Email,
                                  Phone = e.Phone,
                                  Salary = e.Salary,
                                  DepartmentName = d.Name,
                                  Street = l.Street,
                                  Country = c.Name,
                                  Region = r.Name
                              }).ToList();
            LinqEmployeeView linqView = new LinqEmployeeView();
            linqView.JoinedDataEmployee(joinedData);
        }
    }
}
