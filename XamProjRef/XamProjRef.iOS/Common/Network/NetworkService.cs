using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using XamProjRef1.Common.Network;
using XamProjRef.iOS.Common.Network;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkService))]
namespace XamProjRef.iOS.Common.Network
{
    public class NetworkService : AbstractNetworkService
    {
        public NetworkService()
        {
            this.SetInfo();
            Reachability.ReachabilityChanged += (s, e) => this.SetInfo();
        }

        public override System.Threading.Tasks.Task<bool> IsHostReachable(string host)
        {
            throw new NotImplementedException();
        }

        private void SetInfo()
        {
            var state = Reachability.InternetConnectionStatus();
            switch (state)
            {
                case NetworkStatus.NotReachable:
                    this.IsConnected = false;
                    break;

                case NetworkStatus.ReachableViaCarrierDataNetwork:
                    this.IsConnected = true;
                    this.IsWifi = false;
                    this.IsMobile = true;
                    this.IsRoaming = false;
                    break;

                case NetworkStatus.ReachableViaWiFiNetwork:
                    this.IsConnected = true;
                    this.IsWifi = true;
                    this.IsMobile = false;
                    this.IsRoaming = false;
                    break;
            }
            this.PostUpdateStates();
        }
    }
}