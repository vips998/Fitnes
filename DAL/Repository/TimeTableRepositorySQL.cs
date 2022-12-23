using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TimeTableRepositorySQL : IRepository<TimeTable>
    {
        private FitnesModelContext db;

        public TimeTableRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<TimeTable> GetList()
        {
            return db.TimeTable.ToList();
        }

        public TimeTable GetItem(int id)
        {
            return db.TimeTable.Find(id);
        }

        public void Create(TimeTable timetable)
        {
            db.TimeTable.Add(timetable);
        }

        public void Update(TimeTable timetable)
        {
            db.Entry(timetable).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TimeTable timetable = db.TimeTable.Find(id);
            if (timetable != null)
                db.TimeTable.Remove(timetable);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
