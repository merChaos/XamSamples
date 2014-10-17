using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.ViewModel;

namespace XamProjRef1
{
    public class AutoFacPageLocator : PageLocator
    {
        private readonly ILifetimeScope container;
        public AutoFacPageLocator(ILifetimeScope container)
        {
            this.container = container;
        }


        protected override Page CreatePage(Type pageType) {
            return this.container.Resolve(pageType) as Page;
        }


        protected override IViewModel CreateViewModel(Type viewModelType) {
            return this.container.Resolve(viewModelType) as IViewModel;
        }

    }
}
