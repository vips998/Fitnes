using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Fitnes.Views;
using BLL.Interfaces;
using BLL.DTO;

namespace Fitnes.ViewModels
{
    internal class UpdateTimeTableController : INotifyPropertyChanged
    {
        private IDbCrud crudServ;
        private UpdateTimeTableForm updateTimeTableForm;
        private UserDTO user;
        private ServiceTypeDTO servicetype;
        private TimeTableDTO timeTable;


        public ServiceTypeDTO ServiceType
        {
            get { return servicetype; }
            set
            {
                servicetype = value;
                OnPropertyChanged("ServiceType");
            }
        }

        public TimeTableDTO TimeTable
        {
            get { return timeTable; }
            set
            {
                timeTable = value;
                OnPropertyChanged("TimeTable");
            }
        }

        public List<ServiceTypeDTO> ServiceTypes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public UpdateTimeTableController(IDbCrud crudServ, UpdateTimeTableForm updateTimeTableForm, TimeTableDTO timetable)
        {
            this.crudServ = crudServ;
            this.updateTimeTableForm = updateTimeTableForm;
            this.timeTable = timetable;

            servicetype = new ServiceTypeDTO();
            ServiceTypeLoad();
        }

        public void ServiceTypeLoad()
        {
            ServiceTypes = crudServ.GetServiceType();
        }


        private RelayCommand closeWindow;
        public RelayCommand CloseWindow
        {
            get
            {
                return closeWindow ?? new RelayCommand(obj =>
                {
                    CloseThisWindow();
                });
            }
        }

        private RelayCommand updateTimeTable;
        public RelayCommand UpdateTimeTable
        {
            get
            {
                return updateTimeTable ?? new RelayCommand(obj =>
                {
                    UpdTimeTable();
                });
            }
        }

        public void CloseThisWindow()
        {
            updateTimeTableForm.Close();
        }

        public void UpdTimeTable()
        {
            if (ServiceType.ID == 0)
                timeTable.ServiceType = null;
            else
                timeTable.ServiceTypeID = ServiceType.ID;

            timeTable.Cost = timeTable.MaxCount * ServiceType.Cost;
            timeTable.ServiceType = ServiceType.Name;
            crudServ.UpdateTimeTable(timeTable);

            CloseThisWindow();
        }
    }
}