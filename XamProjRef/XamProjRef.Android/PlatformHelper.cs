using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Xamarin.Forms;

namespace XamProjRef.Droid
{
    public static class PlatformHelper
    {
        public static void RequestMainThread(Action action)
        {
            if (Android.App.Application.SynchronizationContext == SynchronizationContext.Current)
            {
                action();
            }
            else
            {
                Android.App.Application.SynchronizationContext.Post(x => MaskedException(action), null);
            }
        }

        private static void MaskedException(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                
                
            }
        }

        public static Context GetActivityContext()
        {
            return Forms.Context;
        }

    }
}