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

namespace BLL
{
    public class DBDataOperation : IDbCrud
    {
        IDbRepos dbcontext;

        public DBDataOperation(IDbRepos repos)
        {
            dbcontext = repos;
        }
        public List<TimeTableDTO> GetTimeTable()
        {
            return dbcontext.TimeTables.GetList().Select(i => new TimeTableDTO(i)).ToList();
        }

        /* public List<TimeTableDTO> GetPaymentClient(int type) //// ???
         {
             return dbcontext.Payment.ToList()
                 .Where(i => i.Cost <= i.Client.Balance)
                 .Select(i => new PaymentDTO(i)).ToList();
         }*/

        public List<ServiceTypeDTO> GetServiceType()
        {
            return dbcontext.ServiceTypes.GetList().Select(i => new ServiceTypeDTO(i)).ToList();
        }

        public List<UserTypeDTO> GetUserType()
        {
            return dbcontext.UserTypes.GetList().Select(i => new UserTypeDTO(i)).ToList();
        }

        public List<UserDTO> GetUser()
        {
            return dbcontext.Users.GetList().Select(i => new UserDTO(i)).ToList();
        }

        public UserDTO GetUser(int Id)
        {
            return new UserDTO(dbcontext.Users.GetItem(Id));
        }

        public ServiceTypeDTO GetServiceType(int Id)
        {
            return new ServiceTypeDTO(dbcontext.ServiceTypes.GetItem(Id));
        }

        public TimeTableDTO GetoneTimeTable(int Id)
        {
            return new TimeTableDTO(dbcontext.TimeTables.GetItem(Id));
        }

        public List<TrainingDTO> GetTraining()
        {
            return dbcontext.Trainings.GetList().Select(i => new TrainingDTO(i)).ToList();
        }

        public ServiceTypeDTO GetOneService(int ID)
        {
            return new ServiceTypeDTO(dbcontext.ServiceTypes.GetItem(ID));
        }
        public bool Save()
        {
            if (dbcontext.Save() > 0) return true;
            return false;
        }

        public void DeleteUser(int id)
        {
            if (dbcontext.Users.GetItem(id) != null)
            {
                dbcontext.Users.Delete(id);
                Save();
            }
        }
        public void DeleteTimeTable(int id)
        {
            if (dbcontext.TimeTables.GetItem(id) != null)
            {
                dbcontext.TimeTables.Delete(id);
                Save();
            }
        }

        public void CreateUser(UserDTO user)
        {
            dbcontext.Users.Create(new User()
            {
                FIO = user.FIO,
                Birthday = user.Birthday,
                Passport = user.Passport,
                UserTypeID = user.UserTypeID,
                Telephone = user.Telephone,
                Mail = user.Mail,
                Login = user.Login,
                Password = user.Password,
            });
            Save();
        }

        public void CreateClient(ClientDTO client)
        {
            dbcontext.Clients.Create(new Client()
            {
                ID = client.ID,
                UserID = client.UserID,
                Balance = client.Balance
            });
            Save();
        }

        public void CreateTraining(TrainingDTO training)
        {
            dbcontext.Trainings.Create(new Training()
            {
                ID = training.ID,
                NumberTrain = training.NumberTrain,
                Date = training.Date
            });
            Save();
        }

        public void CreateTimeTable(TimeTableDTO timeTable)
        {
            dbcontext.TimeTables.Create(new TimeTable()
            {
                //ID = timeTable.ID,
                ServiceTypeID = timeTable.ServiceTypeID,
                Cost = timeTable.Cost,
                UserID = timeTable.UserID,
                MaxCount = timeTable.MaxCount,
                Date = timeTable.Date,
            });
            Save();
        }

        public void UpdateUser(UserDTO user)
        {
            User us = dbcontext.Users.GetItem(user.ID);
            us.ID = user.ID;
            us.FIO = user.FIO;
            us.Birthday = user.Birthday;
            us.Passport = user.Passport;
            us.UserTypeID = user.UserTypeID;
            us.Telephone = user.Telephone;
            us.Mail = user.Mail;
            us.Login = user.Login;
            us.Password = user.Passport;
            Save();
        }

        public void UpdateTimeTable(TimeTableDTO tb)
        {
            TimeTable us = dbcontext.TimeTables.GetItem(tb.ID);
            /*us.ID = tb.ID;*/
            us.ServiceTypeID = tb.ServiceTypeID;
            us.UserID = tb.UserID;
            us.Cost = tb.Cost;
            us.Date = tb.Date;
            us.MaxCount = tb.MaxCount;
            Save();
        }
    }
}
