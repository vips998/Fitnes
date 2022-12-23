using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private FitnesModelContext db;
        private TimeTableRepositorySQL timeTableRepository;
        private TrainingRepositorySQL trainingRepository;
        private UserRepositorySQL userRepository;
        private ReportRepositorySQL reportRepository;
        private ClientRepositorySQL clientRepository;
        private ServiceTypeRepositorySQL servicetypeRepository;
        private UserTypeRepositorySQL usertypeRepository;

        public DbReposSQL()
        {
            db = new FitnesModelContext();
        }

        public IRepository<TimeTable> TimeTables
        {
            get
            {
                if (timeTableRepository == null)
                    timeTableRepository = new TimeTableRepositorySQL(db);
                return timeTableRepository;
            }
        }

        public IRepository<Training> Trainings
        {
            get
            {
                if (trainingRepository == null)
                    trainingRepository = new TrainingRepositorySQL(db);
                return trainingRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepositorySQL(db);
                return clientRepository;
            }
        }

        public IRepository<UserType> UserTypes
        {
            get
            {
                if (usertypeRepository == null)
                    usertypeRepository = new UserTypeRepositorySQL(db);
                return usertypeRepository;
            }
        }
        public IRepository<ServiceType> ServiceTypes
        {
            get
            {
                if (servicetypeRepository == null)
                    servicetypeRepository = new ServiceTypeRepositorySQL(db);
                return servicetypeRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepositorySQL(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
