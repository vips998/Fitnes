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
    public class UserRepositorySQL : IRepository<User>
    {
        private FitnesModelContext db;

        public UserRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<User> GetList()
        {
            return db.User.ToList();
        }

        public User GetItem(int id)
        {
            return db.User.Find(id);
        }

        public void Create(User user)
        {
            db.User.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.User.Find(id);
            if (user != null)
                db.User.Remove(user);
        }


    }
}

