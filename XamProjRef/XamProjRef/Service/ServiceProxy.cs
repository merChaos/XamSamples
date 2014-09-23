using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;

namespace XamProjRef1.Service
{
    public class ServiceProxy : IServiceProxy
    {
        public IServiceResult AuthenticateUser(User user)
        {
            // do the service call
            // parse json input and output parameter

            var serviceResult = IocContainer.Resolve<IServiceResult>();
            serviceResult.Code = 1; // some code that the BL will interepret
            serviceResult.ReturnMessage = "Some message based on the actual service call";
            serviceResult.ReturnObject = user;
            return serviceResult;
        }
    }
}
