using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IReportsRepository
    {
        private FitnesModelContext db;
        private class FitnesResult
        {
            public string FIO { get; set; }
            public int Balance { get; set; }

            public int Cost { get; set; }
            public DateTime Date { get; set; }
        }
        public ReportRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        //выполнить ХП
        public List<TrainingClients> ExecuteSP(DateTime time)
        {
            SqlParameter param = new SqlParameter("@Date", time);

            var result = db.Database.SqlQuery<FitnesResult>("dbo.Paym @Date", new object[] { param }).ToList();
            var date = result
                .OrderBy(i => i.Date)
                .Select(i => new TrainingClients
                {
                    FIO = i.FIO,
                    Balance = i.Balance,
                    Cost = i.Cost,
                    Date = i.Date
                })
                .ToList();

            return date;
        }

        public List<PaymentClients> Trainings(int ServiceeeID)
        {
            var request = db.User
               .Join(db.TimeTable, t => t.ID, r => r.UserID, (t, r) => new { t, r })
               .Where(i => i.r.ServiceTypeID == ServiceeeID)
               .Select(i => new PaymentClients { FIO = i.t.FIO, Telephone = i.t.Telephone, Mail = i.t.Mail })
               .ToList();

            return request;
        }
    }
}
