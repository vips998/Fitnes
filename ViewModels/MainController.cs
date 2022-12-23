using BLL.DTO;
using BLL.Interfaces;
using Fitnes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Fitnes.Views
{
    internal class MainController : INotifyPropertyChanged
    {
        private IDbCrud crusServ;
        private MainWindow mainWindow;
        private UserDTO user;
        private TimeTableDTO selectedTimeTable;
        public ObservableCollection<TimeTableDTO> tables { get; set; }

        public List<ServiceTypeDTO> types { get; set; }

        public MainController(IDbCrud crusServ, MainWindow mainWindow, UserDTO user)
        {
            this.crusServ = crusServ;
            this.mainWindow = mainWindow;
            this.user = user;
            types = crusServ.GetServiceType();


            tables = new ObservableCollection<TimeTableDTO>(crusServ.GetTimeTable().Where(i=> i.UserID == user.ID).ToList());



            for (int i = 0; i < tables.Count; i++)
            {
                tables[i].ServiceType = crusServ.GetOneService(tables[i].ServiceTypeID).Name;
            }

        }

        public UserDTO User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public TimeTableDTO SelectedTimeTable
        {
            get { return selectedTimeTable; }
            set
            {
                selectedTimeTable = value;
                OnPropertyChanged("SelectedTimeTable");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private TimeTableDTO timetable;
        public TimeTableDTO Timetable
        {
            get {return timetable; }
            set
            {
                timetable = value;
                OnPropertyChanged("Timetable");
            }
        }


        private RelayCommand addTimetable;

        public RelayCommand AddTimeTable
        {
            get
            {
                return addTimetable ?? new RelayCommand(obj =>
                {
                    AddNewtable();
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
                },
                (obj) => (tables.Count > 0 && SelectedTimeTable != null));
            }
        }

        private RelayCommand deletetimetable;
        public RelayCommand DeleteTimeTable
        {
            get
            {
                return deletetimetable ?? new RelayCommand(obj =>
                {
                   DelTimeTable();
                },

                (obj) => (tables.Count > 0 && SelectedTimeTable != null));
            }
        }
        private void AddNewtable()
        {

            CreateTimeTableForm CreateTable = new CreateTimeTableForm(user);
            CreateTable.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            CreateTable.ShowDialog();

            List<TimeTableDTO> timetables = crusServ.GetTimeTable();
            if (tables.Count < timetables.Count)
            {
                tables.Insert(tables.Count, timetables.Last());
                tables[tables.Count - 1].ServiceType = crusServ.GetOneService(timetables.Last().ServiceTypeID).Name;
            }

        }

        public void DelTimeTable()
        {
            crusServ.DeleteTimeTable(selectedTimeTable.ID);
            tables.Remove(selectedTimeTable);
        }


        public void UpdTimeTable()
        {
            UpdateTimeTableForm updateForm = new UpdateTimeTableForm(selectedTimeTable);
            updateForm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            updateForm.ShowDialog();

        }
    }
}