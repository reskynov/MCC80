using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;
using System;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class HistoryController
    {
        private HistoryModel _historyModel = new HistoryModel();
        private HistoryView _historyView = new HistoryView();

        public HistoryController(HistoryModel history, HistoryView historyView)
        {
            _historyModel = history;
            _historyView = historyView;
        }

        public void GetAll()
        {
            var result = _historyModel.GetAll();
            switch (result.Count)
            {
                case 0:
                    _historyView.DataEmpty();
                    break;
                default:
                    _historyView.GetAll(result);
                    break;
            }
        }

        public void GetById(int id)
        {
            var result = _historyModel.GetById(id);
            switch (result.Count)
            {
                case 0:
                    _historyView.DataEmpty();
                    break;
                default:
                    _historyView.GetAll(result);
                    break;
            }
        }

        public void Insert()
        {
            var country = _historyView.Insert();
            var result = _historyModel.Insert(country);
            switch (result)
            {
                case 0:
                    _historyView.Failed();
                    break;
                case -1:
                    _historyView.ErrorDatabase();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void Update()
        {
            var region = _historyView.Update();
            var result = _historyModel.Update(region);
            switch (result)
            {
                case 0:
                    _historyView.Failed();
                    break;
                case -1:
                    _historyView.ErrorDatabase();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var region = _historyView.Delete();
            var result = _historyModel.Delete(region);
            switch (result)
            {
                case 0:
                    _historyView.Failed();
                    break;
                case -1:
                    _historyView.ErrorDatabase();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }
    }
}
