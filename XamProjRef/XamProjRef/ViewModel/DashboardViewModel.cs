using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamProjRef1.ViewModel
{
    class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {

        }

        public Command backCommand { protected set; get; }
        public const string BackCommandName = "BackCommand";
        public Command BackCommand
        {
            get { return backCommand ?? (backCommand = new Command(() => App.NavigateTo<Page1ViewModel>(null,false))); }
        }
    }
}
