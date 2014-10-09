using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common
{
    public class AlertConfig
    {
        public AlertConfig()
        {
            this.OkButtonText = "Ok"; // Default text
        }

        public string AlertTitle { get; set; }

        public string Message { get; set; }

        public string OkButtonText { get; set; }

        public Action OkButtonAction { get; set; }


    }
}
