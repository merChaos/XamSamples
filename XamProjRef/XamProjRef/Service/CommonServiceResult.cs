using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Service
{
    public class CommonServiceResult : IServiceResult
    {

        public int Code { get; set; }

        public string ReturnMessage { get; set; }

        public object ReturnObject { get; set; }
    }
}
