using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using System.Net;

namespace XamProjRef1.Droid
{
    [Activity(Label = "XamProjRef1", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            // Override the security check if as required
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                            (se, cert, chain, sslerror) => { 
                                // Assuming the certificate to be valid
                                return true; 
                            };

            SetPage(App.GetMainPage());

           
        }
    }
}

