using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;

namespace XamProjRef1.Service
{
    public class ServiceProxy : IServiceProxy
    {
        public IServiceResult AuthenticateUser(User user)
        {
            var serviceResult = IocContainer.Resolve<IServiceResult>();
            serviceResult.Code = 1; // some code that the BL will interepret
            serviceResult.ReturnMessage = "Some message based on the actual service call";
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
                //PortableRest.RestClient client = new PortableRest.RestClient();
                //PortableRest.RestRequest request = new PortableRest.RestRequest("https://gist.github.com/jamesmontemagno/a54af53e027308362415/raw/a828b194254b241281aad79cd362c33295fdb183/gistfile1.txt");
                //request.Method = HttpMethod.Get;
                //request.ContentType = PortableRest.ContentTypes.Json;
                //var result = await client.ExecuteAsync<string>(request);
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




        public Task<IServiceResult> GetCSRFToken()
        {
            return null;
            //var serviceResult = IocContainer.Resolve<IServiceResult>();
            //HttpClient objClient = new HttpClient();
            //objClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //objClient.DefaultRequestHeaders.Add("LocalDBUser_CREATE|PASSWORD", "tjadmin");
            //objClient.DefaultRequestHeaders.Add("LocalDBUser_CREATE|USERNAME", "tjadmin");
            //objClient.DefaultRequestHeaders.Add("LocalDBUser_CREATE|COMPANY_NAME", "Assurant");

            //// Move the service URL to constant class for easy management. 

            //HttpResponseMessage respMsg = await objClient.PostAsync("https://gamma.appintegration.trumobi.com/Assurant/v1/BreakdownCall/CSRFTokenGeneration", new StringContent("", Encoding.UTF8, "application/json"));
            //if (respMsg.StatusCode == HttpStatusCode.OK)
            //{
            //    var requiredHeader = respMsg.Headers.ToList().Where(i => i.Key == "CSRF_Token").FirstOrDefault();
            //    serviceResult.Code = 1;
            //    serviceResult.ReturnMessage = "Success";
            //    serviceResult.ReturnObject = requiredHeader.Value.FirstOrDefault();
            //    return serviceResult;
            //}
            //else
            //{
            //    // check for error
            //    Stream str = await respMsg.Content.ReadAsStreamAsync();
            //    var result = DecompressData(str);
            //    // de serralize result to TJResult. 
            //    serviceResult.Code = 0;
            //    serviceResult.ReturnMessage = "Failure";
            //    serviceResult.ReturnObject = result;
            //    return serviceResult;
            //}
        }



        public Task<IServiceResult> RegisterBreakdown(object breakdown)
        {
            throw new NotImplementedException();
        }
    }
}