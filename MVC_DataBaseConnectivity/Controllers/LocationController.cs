using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class LocationController
    {
        private LocationModel _locationModel = new LocationModel();
        private LocationView _locationView = new LocationView();

        public LocationController(LocationModel location, LocationView locationView)
        {
            _locationModel = location;
            _locationView = locationView;
        }

        public void GetAll()
        {
            var result = _locationModel.GetAll();
            switch (result.Count)
            {
                case 0:
                    _locationView.DataEmpty();
                    break;
                default:
                    _locationView.GetAll(result);
                    break;
            }
        }

        public void GetById(int id)
        {
            var result = _locationModel.GetById(id);
            if (result != null)
            {
                _locationView.GetById(result);
            }
            else if (result.Id == null)
            {
                _locationView.DataNotFound();
            }
            else
            {
                _locationView.ErrorDatabase();
            }
        }

        public void Insert()
        {
            var department = _locationView.Insert();
            var result = _locationModel.Insert(department);
            switch (result)
            {
                case 0:
                    _locationView.Failed();
                    break;
                case -1:
                    _locationView.ErrorDatabase();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void Update()
        {
            var department = _locationView.Update();
            var result = _locationModel.Update(department);
            switch (result)
            {
                case 0:
                    _locationView.Failed();
                    break;
                case -1:
                    _locationView.ErrorDatabase();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var department = _locationView.Delete();
            var result = _locationModel.Delete(department);
            switch (result)
            {
                case 0:
                    _locationView.Failed();
                    break;
                case -1:
                    _locationView.ErrorDatabase();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }
    }
}
