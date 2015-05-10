using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.ViewModel;

namespace XamProjRef1.View
{
    public class BaseView : ContentPage
    {
        public BaseView()
        {
            SetBinding(Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding(Page.IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            base.OnAppearing();
            this.Animate("", s => Layout(new Rectangle(((-1 + s) * Width), Y, Width, Height)), 16, 250, Easing.Linear, null, null);


            /*
            // Rotate and scale
            this.Rotation = 0;
            this.Scale = 1;
            this.RotateTo(360, 2000);
            Task.Run(async () =>
                {
                    await this.ScaleTo(0);
                    await this.ScaleTo(.25, 500, Easing.Linear);
                    await this.ScaleTo(.50, 500, Easing.Linear);
                    await this.ScaleTo(.75, 500, Easing.Linear);
                    await this.ScaleTo(1, 500, Easing.Linear);
                }
                );
            this.Scale = 0;
           */
        }

    }
}
