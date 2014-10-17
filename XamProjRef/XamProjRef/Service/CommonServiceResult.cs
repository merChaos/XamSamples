using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Service
{
    public class CommonServiceResult : IServiceResult
    {

        public string Message { get; set; }

        public object ReturnObject { get; set; }

        public bool IsSuccess { get; set; }

        public string StatusCode { get; set; }
    }
}
