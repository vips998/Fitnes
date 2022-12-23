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
    internal class CreateTimeTableController : INotifyPropertyChanged
    {
        private IDbCrud crudServ;
        private CreateTimeTableForm createTimeTableForm;
        private ServiceTypeDTO servicetype;
        private TimeTableDTO timeTable;
        private UserDTO user;

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
        public CreateTimeTableController(IDbCrud crudServ, CreateTimeTableForm createTimeTableForm, UserDTO user)
        {
            this.crudServ = crudServ;
            this.createTimeTableForm = createTimeTableForm;
            this.user = user;

            timeTable = new TimeTableDTO();
            servicetype = new ServiceTypeDTO();
            ServiceTypeLoad();
        }

        public void ServiceTypeLoad()
        {
            ServiceTypes = crudServ.GetServiceType();
        }


        private RelayCommand create;
        public RelayCommand Create
        {
            get
            {
                return create ?? new RelayCommand(obj =>

                    CreateTimeTable(obj)
                );
            }
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

        private RelayCommand createNewCategory;
        public RelayCommand CreateNewCategory
        {
            get
            {
                return createNewCategory ?? new RelayCommand(obj =>
                {
                    CreateCategory();
                });
            }
        }


        public void CloseThisWindow()
        {
            createTimeTableForm.Close();
        }

        public void CreateTimeTable(object obj)
        {
            if (ServiceType.ID == 0)
                timeTable.ServiceType = null;
            else
                timeTable.ServiceTypeID = ServiceType.ID;

            timeTable.Cost = timeTable.MaxCount * ServiceType.Cost;
            timeTable.UserID = user.ID;
           // timeTable.Date = DateTime.Now;
            crudServ.CreateTimeTable(timeTable);

            CloseThisWindow();
        }

        public void CreateCategory()
        {
            /*createForm.Hide();

            IncomeCategoryCreate incomeCategory = new IncomeCategoryCreate();
            incomeCategory.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            incomeCategory.ShowDialog();*/

            CloseThisWindow();
        }


    }
}