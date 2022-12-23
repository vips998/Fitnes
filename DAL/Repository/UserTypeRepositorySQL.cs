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
    public class UserTypeRepositorySQL : IRepository<UserType>
    {
        private FitnesModelContext db;

        public UserTypeRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<UserType> GetList()
        {
            return db.UserType.ToList();
        }

        public UserType GetItem(int id)
        {
            return db.UserType.Find(id);
        }

        public void Create(UserType usertype)
        {
            db.UserType.Add(usertype);
        }

        public void Update(UserType usertype)
        {
            db.Entry(usertype).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserType usertype = db.UserType.Find(id);
            if (usertype != null)
                db.UserType.Remove(usertype);
        }


    }
}
