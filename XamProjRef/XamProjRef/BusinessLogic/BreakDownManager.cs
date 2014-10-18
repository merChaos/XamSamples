using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Service;
using xBrainLab.Security.Cryptography;
using BreakdownCreate = XamProjRef1.Model.BreakdownCreate;
using BreakdownCreateResult = XamProjRef1.Model.BreakdownCreateResult;
using CSRFToken = XamProjRef1.Model.CSRFToken;

namespace XamProjRef1.BusinessLogic
{
    public static class BreakDownManager 
    {
        public static IServiceProxy ServiceProxy { get; set; }

        static BreakDownManager()
        {
            ServiceProxy = IocContainer.Resolve<IServiceProxy>();
        }

        public static async Task<BreakdownCreateResult.BreakdownCallCreateResult> RegisterBreakdown(XamProjRef1.Model.BreakdownCreate.Location location)
        {
            try
            {

                // mocking the membership here - this will be available after registration
                var membership = new BreakdownCreate.MembershipDetails()
                        {
                            MembershipNo = "2313123",
                            MobileNumber = "9846123111",
                            Name = "RKA",
                            VehicleReg = "BD51 RKA"
                        };

                // do the Validation here
                if (location == null) { throw new ArgumentNullException("location"); }

                //Guid Key = MD5(CompanyKey . MobileNumber . MembershipNo)
                var hashInput = string.Concat(Settings.CompanyName, membership.MobileNumber, membership.MembershipNo);
                //byte[] hash = MD5.GetHash(hashInput);
                string key = MD5.GetHashString(hashInput);

                SessionToken token = await ValidateToken();
                BreakdownCreate.BreakDownRootObject breakdownRoot = new BreakdownCreate.BreakDownRootObject()
                {
                    breakdownCall_CREATE = new BreakdownCreate.BreakdownCallCREATE()
                    {
                        BreakdownCallInfo = new BreakdownCreate.BreakdownCallInfo()
                        {
                            Company = "Halifax",
                            Key = key,// MD5 hashing required
                            Location = location,
                            MembershipDetails = membership
                        }
                    }
                };

                //serviceProxy
                // get the token id, set it in the header for the break down call. 
                IServiceResult result = await ServiceProxy.RegisterBreakdown(breakdownRoot, token.TokenId);
                return result.ReturnObject as BreakdownCreateResult.BreakdownCallCreateResult;// check the conversion. 
            }
            catch (Exception ex)
            {
                // log the exception
                throw ex;
            }
        }



        public async static Task<SessionToken> ValidateToken()
        {
            SessionToken token = Settings.Session;

            //NOTE: 18 should be read from a configuration, chance that it can change later. 
            if (token != null && token.SessionElapsedTime < 18) { return Settings.Session; }
            else
            {
                var serviceResponse = await ServiceProxy.GetCSRFToken();
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
