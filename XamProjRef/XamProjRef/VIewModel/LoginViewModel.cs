using System;
using System.Collections.Generic;
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
        // ICommand implementations
        public ICommand SubmitLogin { protected set; get; }

        public LoginViewModel()
        {
            this.SubmitLogin = new Command<string>((key) =>
            {
                // call the service and get the return message and show in the screen. 
                Login logObj = new Login();
                logObj.UserId = this.UserId;
                logObj.Password = this.Password;

                SubmitLoginDetails(logObj);
            });
        }

        private void SubmitLoginDetails(Login logObj)
        {
            //
        }

        private const string _UserIdPropertyName = "UserId";
        private string _UserId;
        public string UserId 
        {
            get {
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
