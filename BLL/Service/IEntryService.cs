using BLL.DTO;
using BLL.Interfaces;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL.Service
{
    public class EntryService : IEntryService
    {
        private IDbRepos db;

        public EntryService(IDbRepos repos)
        {
            db = repos;
        }

        public bool MakeTimeTable(TimeTableDTO e)
        {
            TimeTable entry = new TimeTable()
            {
                UserID = e.UserID,
                ServiceTypeID = e.ServiceTypeID,
                Cost = e.MaxCount * db.ServiceTypes.GetItem(e.ServiceTypeID).Cost,
                MaxCount = e.MaxCount,
                Date = e.Date,
            };

            db.TimeTables.Create(entry);

            if (db.Save() > 0)
                return true;
            return false;
        }
    }
}
