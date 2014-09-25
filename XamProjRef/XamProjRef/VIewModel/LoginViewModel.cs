using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamProjRef1.Model;
using XamProjRef1.Service;
using XamProjRef1.View;

namespace XamProjRef1.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private Variables

        IServiceProxy proxy;

        #endregion

        #region CTOR
        public LoginViewModel() : this(IocContainer.Resolve<IServiceProxy>()) { }

        public LoginViewModel(IServiceProxy proxy)
        {
            this.proxy = proxy;
        }

        #endregion

        #region Properties
        private const string UserIdPropertyName = "UserId";
        private string _UserId = string.Empty;
        public string UserId
        {
            get
            {
                return _UserId;
            }

            set { _UserId = value; OnPropertyChanged(UserIdPropertyName); }
        }

        private const string PasswordPropertyName = "Password";
        private string _Password = string.Empty;
        public string Password
        {
            get
            {
                return _Password;
            }

            set { _Password = value; OnPropertyChanged(PasswordPropertyName); }
        }
        #endregion

        #region Commands
        // Command implementations
        public Command submitLoginCommand { protected set; get; }
        public Command forgotPasswordCommand { protected set; get; }
        public Command forgotUserIdCommand { protected set; get; }

        public const string SubmitLoginCommandName = "SubmitLoginCommand";
        public Command SubmitLoginCommand
        {
            get { return submitLoginCommand ?? (submitLoginCommand = new Command(async () => await ExecuteLogin())); }
        }

        public const string ForgotPasswordCommandName = "ForgotPasswordCommand";
        public Command ForgotPasswordCommand
        {
            get { return forgotPasswordCommand ?? (forgotPasswordCommand = new Command(async () => await ExecuteForgotPassword())); }
        }

        public const string ForgotUserIdCommandName = "ForgotUserIdCommand";
        public Command ForgotUserIdCommand
        {
            get { return forgotUserIdCommand ?? (forgotUserIdCommand = new Command(async () => await ExecuteForgotUserId())); }
        }


        private async Task ExecuteForgotPassword()
        {
            // Navigate to Forgot Password page;
        }

        private async Task ExecuteForgotUserId()
        {
            // Navigate to Forgot userid page;
        }

        private async Task ExecuteLogin()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                //await Task.Run(() =>
                //    {
                ServiceCall();
                //}
                //);

            }
            catch (Exception ex)
            {
                var page = new ContentPage();
                page.DisplayAlert("Error", ex.Message, "OK", null);
                // Option 1 send the complete ex as email
                // option 2 save in local db and do offline sync.
            }

            IsBusy = false;

        }

        #endregion

        #region BL Calls

        private void ServiceCall()
        {
            User u = new User();
            u.UserId = this.UserId;
            u.Password = this.Password;
            var result = proxy.AuthenticateUser(u);
            App.NavigateTo<DashboardViewModel>();
        }

        #endregion

    }
}
