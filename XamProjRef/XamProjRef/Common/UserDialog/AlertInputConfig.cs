using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common
{
    public class AlertInputConfig
    {
        public AlertInputConfig()
        {
            this.OkText = "Ok";
            this.CancelText = "Cancel";
        }

        public string AlertTitle { get; set; }

        public string Message { get; set; }

        public string Regex { get; set; }

        public Action<AlertInputResult> OnActionCallBack { get; set; }

        public bool IsTextSecure { get; set; }

        public string PlaceHolder { get; set; }

        public string OkText { get; set; }

        public string CancelText { get; set; }

    }

    public class AlertInputResult
    {
        public string InputText { get; set; }

        public bool Ok { get; set; }

    }
}
