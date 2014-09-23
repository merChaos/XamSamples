using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamProjRef1.View;

namespace XamProjRef1
{
    public class App
    {
        public static Page GetMainPage()
        {
            IocContainer.Build();
            return RootView.FirstView;
        }
    }
}
