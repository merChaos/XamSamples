using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common
{
    public class ConfirmConfig
    {
        public ConfirmConfig()
        {
            this.CancelButtonText = "Cancel";
            this.OkButtonText = "Ok";
        }

        public string Title { get; set; }

        public string Message { get; set; }

        public string OkButtonText { get; set; }

        public string CancelButtonText { get; set; }

        public Action<bool> OnConfirm { get; set; }


    }
}
