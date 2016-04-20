using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Autofac;
using Microsoft.Data.Entity;
using SaveMyURL.Model;
using SaveMyURL.Pages;
using SaveMyURL.ViewModel;

namespace SaveMyURL.Repositories
{
    public class AutofacConfig
    {

        public static void InitContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ApplicationContext>();
            containerBuilder.Register(c => new ApplicationContext())
             .As<ApplicationContext>().InstancePerDependency();
            containerBuilder.RegisterType<ApplicationContext>().As<DbContext>().
                InstancePerDependency();
            containerBuilder.RegisterType<GroupRepository>().As<IGroupRepository>();
            containerBuilder.RegisterType<Class1>().As<IClass1>();
            var container = containerBuilder.Build();
        }

    }
}
