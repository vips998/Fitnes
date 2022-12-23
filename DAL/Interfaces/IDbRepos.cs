using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<User> Users { get; }
        IRepository<TimeTable> TimeTables { get; }
        IRepository<Training> Trainings { get; }
        IRepository<UserType> UserTypes { get; }
        IRepository<ServiceType> ServiceTypes { get; }
        IRepository<Client> Clients { get; }
        IReportsRepository Reports { get; }
        int Save();

    }
}
