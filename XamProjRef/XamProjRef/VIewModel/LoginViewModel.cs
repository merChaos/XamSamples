using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamProjRef1.BusinessLogic;
using XamProjRef1.Model;
using XamProjRef1.Service;
using XamProjRef1.View;
using BreakdownCreate = XamProjRef1.Model.BreakdownCreate;
using BreakdownCreateResult = XamProjRef1.Model.BreakdownCreateResult;


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
        public const string SubmitLoginCommandName = "SubmitLoginCommand";
        public Command SubmitLoginCommand
        {
            get { return submitLoginCommand ?? (submitLoginCommand = new Command(async () => await ExecuteLogin())); }
        }

        private async Task ExecuteLogin()
        {
            UserDialog.AlertWithInput("Hello World",
                (result) =>
                {
                    if (result.Ok) { UserDialog.Alert(result.InputText); }
                    else { UserDialog.Alert(result.InputText + "False"); }
                }, "Alert With Text");

            if (string.IsNullOrEmpty(this.UserId)) { UserDialog.Alert("User Id cannot be null", "Validation"); return; }
            if (Network != null && !this.Network.IsConnected)
            {
                UserDialog.Alert("No Network", "Error", "Ok", () => { this.UserId = "Hello"; });
                return;
            }

            if (IsBusy)
                return;
           

            IsBusy = true;
            try
            {
                await ServiceCall();
            }
            catch (Exception ex)
            {
                UserDialog.Alert(ex.Message,"Error" , "OK", null);
                // Option 1 send the complete ex as email
                // option 2 save in local db and do offline sync.
            }
            IsBusy = false;
        }

        #endregion

        #region BL Calls

        private async Task ServiceCall()
        {
            //User u = new User();
            //u.UserId = this.UserId;
            //u.Password = this.Password;
            //var result = UserManager.AuthenticateUser(u);
            //App.NavigateTo<RecipeListViewModel>();

            BreakdownCreate.Location location = new BreakdownCreate.Location();
            location.Accuracy = "10.0";
            location.Altitude = "0";
            location.Latitude = "51.3";
            location.Longitude = "-1.2";
            BreakdownCreateResult.BreakdownCallCreateResult result = await BreakDownManager.RegisterBreakdown(location);
            UserDialog.Alert(result.BreakDownCallMessage, "Breakdown Call Result");
        }
            
        #endregion

    }
}
