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
    public class ServiceTypeRepositorySQL : IRepository<ServiceType>
    {
        private FitnesModelContext db;

        public ServiceTypeRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ServiceType> GetList()
        {
            return db.ServiceType.ToList();
        }

        public ServiceType GetItem(int id)
        {
            return db.ServiceType.Find(id);
        }

        public void Create(ServiceType servicetype)
        {
            db.ServiceType.Add(servicetype);
        }

        public void Update(ServiceType servicetype)
        {
            db.Entry(servicetype).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ServiceType servicetype = db.ServiceType.Find(id);
            if (servicetype != null)
                db.ServiceType.Remove(servicetype);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}

