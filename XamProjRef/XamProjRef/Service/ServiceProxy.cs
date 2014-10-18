using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;
using BreakdownCreate = XamProjRef1.Model.BreakdownCreate;
using BreakdownCreateResult = XamProjRef1.Model.BreakdownCreateResult;
using CSRFToken = XamProjRef1.Model.CSRFToken;


namespace XamProjRef1.Service
{
    public class ServiceProxy : IServiceProxy
    {
        public IServiceResult AuthenticateUser(User user)
        {
            var serviceResult = IocContainer.Resolve<IServiceResult>();
            serviceResult.StatusCode = "1"; // some code that the BL will interepret
            serviceResult.Message = "Some message based on the actual service call";
            serviceResult.ReturnObject = user;
            return serviceResult;
        }

        public async Task<IServiceResult> Test()
        {
            var serviceResult = IocContainer.Resolve<IServiceResult>();
            var a = await test();
            serviceResult.ReturnObject = a;
            return serviceResult;
        }

        private async Task<string> test()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync("https://gist.github.com/jamesmontemagno/a54af53e027308362415/raw/a828b194254b241281aad79cd362c33295fdb183/gistfile1.txt");
                return result.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to query and gather expenses");
                throw ex;
            }
            finally
            {
            }
        }




        public async Task<IServiceResult> GetCSRFToken()
        {
            try
            {

                //return null;
                var serviceResult = IocContainer.Resolve<IServiceResult>();
                HttpClient objClient = new HttpClient();
                objClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                objClient.DefaultRequestHeaders.Add("LocalDBUser_CREATE|PASSWORD", "tjadmin");
                objClient.DefaultRequestHeaders.Add("LocalDBUser_CREATE|USERNAME", "tjadmin");
                objClient.DefaultRequestHeaders.Add("LocalDBUser_CREATE|COMPANY_NAME", "Assurant");

                // Move the service URL to constant class for easy management. 
                HttpResponseMessage respMsg = await objClient.PostAsync("https://gamma.appintegration.trumobi.com/Assurant/v1/BreakdownCall/CSRFTokenGeneration", new StringContent("", Encoding.UTF8, "application/json"));
                if (respMsg.StatusCode == HttpStatusCode.OK)
                {
                    var requiredHeader = respMsg.Headers.ToList().Where(i => i.Key == "CSRF_Token").FirstOrDefault();
                    serviceResult.StatusCode = respMsg.StatusCode.ToString();
                    serviceResult.Message = "Success";
                    serviceResult.ReturnObject = requiredHeader.Value.FirstOrDefault();
                }
                else
                {
                    //CHECK BREAK POINT ON DEVICE
                    var csrfToken = JsonConvert.DeserializeObject<CSRFToken.CSRFTokenRootObject>(respMsg.Content.ToString());
                    serviceResult.StatusCode = respMsg.StatusCode.ToString();
                    serviceResult.Message = "Access Denied";
                    serviceResult.ReturnObject = csrfToken;
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }



        public async Task<IServiceResult> RegisterBreakdown(BreakdownCreate.BreakDownRootObject breakdownRootObj, string csrfToken)
        {
            try
            {
                var serviceResult = IocContainer.Resolve<IServiceResult>();
                HttpClient objClient = new HttpClient();
                objClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                objClient.DefaultRequestHeaders.Add("CSRF_Token", csrfToken);
                var breakDownPostData = JsonConvert.SerializeObject(breakdownRootObj);

                // Move the service URL to constant class for easy management. 
                HttpResponseMessage respMsg = await objClient.PostAsync("https://gamma.appintegration.trumobi.com/Assurant/v1/BreakdownCall/OrchbreakdownCallCREATE", new StringContent(breakDownPostData, Encoding.UTF8, "application/json"));
                if (respMsg.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = await respMsg.Content.ReadAsStringAsync();
                    var breakdownResponse = JsonConvert.DeserializeObject<BreakdownCreateResult.BreakdownCallCreateResult>(responseContent);
                    serviceResult.StatusCode = respMsg.StatusCode.ToString();
                    serviceResult.Message = "Service Call Success"; // put any other message if required
                    serviceResult.ReturnObject = breakdownResponse;
                }
                else
                {
                    //CHECK BREAK POINT ON DEVICE
                    var responseContent = respMsg.Content.ToString();
                    var breakdownResponse = JsonConvert.DeserializeObject<BreakdownCreateResult.BreakdownCallCreateResult>(respMsg.Content.ToString());
                    serviceResult.StatusCode = respMsg.StatusCode.ToString();
                    serviceResult.Message = "Error";
                    serviceResult.ReturnObject = responseContent;
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}