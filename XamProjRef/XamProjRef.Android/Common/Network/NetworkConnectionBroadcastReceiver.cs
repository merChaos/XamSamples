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
using Android.Net;


namespace XamProjRef.Droid.Common.Network
{
    [BroadcastReceiver(Enabled=true,Label="Network Status Receiver")]
    [IntentFilter(new string[] { "android.net.conn.CONNECTIVITY_CHANGE" })]
    class NetworkConnectionBroadcastReceiver : BroadcastReceiver
    {
        internal static Action<NetworkInfo> OnChange { get; set; }

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Extras == null || OnChange == null)
                return;

            var ni = intent.Extras.Get(ConnectivityManager.ExtraNetworkInfo) as NetworkInfo;
            if (ni == null)
                return;
            OnChange(ni);
        }
    }
}