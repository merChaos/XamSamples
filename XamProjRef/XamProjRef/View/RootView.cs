using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Model;
using XamProjRef1.VIewModel;

namespace XamProjRef1.View
{
    public static class RootView
    {
        private static Page _rootVIew;
        
        public static Page FirstView
        {
            // check the logic to decide which page to load. 
            //get { return _rootVIew ?? (_rootVIew = new NavigationPage(new RecipleListPage())); }
            get { return _rootVIew ?? (_rootVIew = new LoginView1(new LoginViewModel())); }
        }

    }
}
