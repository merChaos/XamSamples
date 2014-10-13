using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common
{
    public class ProgressConfig
    {

        public ProgressConfig()
        {
            this.CancelText = "Cancel";
            this.AutoShow = true;
            this.Title = "Loaging...";
        }

        public bool AutoShow { get; set; }

        public string Title { get; set; }

        public string CancelText { get; set; }

        public bool IsDeterministic { get; set; }

        public Action OnCancel { get; set; }


    }
}
