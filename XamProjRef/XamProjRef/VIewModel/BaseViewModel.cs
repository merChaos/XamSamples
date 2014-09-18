﻿using System;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
