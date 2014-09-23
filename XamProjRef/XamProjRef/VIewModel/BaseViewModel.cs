using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.VIewModel
{
    public class BaseViewModel : INotifyPropertyChanged 
    {
        public BaseViewModel()
        {

        }

        private string _Name;
        public const string _NamePropertyName = "Name";
        public string Name 
        {   get { return _Name;}
            set { _Name = value; OnPropertyChanged(_NamePropertyName); } 
        }

        private bool _IsBusy;
        public const string _IsBusyPropertyName = "IsBusy";
        public bool IsBusy 
        {
            get { return _IsBusy; }
            set { _IsBusy = value; OnPropertyChanged(_IsBusyPropertyName); }
        }

        private string _Icon;
        public const string _IconPropertyName = "Icon";
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; OnPropertyChanged(_IconPropertyName); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
