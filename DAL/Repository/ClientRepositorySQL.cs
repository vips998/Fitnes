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
    public class ClientRepositorySQL : IRepository<Client>
    {
        private FitnesModelContext db;

        public ClientRepositorySQL(FitnesModelContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Client> GetList()
        {
            return db.Client.ToList();
        }

        public Client GetItem(int id)
        {
            return db.Client.Find(id);
        }

        public void Create(Client client)
        {
            db.Client.Add(client);
        }

        public void Update(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client client = db.Client.Find(id);
            if (client != null)
                db.Client.Remove(client);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}

