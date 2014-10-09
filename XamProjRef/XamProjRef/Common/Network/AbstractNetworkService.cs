using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common.Network
{
    public abstract class AbstractNetworkService : INetworkService
    {
        public abstract Task<bool> IsHostReachable(string host);


        public bool IsConnected { get; set; }

        public bool IsWifi { get; set; }

        public bool IsMobile { get; set; }

        public bool IsRoaming { get; set; }

        public event EventHandler<NetworkStatusChangedEventArgs> NetworkStatusChanged;

        protected virtual void OnNetworkStatusChanged()
        {
            // check if event is hooked
            if (this.NetworkStatusChanged != null)
                this.NetworkStatusChanged(this, new NetworkStatusChangedEventArgs(this.IsConnected, this.IsWifi, this.IsMobile,this.IsRoaming));
        }

        protected void PostUpdateStates()
        {
            if (!this.IsConnected)
            {
                this.IsWifi = false;
                this.IsMobile = false;
                this.IsRoaming = false;
            }
            this.OnPropertyChanged("IsWifi");
            this.OnPropertyChanged("IsMobile");
            this.OnPropertyChanged("IsRoaming");
            this.OnPropertyChanged("IsConnected");
            this.OnNetworkStatusChanged();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
