using Autofac;
using System;
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

namespace XamProjRef1
{
    public static class IocContainer
    {
        public static IContainer Container { get; set; }

        public static void Build()
        {
            var builder = new ContainerBuilder();

            //Register Service Classes
            //builder.Container = new ContainerBuilder()
            //    .RegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly)
            //    .RegisterXamDependency<INetworkService>()
            //    .Build();


            // register all the Dependencies here. 
            builder.Register(x => new ServiceProxy()).As<IServiceProxy>().SingleInstance();
            builder.Register(x => new CommonServiceResult()).As<IServiceResult>().SingleInstance();
            builder.Register(x => new PageLocator()).As<IPageLocator>().SingleInstance();
            builder.Register(x => new UserDAL()).As<IRepository<User>>().SingleInstance();
            //builder.Register(x => DependencyService.Get<INetworkService>()).As<INetworkService>().SingleInstance();
            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }

    
}
