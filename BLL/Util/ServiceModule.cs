﻿using DAL;
using DAL.Interfaces;
using DAL.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Util
{
    public class ServiceModule : NinjectModule
    {
        string Connectionstring;
        public ServiceModule(string FitnesModelContext)
        {
            Connectionstring = FitnesModelContext;
        }
        public override void Load()
        {
            Bind<IDbRepos>().To<DbReposSQL>().InSingletonScope().WithConstructorArgument(Connectionstring);
        }
    }
}
