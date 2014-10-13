using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Common;
using XamProjRef1.ViewModel;

namespace XamProjRef1.Helper
{
    public static class Extensions
    {
        #region IOC Container Extension methods

        public static void BindViewModel(this Page page, IViewModel viewModel)
        {
            page.BindingContext = viewModel;

            page.Appearing += (sender, args1) => viewModel.OnAppearing();
            page.Disappearing += (sender, args1) => viewModel.OnDisappearing();
        } 
        #endregion

        #region AutoFac Entension methods

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
        #endregion

        #region UserDialog Extension methods

        #region Async Helpers

        public static Task AlertAsync(this IUserDialog dialogs, string message, string title = null, string okText = "OK") {
            var tcs = new TaskCompletionSource<object>();
            dialogs.Alert(message, title, okText, () => tcs.SetResult(null));
            return tcs.Task;
        }


        public static Task AlertAsync(this IUserDialog dialogs, AlertConfig config) {
            var tcs = new TaskCompletionSource<object>();
            config.OkButtonAction = () => tcs.SetResult(null);
            dialogs.Alert(config);
            return tcs.Task;    
        }


        public static Task<bool> ConfirmAsync(this IUserDialog dialogs, string message, string title = null, string okText = "OK", string cancelText = "Cancel") {
            var tcs = new TaskCompletionSource<bool>();
            dialogs.Confirm(message, tcs.SetResult, title, okText, cancelText);
            return tcs.Task;
        }


        public static Task<bool> ConfirmAsync(this IUserDialog dialogs, ConfirmConfig config) {
            var tcs = new TaskCompletionSource<bool>();
            config.OnConfirm = tcs.SetResult;
            dialogs.Confirm(config);
            return tcs.Task;
        }

  
        #endregion


        #region Legacy Methods

        
        public static void Alert(this IUserDialog dialogs, string message, string title = null, string okText = "OK", Action onOk = null) {
            dialogs.Alert(new AlertConfig {
                Message = message,
                AlertTitle = title,
                OkButtonText = okText,
                OkButtonAction = onOk
            });
        }


        public static void Confirm(this IUserDialog dialogs, string message, Action<bool> onConfirm, string title = null, string okText = "OK", string cancelText = "Cancel") {
            dialogs.Confirm(new ConfirmConfig {
                CancelButtonText = cancelText,
                Message = message,
                OkButtonText = okText,
                OnConfirm = onConfirm,
                Title = title
            });
        }


        
        public static IProgressDialog Loading(this IUserDialog dialogs, string title = null, Action onCancel = null, string cancelText = "Cancel", bool show = true) {
            return dialogs.Progress(new ProgressConfig {
                Title = title,
                AutoShow = show,
                CancelText = cancelText,
                IsDeterministic = false,
                OnCancel = onCancel
            });
        }


        public static IProgressDialog Progress(this IUserDialog dialogs, string title = null, Action onCancel = null, string cancelText = "Cancel", bool show = true) {
            return dialogs.Progress(new ProgressConfig {
                Title = title,
                AutoShow = show,
                CancelText = cancelText,
                IsDeterministic = true,
                OnCancel = onCancel
            });
        }

        #endregion
        
        #endregion
    }
}
