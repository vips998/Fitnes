using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO : INotifyPropertyChanged
    {
        private int userTypeID;
        private string fIO;
        private DateTime birthday;
        private string passport;

        private string telephone;
        private string mail;

        private string login;

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                userTypeID = value;
                OnPropertyChanged("UserTypeID");
            }
        }

        public string FIO
        {
            get { return fIO; }
            set
            {
                fIO = value;
                OnPropertyChanged("FIO");
            }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public string Passport
        {
            get { return passport; }
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public int ID { get; set; }
        public UserDTO() { }
        public UserDTO(User t)
        {
            ID = t.ID;
            UserTypeID = t.UserTypeID;
            FIO = t.FIO;
            Login = t.Login;
            Password = t.Password;
            Birthday = t.Birthday;
            Passport = t.Passport;
            Telephone = t.Telephone;
            Mail = t.Mail;
        }
    }
}
