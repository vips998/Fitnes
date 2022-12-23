using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL.DTO
{
    public class TimeTableDTO : INotifyPropertyChanged
    {
        private int serviceTypeID;
        private int cost;
        private int userID;
        private int maxCount;
        private string serviceType;
        private DateTime date;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int ID { get; set; }

        public int ServiceTypeID
        {
            get { return serviceTypeID; }
            set
            {
                serviceTypeID = value;
                OnPropertyChanged("ServiceTypeID");
            }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

        public int MaxCount
        {
            get { return maxCount; }
            set
            {
                maxCount = value;
                OnPropertyChanged("MaxCount");
            }
        }

        public string ServiceType
        {
            get { return serviceType; }
            set
            {
                serviceType = value;
                OnPropertyChanged("ServiceType");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }


        public TimeTableDTO() { }
        public TimeTableDTO(TimeTable t)
        {
            ID = t.ID;
            ServiceTypeID = t.ServiceTypeID;
            Cost = t.Cost;
            UserID = t.UserID;
            MaxCount = t.MaxCount;
            Date = t.Date;
        }

    }
}
