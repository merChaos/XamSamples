using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.ViewModel;

namespace XamProjRef1.View
{
    public class LoginView : BaseView
    {
        public LoginView(LoginViewModel loginViewModel)
        {
            //Padding = new Thickness(20);
            this.BindingContext = loginViewModel;

            var userIdInput = new Entry
            {
                Placeholder = "User Id ",
                MinimumHeightRequest = 20
            };
            //userIdInput.Text = loginViewModel.UserId;
            userIdInput.SetBinding(Entry.TextProperty, "UserId");

            var passwordInput = new Entry
            {
                Placeholder = "Password ",
                IsPassword = true,
                MinimumWidthRequest = 60,
                MinimumHeightRequest = 20
            };
            //passwordInput.Text = loginViewModel.Password;
            passwordInput.SetBinding(Entry.TextProperty, "Password");


            var loginButton = new Button
            {
                Text = "Login",
                BorderRadius = 4,
                MinimumWidthRequest = 60,
                MinimumHeightRequest = 20
                //Command = loginViewModel.SubmitLoginCommand
            };
            loginButton.SetBinding(Button.CommandProperty, LoginViewModel.SubmitLoginCommandName);

            var activity = new ActivityIndicator
            {
                IsEnabled = true
            };
            activity.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            

            this.Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = { userIdInput, passwordInput, loginButton, activity }
            };

        }
    }
}
