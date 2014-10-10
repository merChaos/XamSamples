using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.ViewModel;

namespace XamProjRef1.Helper
{
    public static class Extensions
    {
        
        public static void BindViewModel(this Page page, IViewModel viewModel)
        {
            page.BindingContext = viewModel;

            page.Appearing += (sender, args1) => viewModel.OnAppearing();
            page.Disappearing += (sender, args1) => viewModel.OnDisappearing();
        }

        public static ContainerBuilder RegisterMvvmComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
               .RegisterType<AutoFacPageLocator>()
               .As<IPageLocator>()
               .SingleInstance();

            builder
                .RegisterViewModels(assemblies)
                .RegisterViews(assemblies);

            return builder;
        }

        /// <summary>
        /// Extension Method will register all the View Models under the passed assembly
        /// </summary>
        /// <param name="builder">IOC container</param>
        /// <param name="assemblies">assembly</param>
        /// <returns>IOC Container</returns>
        public static ContainerBuilder RegisterViewModels(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(x =>
                    x.GetTypeInfo().IsClass &&
                    !x.GetTypeInfo().IsAbstract &&
                    x.GetTypeInfo().ImplementedInterfaces.Any(y => y == typeof(IViewModel))
                )
                .InstancePerDependency();

            return builder;
        }


        /// <summary>
        /// Extension Method will register all the class inherited from base Xamarin.Forms.Page class
        /// </summary>
        /// <param name="builder">IOC container</param>
        /// <param name="assemblies">assembly</param>
        /// <returns>IOC Container</returns>
        public static ContainerBuilder RegisterViews(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(x =>
                    x.GetTypeInfo().IsClass &&
                    !x.GetTypeInfo().IsAbstract &&
                    x.GetTypeInfo().IsSubclassOf(typeof(Page))
                )
                .InstancePerDependency();

            return builder;
        }

        /// <summary>
        /// Extension method to resolve the platform specific dependency using Xamarin Dependency service
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="builder">IOC Container</param>
        /// <returns></returns>
        public static ContainerBuilder RegisterPlatformDependency<T>(this ContainerBuilder builder) where T : class
        {
            builder.Register(x => DependencyService.Get<T>()).SingleInstance();
            return builder;
        }
    }
}
