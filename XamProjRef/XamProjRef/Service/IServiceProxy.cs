using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;

namespace XamProjRef1.Service
{
    public interface IServiceProxy
    {
        IServiceResult AuthenticateUser(User user);
    }
}
