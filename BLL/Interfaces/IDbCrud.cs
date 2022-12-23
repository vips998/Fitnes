using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud

    {
        List<TimeTableDTO> GetTimeTable();
        List<ServiceTypeDTO> GetServiceType();
        List<UserTypeDTO> GetUserType();
        List<UserDTO> GetUser();
        List<TrainingDTO> GetTraining();
        ServiceTypeDTO GetOneService(int ID);
        UserDTO GetUser(int Id);
        TimeTableDTO GetoneTimeTable(int Id);
        bool Save();
        void CreateUser(UserDTO p);
        void UpdateUser(UserDTO p);

        void UpdateTimeTable(TimeTableDTO p);
        void DeleteUser(int id);
        void DeleteTimeTable(int id);
        void CreateClient(ClientDTO c);

        void CreateTraining(TrainingDTO t);

        void CreateTimeTable(TimeTableDTO tt);
    }
}
