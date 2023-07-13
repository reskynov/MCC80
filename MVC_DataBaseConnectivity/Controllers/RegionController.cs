using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class RegionController
    {
        private RegionModel _regionModel = new RegionModel();
        private RegionView _regionView = new RegionView();

        public RegionController(RegionModel region, RegionView regionView) 
        {
            _regionModel = region;
            _regionView = regionView;
        }

        public void GetAll()
        {
            var result = _regionModel.GetAll();
            switch(result.Count)
            {
                case 0:
                    _regionView.DataEmpty();
                    break;
                default:
                    _regionView.GetAll(result);
                    break;
            }
        }

        public void GetById(int id)
        {
            var result = _regionModel.GetById(id);
            if (result != null)
            {
                _regionView.GetById(result);
            }
            else if (result.Id == null)
            {
                _regionView.DataNotFound();
            }
            else
            {
                _regionView.ErrorDatabase();
            }
        }

        public void Insert()
        {
            var region = _regionView.Insert();
            var result = _regionModel.Insert(region);
            switch (result)
            {
                case 0:
                    _regionView.Failed();
                    break;
                case -1:
                    _regionView.ErrorDatabase();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void Update()
        {
            var region = _regionView.Update();
            var result = _regionModel.Update(region);
            switch (result)
            {
                case 0:
                    _regionView.Failed();
                    break;
                case -1:
                    _regionView.ErrorDatabase();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var region = _regionView.Delete();
            var result = _regionModel.Delete(region);
            switch (result)
            {
                case 0:
                    _regionView.Failed();
                    break;
                case -1:
                    _regionView.ErrorDatabase();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }
    }
}
