using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamProjRef1.Model;

namespace XamProjRef1.VIewModel
{
    public class LoginViewModel : BaseViewModel
    {

        // Command implementations
        public Command submitLoginCommand { protected set; get; }

        public LoginViewModel()
        {

        }

        public Command SubmitLogin
        {
            get { return submitLoginCommand ?? (submitLoginCommand = new Command(SubmitLoginDetails)); }
        }

        private async void SubmitLoginDetails()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                await Task.Run(() =>
                    {
                        ServiceCall();
                    }
                    );

            }
            catch (Exception ex)
            {
                var page = new ContentPage();
                page.DisplayAlert("Error", "Oops!!! Something went wrong.Please try again", "OK", null);
                // Option 1 send the complete ex as email
                // option 2 save in local db and do offline sync.
            }

            IsBusy = false;

        }
           
        private void ServiceCall()
        {
            // all manager method

            // pass the required fields and get the result and show.
        }


        private const string _UserIdPropertyName = "UserId";
        private string _UserId;
        public string UserId
        {
            get
            {
                return _UserId;
            }

            set { _UserId = value; OnPropertyChanged(_UserIdPropertyName); }
        }

        private const string _PasswordPropertyName = "Password";
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }

            set { _Password = value; OnPropertyChanged(_PasswordPropertyName); }
        }

    }
}
