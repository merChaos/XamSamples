using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.ViewModel
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void Init(object args);

        void OnAppearing();

        void OnDisappearing();

    }
}
