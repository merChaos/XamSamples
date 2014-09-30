using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.LocalDB;
using XamProjRef1.Model;
using XamProjRef1.Service;

namespace XamProjRef1.BusinessLogic
{
    public static class UserManager
    {
        private static IServiceProxy serviceProxy = null;
        private static IRepository<User> userLocalDb = null;
        static UserManager()
        {
            serviceProxy = IocContainer.Resolve <IServiceProxy>();
            userLocalDb = IocContainer.Resolve<IRepository<User>>();
        }

        public static bool AuthenticateUser(User user)
        {
            // authenticate user with the seervice
            IServiceResult result = serviceProxy.AuthenticateUser(user);
            // if true save it to db
            if(result.Code == 1)
            {
                userLocalDb.Save(user);
            }

            return true;
        }
    }
}
