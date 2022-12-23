using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using BLL.Interfaces;
using BLL.DTO;
using Fitnes.ViewModels;
using Fitnes;

namespace Fitnes.ViewModels
{
    public class EnterController : INotifyPropertyChanged
    {
        IDbCrud db;
        Registration registration;
        private UserDTO user;
        public event PropertyChangedEventHandler PropertyChanged;

        public UserDTO User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public List<UserDTO> Users { get; set; }

        public EnterController(IDbCrud dbCrud, Registration registration)
        {
            db = dbCrud;
            this.registration = registration;
            user = new UserDTO();
        }

        public void UsersLoad()
        {
            Users = db.GetUser().ToList();
        }


        #region COMMANDs

        private RelayCommand closeRegistration;
        public RelayCommand CloseRegistration
        {
            get
            {
                return closeRegistration ?? new RelayCommand(obj =>
                {
                    CloseRegistrationWindow();
                });
            }
        }


        private RelayCommand openNewMainWindow;
        public RelayCommand OpenNewMainWindow
        {
            get
            {
                return openNewMainWindow ?? new RelayCommand(obj =>
                {
                    OpenMainWindow();
                });
            }
        }


        private RelayCommand registrationNew;
        public RelayCommand RegistrationNew
        {
            get
            {
                return registrationNew ?? new RelayCommand(obj =>

                    RegistrationNewUser(obj)
                );
            }
        }

        #endregion

        public void OpenMainWindow()
        {
            if (user.Login == null)
            {
                MessageBox.Show("Не все поля входа заполнены!");
            }
            else if (user.Password.Count() <= 0  || user.Password.Count()>8)
            {
                MessageBox.Show("Пароль должен состоять из 8 символов!");
            }
            else
            {
                bool search = false;

                UsersLoad();

                for (int i = 0; i < Users.Count(); i++)
                {
                    if (user.Login == Users[i].Login && user.Password == Users[i].Password)
                    {
                        search = true;
                        MainWindow mainWindow = new MainWindow(Users[i]);
                        mainWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        mainWindow.Show();
                        CloseRegistrationWindow();
                    }
                }

                if (search == false)
                    MessageBox.Show("Неправильно введён логин/пароль или пользователя с таким данными не существует!");
            }
        }


        public void CloseRegistrationWindow()
        {
            registration.Close();
        }


        public void RegistrationNewUser(object obj)
        {
            if (user.Password == null || user.Login == null || user.FIO == null)
            {
                MessageBox.Show("Не все поля регистрации заполнены!");
            }
            else if (user.Password.Count() <= 0 || user.Password.Count() > 8)
            {
                MessageBox.Show("Пароль должен состоять из 8 символов!");
            }
            else
            {
               /* user.DateUpdateBalance = DateTime.Now;*/


                UsersLoad();

                bool search = false;

                for (int i = 0; i < Users.Count(); i++)
                    if (user.Login == Users[i].Login)
                    {
                        search = true;
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        break;
                    }

                if (search == false)
                {
                    user.UserTypeID = 1;
                    db.CreateUser(user);
                    MessageBox.Show("Пользователь успешно зарегистрирован!");
                }
            }
        }
    }
}
