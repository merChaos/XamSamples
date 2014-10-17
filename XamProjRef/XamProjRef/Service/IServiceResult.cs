using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Service
{
    public interface IServiceResult
    {
        string StatusCode { get; set; }

        string Message { get; set; }

        object ReturnObject { get; set; }

        bool IsSuccess { get; set; }
    }
}
