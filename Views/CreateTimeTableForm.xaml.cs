﻿using Fitnes.Util;
using Fitnes.ViewModels;
using BLL.Interfaces;
using BLL.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для CreateTimeTableForm.xaml
    /// </summary>
    public partial class CreateTimeTableForm : Window
    {
        public CreateTimeTableForm(BLL.DTO.UserDTO user)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("Context"));
            IDbCrud crudServ = kernel.Get<IDbCrud>();

            InitializeComponent();
            DataContext = new CreateTimeTableController(crudServ, this, user);
        }
    }
}
