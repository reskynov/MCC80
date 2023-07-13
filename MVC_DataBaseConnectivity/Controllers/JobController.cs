using System;
using MVC_DataBaseConnectivity.Models;
using MVC_DataBaseConnectivity.Views;

namespace MVC_DataBaseConnectivity.Controllers
{
    public class JobController
    {
        private JobModel _jobModel = new JobModel();
        private JobView _jobView = new JobView();

        public JobController(JobModel job, JobView jobView)
        {
            _jobModel = job;
            _jobView = jobView;
        }

        public void GetAll()
        {
            var result = _jobModel.GetAll();
            switch (result.Count)
            {
                case 0:
                    _jobView.DataEmpty();
                    break;
                default:
                    _jobView.GetAll(result);
                    break;
            }
        }

        public void GetById(string id)
        {
            var result = _jobModel.GetById(id);
            if (result != null)
            {
                _jobView.GetById(result);
            }
            else if (result.Id == null)
            {
                _jobView.DataNotFound();
            }
            else
            {
                _jobView.ErrorDatabase();
            }
        }

        public void Insert()
        {
            var job = _jobView.Insert();
            var result = _jobModel.Insert(job);
            switch (result)
            {
                case 0:
                    _jobView.Failed();
                    break;
                case -1:
                    _jobView.ErrorDatabase();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void Update()
        {
            var job = _jobView.Update();
            var result = _jobModel.Update(job);
            switch (result)
            {
                case 0:
                    _jobView.Failed();
                    break;
                case -1:
                    _jobView.ErrorDatabase();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var job = _jobView.Delete();
            var result = _jobModel.Delete(job);
            switch (result)
            {
                case 0:
                    _jobView.Failed();
                    break;
                case -1:
                    _jobView.ErrorDatabase();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }
    }
}
