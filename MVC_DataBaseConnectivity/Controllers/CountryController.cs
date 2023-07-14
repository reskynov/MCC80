using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class CountryController
    {
        private Country _countryModel = new Country();
        private CountryView _countryView = new CountryView();

        public CountryController(Country country, CountryView countryView)
        {
            _countryModel = country;
            _countryView = countryView;
        }

        public void GetAll()
        {
            var result = _countryModel.GetAll();
            switch (result.Count)
            {
                case 0:
                    _countryView.DataEmpty();
                    break;
                default:
                    _countryView.GetAll(result);
                    break;
            }
        }

        public void GetById(string id)
        {
            var result = _countryModel.GetById(id);
            if (result != null)
            {
                _countryView.GetById(result);
            }
            else if (result.Id == null)
            {
                _countryView.DataNotFound();
            }
            else
            {
                _countryView.ErrorDatabase();
            }
        }

        public void Insert()
        {
            var country = _countryView.Insert();
            var result = _countryModel.Insert(country);
            switch (result)
            {
                case 0:
                    _countryView.Failed();
                    break;
                case -1:
                    _countryView.ErrorDatabase();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void Update()
        {
            var country = _countryView.Update();
            var result = _countryModel.Update(country);
            switch (result)
            {
                case 0:
                    _countryView.Failed();
                    break;
                case -1:
                    _countryView.ErrorDatabase();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var country = _countryView.Delete();
            var result = _countryModel.Delete(country);
            switch (result)
            {
                case 0 :
                    _countryView.Failed();
                    break;
                case -1 :
                    _countryView.ErrorDatabase();
                    break;
                default :
                    _countryView.Success();
                    break;
            }
        }
    }
}
