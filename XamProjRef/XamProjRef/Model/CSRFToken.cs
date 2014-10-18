using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Model.CSRFToken
{
    public class Result
    {
        public string status { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public string type { get; set; }
    }

    public class CSRFTokenRootObject
    {
        public Result result { get; set; }
    }

}
