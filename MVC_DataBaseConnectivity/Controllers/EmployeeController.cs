using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class EmployeeController
    {
        private EmployeeModel _employeeModel = new EmployeeModel();
        private EmployeeView _employeeView = new EmployeeView();

        public EmployeeController(EmployeeModel employee, EmployeeView employeeView)
        {
            _employeeModel = employee;
            _employeeView = employeeView;
        }

        public void GetAll()
        {
            var result = _employeeModel.GetAll();
            switch (result.Count)
            {
                case 0:
                    _employeeView.DataEmpty();
                    break;
                default:
                    _employeeView.GetAll(result);
                    break;
            }
        }

        public void GetById(int id)
        {
            var result = _employeeModel.GetById(id);
            if (result != null)
            {
                _employeeView.GetById(result);
            }
            else if (result.Id == null)
            {
                _employeeView.DataNotFound();
            }
            else
            {
                _employeeView.ErrorDatabase();
            }
        }

        public void Insert()
        {
            var employee = _employeeView.Insert();
            var result = _employeeModel.Insert(employee);
            switch (result)
            {
                case 0:
                    _employeeView.Failed();
                    break;
                case -1:
                    _employeeView.ErrorDatabase();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void Update()
        {
            var employee = _employeeView.Update();
            var result = _employeeModel.Update(employee);
            switch (result)
            {
                case 0:
                    _employeeView.Failed();
                    break;
                case -1:
                    _employeeView.ErrorDatabase();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var employee = _employeeView.Delete();
            var result = _employeeModel.Delete(employee);
            switch (result)
            {
                case 0:
                    _employeeView.Failed();
                    break;
                case -1:
                    _employeeView.ErrorDatabase();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }
    }
}
