using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;
using BreakdownCreate = XamProjRef1.Model.BreakdownCreate;
using CSRFToken = XamProjRef1.Model.CSRFToken;

namespace XamProjRef1.Service
{
    public interface IServiceProxy
    {
        IServiceResult AuthenticateUser(User user);

        Task<IServiceResult> Test();

        Task<IServiceResult> GetCSRFToken();

        Task<IServiceResult> RegisterBreakdown(BreakdownCreate.BreakDownRootObject breakdown,string csrfToken);

    }
}
