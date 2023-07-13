using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class CountryController
    {
        private CountryModel _countryModel = new CountryModel();
        private CountryView _countryView = new CountryView();

        public CountryController(CountryModel country, CountryView countryView)
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
            var region = _countryView.Update();
            var result = _countryModel.Update(region);
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
            var region = _countryView.Delete();
            var result = _countryModel.Delete(region);
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
    }
}
