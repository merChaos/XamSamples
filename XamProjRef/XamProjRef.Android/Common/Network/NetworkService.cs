using System;
using System.Threading.Tasks;
using Android.App;
using Android.Net;
using Java.Net;
using Xamarin.Forms;
using XamProjRef.Droid.Common.Network;
using XamProjRef1.Common.Network;

[assembly: Dependency(typeof(NetworkService))]


namespace XamProjRef.Droid.Common.Network
{

    public class NetworkService : AbstractNetworkService
    {

        public NetworkService()
        {
            NetworkConnectionBroadcastReceiver.OnChange = this.SetFromInfo;
            var manager = (ConnectivityManager)Forms.Context.GetSystemService(Android.App.Application.ConnectivityService);
            this.SetFromInfo(manager.ActiveNetworkInfo);
        }


        private void SetFromInfo(NetworkInfo network)
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
