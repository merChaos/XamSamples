using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.VIewModel;

namespace XamProjRef1.View
{
    public class LoginView1 : BaseView
    {
        public LoginView1(LoginViewModel loginViewModel)
        {
            //Padding = new Thickness(20);



            var userIdInput = new Entry
            {
                Placeholder = "User Id ",
                MinimumHeightRequest = 20
            };

            var passwordInput = new Entry
            {
                Placeholder = "Password ",
                IsPassword = true,
                MinimumWidthRequest = 60,
                MinimumHeightRequest = 20
            };

            var loginButton = new Button
            {
                Text = "Login",
                BorderRadius = 4,
                Command = loginViewModel.SubmitLogin,
                MinimumWidthRequest = 60,
                MinimumHeightRequest = 20
            };

            Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = { userIdInput, passwordInput, loginButton}
            };

            loginViewModel.UserId = userIdInput.Text;
            loginViewModel.Password = passwordInput.Text;
        }
    }
}
