using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Service
{
    public interface IServiceResult
    {
        int Code { get; set; }

        string ReturnMessage { get; set; }

        object ReturnObject { get; set; }
    }
}
