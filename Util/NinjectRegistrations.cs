using BLL;
using BLL.Interfaces;
using BLL.Service;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IEntryService>().To<EntryService>();
            Bind<IReportService>().To<ReportsService>();
            Bind<IDbCrud>().To<DBDataOperation>();
        }
    }
}
