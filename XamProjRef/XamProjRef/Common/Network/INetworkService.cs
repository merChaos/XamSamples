using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common.Network
{
    public interface INetworkService : INotifyPropertyChanged
    {
        Task<bool> IsHostReachable(string host);

        bool IsConnected { get; set; }

        bool IsWifi { get; set; }

        bool IsMobile { get; set; }

        bool IsRoaming { get; set; }

        event EventHandler<NetworkStatusChangedEventArgs> NetworkStatusChanged;
    }
}

public class NetworkStatusChangedEventArgs : EventArgs
{

    public NetworkStatusChangedEventArgs(bool isConnected, bool isWifi, bool isMobile, bool isRoaming)
    {
        this.IsConnected = isConnected;
        this.IsMobile = isMobile;
        this.IsWifi = isWifi;
        this.IsRoaming = isRoaming;
    }
    public bool IsConnected { get; private set; }

    public bool IsWifi { get; private set; }

    public bool IsMobile { get; private set; }

    public bool IsRoaming { get; private set; }
}
