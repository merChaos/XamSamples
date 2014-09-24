using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.ViewModel;

namespace XamProjRef1.Helper
{
    public class PageLocator: IPageLocator
    {
        public Page ResolvePage(IViewModel viewModel)
        {
            var pageType = this.FindPageForViewModel(viewModel.GetType());
            var page = this.CreatePage(pageType);
            page.BindViewModel(viewModel); // extension meths
            return page;
        }

        public Xamarin.Forms.Page ResolvePage(Type viewModelType, object args = null)
        {
            var viewModel = this.CreateViewModel(viewModelType);
            viewModel.Init(args);
            return this.ResolvePage(viewModel);
        }

        protected virtual IViewModel CreateViewModel(Type viewModelType)
        {
            return Activator.CreateInstance(viewModelType) as IViewModel;
        }

        protected virtual Page CreatePage(Type pageType)
        {
            return Activator.CreateInstance(pageType) as Page;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {
            var pageTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace("ViewModel", "View");

            var pageType = Type.GetType(pageTypeName);
            if (pageType == null)
                throw new ArgumentException(pageTypeName + " type not exist");

            return pageType;
        }
    }
}
