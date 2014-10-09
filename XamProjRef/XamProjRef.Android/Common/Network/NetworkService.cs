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
using XamProjRef1.Common.Network;
using System.Threading.Tasks;
using Xamarin.Forms;

using XamProjRef.Droid.Common.Network;
using Android.Net;
using Java.Net;

[assembly: Dependency(typeof(NetworkService))]
namespace XamProjRef.Droid.Common.Network
{
    public class NetworkService : AbstractNetworkService
    {

        public NetworkService()
        {
            NetworkConnectionBroadcastReceiver.OnChange = this.SetFromInfo;
            var manager = (ConnectivityManager)Forms.Context.GetSystemService(Application.ConnectivityService);
            this.SetFromInfo(manager.ActiveNetworkInfo);
        }


        public void SetFromInfo(NetworkInfo network)
        {
            if (network == null || !network.IsConnected)
                this.IsConnected = false;
            else
            {
                this.IsConnected = true;
                this.IsRoaming = network.IsRoaming;
                this.IsWifi = (network.Type == ConnectivityType.Wifi);
                this.IsMobile = (network.Type == ConnectivityType.Mobile);
            }
            this.PostUpdateStates();
        }


        public override Task<bool> IsHostReachable(string host)
        {
            return Task<bool>.Run(() =>
            {
                if (!this.IsConnected)
                    return false;

                try
                {
                    return InetAddress
                        .GetByName(host)
                        .IsReachable(5000);
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}