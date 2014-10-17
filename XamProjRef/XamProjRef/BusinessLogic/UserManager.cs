using Refractored.Xam.Settings.Abstractions;
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
            serviceProxy = IocContainer.Resolve<IServiceProxy>();
            userLocalDb = IocContainer.Resolve<IRepository<User>>();
        }

        public static bool AuthenticateUser(User user)
        {
            // authenticate user with the seervice
            IServiceResult result = serviceProxy.AuthenticateUser(user);
            // if true save it to db
            if (result.IsSuccess)
            {
                userLocalDb.Save(user);
            }

            return true;
        }

        public static Task<IServiceResult> RegisterBreakdown()
        {
            //SessionToken token = ValidateToken();
            Task.Run(() => ValidateToken());
            var result = serviceProxy.GetCSRFToken();
            
            return result;
        }

       

        public async static Task<SessionToken> ValidateToken()
        {
            SessionToken token = Settings.Session;

            if (token != null && token.SessionElapsedTime < 18) { return Settings.Session; }
            else
            {
                var serviceResponse = await serviceProxy.GetCSRFToken();
                if (serviceResponse.ReturnObject != null)
                {
                    var newToken = serviceResponse.ReturnObject;
                    token = new SessionToken() { TokenId = newToken.ToString() };
                    // Save the token in the global variable for uses;
                    Settings.Session = token;
                }
            }

            return token;
        }
    }
}

