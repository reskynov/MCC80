using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class DepartmentController
    {
        private DepartmentModel _departmentModel = new DepartmentModel();
        private DepartmentView _departmentView = new DepartmentView();

        public DepartmentController(DepartmentModel department, DepartmentView departmentView)
        {
            _departmentModel = department;
            _departmentView = departmentView;
        }

        public void GetAll()
        {
            var result = _departmentModel.GetAll();
            switch (result.Count)
            {
                case 0:
                    _departmentView.DataEmpty();
                    break;
                default:
                    _departmentView.GetAll(result);
                    break;
            }
        }

        public void GetById(int id)
        {
            var result = _departmentModel.GetById(id);
            if (result != null)
            {
                _departmentView.GetById(result);
            }
            else if (result.Id == null)
            {
                _departmentView.DataNotFound();
            }
            else
            {
                _departmentView.ErrorDatabase();
            }
        }

        public void Insert()
        {
            var department = _departmentView.Insert();
            var result = _departmentModel.Insert(department);
            switch (result)
            {
                case 0:
                    _departmentView.Failed();
                    break;
                case -1:
                    _departmentView.ErrorDatabase();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void Update()
        {
            var department = _departmentView.Update();
            var result = _departmentModel.Update(department);
            switch (result)
            {
                case 0:
                    _departmentView.Failed();
                    break;
                case -1:
                    _departmentView.ErrorDatabase();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var department = _departmentView.Delete();
            var result = _departmentModel.Delete(department);
            switch (result)
            {
                case 0:
                    _departmentView.Failed();
                    break;
                case -1:
                    _departmentView.ErrorDatabase();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }
    }    
}
