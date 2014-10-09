using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Common.Network;

namespace XamProjRef1.ViewModel
{
    public class BaseViewModel : IViewModel 
    {
        public INetworkService Network { get; private set; }

        public BaseViewModel()
        {
            Network = IocContainer.Resolve<INetworkService>();
        }

        private string _Title;
        public const string TitlePropertyName = "Title";
        public string Title 
        {   get { return _Title;}
            set { _Title = value; OnPropertyChanged(TitlePropertyName); } 
        }

        private bool _IsBusy;
        public const string _IsBusyPropertyName = "IsBusy";
        public bool IsBusy 
        {
            get { return _IsBusy; }
            set { _IsBusy = value; OnPropertyChanged(_IsBusyPropertyName); }
        }

        private string _Icon;
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; OnPropertyChanged(IconPropertyName); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Init(object args)
        {
            
        }

        public virtual void OnAppearing()
        {
            // check if Network available
        }

        public virtual void OnDisappearing()
        {
            
        }
    }
}
