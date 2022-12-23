using BLL.Interfaces;
using BLL.Util;
using Fitnes.Util;
using Fitnes.ViewModels;
using Fitnes.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("Context"));
            IDbCrud crudServ = kernel.Get<IDbCrud>();

            InitializeComponent();

            DataContext = new EnterController(crudServ, this);
        }

    }
}
