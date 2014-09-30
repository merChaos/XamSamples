﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamProjRef1.Helper;
using XamProjRef1.View;
using XamProjRef1.ViewModel;

namespace XamProjRef1
{
    public class App
    {
        //private static INavigation navigator;

        public static INavigation Navigator { get; set; }

        public static Page GetMainPage()
        {
            IocContainer.Build();
            var page = RootView.FirstView;
            Navigator = page.Navigation;
            return page;

        }

        public static void NavigateTo<T>(object args = null) 
        {
            var page = IocContainer.Resolve<IPageLocator>().ResolvePage(typeof(T), args);
            Navigator.PushAsync(page);
        }

    }
}
