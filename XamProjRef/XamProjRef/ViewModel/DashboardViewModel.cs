using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.BusinessLogic;

namespace XamProjRef1.ViewModel
{
    internal class DashboardViewModel : BaseViewModel
    {


        public DashboardViewModel()
        {

        }


        public async override void OnAppearing()
        {
            base.OnAppearing();

            // Call the service method in the background and populate the no of characters from the servie call. 
            var lengthTask = UserManager.GetStringLength();

            this.StringLength = "Loading....";

            var len = await lengthTask;
            this.StringLength = len.ToString();
             
        }

        public Command backCommand { protected set; get; }
        public const string BackCommandName = "BackCommand";
        public Command BackCommand
        {
            get { return backCommand ?? (backCommand = new Command(() => App.NavigateTo<Page1ViewModel>(null,false))); }
        }

        private string stringLength = string.Empty;
        public string StringLength
        {
            get
            {
                return stringLength;
            }
            set
            {
                stringLength = value; OnPropertyChanged("StringLength");
            }
        }


    }
}
