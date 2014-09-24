using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.ViewModel;

namespace XamProjRef1.Helper
{
    public interface IPageLocator 
    {
        Page ResolvePage(IViewModel viewModel);

        Page ResolvePage(Type viewModelType, object args = null);
    }
}
