using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamProjRef1.View
{
    public class DashboardView : BaseView
    {
        public DashboardView()
        {
            this.Title = "Dashboard";
            this.Icon = "Home.png";
            //this.BackgroundColor = new Xamarin.Forms.Color(10, 20, 20, 5);

            var lblLength = new Label()
            {
                FontSize = 20.0
            };
            lblLength.SetBinding(Label.TextProperty, new Binding("StringLength", BindingMode.OneWay));


            var backButton = new Button
            {
                Text = "Back",
                BorderRadius = 4,
                MinimumWidthRequest = 60,
                MinimumHeightRequest = 20
            };

            backButton.SetBinding(Button.CommandProperty, "BackCommand");

            this.Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = { backButton, lblLength }
            };

        }
    }
}
