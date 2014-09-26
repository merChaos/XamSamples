using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Service;

namespace XamProjRef1.ViewModel
{
    class Page1ViewModel : BaseViewModel
    {
        private IServiceProxy proxy = null;
        private string sessionVariable = string.Empty;


        public Page1ViewModel()
        {
            this.Title = "Page 1";
        }

        public Page1ViewModel(IServiceProxy proxy)
        {
            this.proxy = proxy;
        }

        public override void Init(object args)
        {
            if (args != null)
            {
                this.sessionVariable = args.ToString();

            }
        }

    }
}
