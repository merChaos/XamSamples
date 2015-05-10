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
            

            this.StringLength = "Loading....";
            using (var dlg = UserDialog.Progress("Progress"))
            {
                var lengthTask = UserManager.GetStringLength();
                Random rnd = new Random();
                while (dlg.PercentageComplete < 100)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    dlg.PercentageComplete += rnd.Next(0,10);
                    if (lengthTask.IsCompleted && dlg.PercentageComplete < 99) 
                    { 
                        var remaining = (99 - dlg.PercentageComplete); 
                        dlg.PercentageComplete += remaining; 
                    }
                }
                var len = await lengthTask;
                this.StringLength = len.ToString();
            }      
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
