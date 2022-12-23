using BLL.DTO.ReportModels;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportsService : IReportService
    {

        private IDbRepos db;
        public ReportsService(IDbRepos repos)
        {
            db = repos;
        }


        public List<TrainingClients> ExecuteSP(DateTime time)
        {

            return db.Reports.ExecuteSP(time).Select(i => new TrainingClients { FIO = i.FIO, Balance = i.Balance, Cost = i.Cost, Date = i.Date }).ToList();
        }

        public List<PaymentClients> Trainings(int id)
        {
            var request = db.Reports.Trainings(id)
             .Select(i => new PaymentClients() { FIO = i.FIO, Telephone = i.Telephone, Mail = i.Mail })
             .ToList();
            return request;
        }

    }
}
