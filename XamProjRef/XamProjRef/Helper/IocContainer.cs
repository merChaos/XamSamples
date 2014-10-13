using Autofac;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Common.Network;
using XamProjRef1.Helper;
using XamProjRef1.LocalDB;
using XamProjRef1.Model;
using XamProjRef1.Service;
using XamProjRef1.View;
using XamProjRef1.ViewModel;
using XamProjRef1.Common;

namespace XamProjRef1
{
    public static class IocContainer
    {
        public static IContainer Container { get; set; }

        public static void Build()
        {
             
                // Register all the platform dependencies here
            var builder = new ContainerBuilder()
                .RegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly) // will register the AutoFacPageLocator and all the View Models 
                .RegisterPlatformDependency<INetworkService>() // will resolve the platform specific dependency of INetworkService
                .RegisterPlatformDependency<IUserDialog>();

            // register all the other Dependencies here. 
            builder.RegisterType<ServiceProxy>().As<IServiceProxy>().SingleInstance();
            builder.RegisterType<CommonServiceResult>().As<IServiceResult>().SingleInstance();
            builder.RegisterType<UserDAL>().As<IRepository<User>>().SingleInstance();
            
            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }

    
}
