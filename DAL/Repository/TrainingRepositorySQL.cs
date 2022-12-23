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
    public class TrainingRepositorySQL : IRepository<Training>
    {
        private FitnesModelContext db;

        public TrainingRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Training> GetList()
        {
            return db.Training.ToList();
        }

        public Training GetItem(int id)
        {
            return db.Training.Find(id);
        }

        public void Create(Training training)
        {
            db.Training.Add(training);
        }

        public void Update(Training training)
        {
            db.Entry(training).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Training training = db.Training.Find(id);
            if (training != null)
                db.Training.Remove(training);
        }


    }
}
