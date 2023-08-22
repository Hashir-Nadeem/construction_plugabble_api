using Dataverse.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataverse.Implementations
{
    public class UserSetup : IUserSetup
    {
        public async Task<HttpResponseMessage> UserLogIn(HttpClient client)
        {

            HttpRequestMessage getRequest = new(
             method: HttpMethod.Get,
             requestUri: "new_employees");
            getRequest.Headers.Add("Prefer", "odata.include-annotations=\"*\"");



            HttpResponseMessage response = await client.SendAsync(request: getRequest);
            return response;

        }

        public async Task<HttpResponseMessage> UserSignUp(string firstName, string lastName, string email, string password)
        {
            HttpClient clientForTrigger = new HttpClient();
            var content = new JObject { { "new_firstname", firstName }, { "new_lastname", lastName }, { "new_email", email }, { "new_password", encryptDecrypt.encode(password) } };
            HttpRequestMessage createRequest = new(
                method: HttpMethod.Post,
                requestUri: new Uri(
                    uriString: "https://prod-204.westeurope.logic.azure.com:443/workflows/12beb2b7072b472c89966da008868cb9/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=uMzQf2l4Ew8oQiHf0EjZiweB23gAp0TPA2feQLR7sSU",
                    uriKind: UriKind.Absolute))
            {
                Content = new StringContent(
                    content: content.ToString(),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            var response = await clientForTrigger.SendAsync(request: createRequest);
            return response;
        }

        public async Task<HttpResponseMessage> VerificationCode(string Id, string code)
        {
            var clientForTrigger = new HttpClient();
            var content = new JObject { { "Id", Id }, { "new_code", code } };
            HttpRequestMessage createRequest = new(
                method: HttpMethod.Post,
                requestUri: new Uri(
                    uriString: "https://prod-244.westeurope.logic.azure.com:443/workflows/98f31298bd0842f18d626ca8b372f6b5/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=nYk7CXqq4xZOnXMHuJGgt-c9fpzziiUYArDFnLwyYnc",
                    uriKind: UriKind.Absolute))
            {
                Content = new StringContent(
                    content: content.ToString(),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            var response = await clientForTrigger.SendAsync(request: createRequest);
            return response;
        }
        public async Task<HttpResponseMessage> ResendCode(string Id)
        {
            var content = new JObject { { "Id", Id } };
            HttpRequestMessage createRequest = new(
                method: HttpMethod.Post,
                requestUri: new Uri(
                    uriString: "https://prod-62.westeurope.logic.azure.com:443/workflows/7d4e7ab2834b480fa2f9270de40513fd/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=lOPPpBRz_eOmvFtqN5il8V2g_rfNXbZsxOhjgCG5VEc",
                    uriKind: UriKind.Absolute))
            {
                Content = new StringContent(
                    content: content.ToString(),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };
            var clientForTrigger = new HttpClient();
            var response = await clientForTrigger.SendAsync(request: createRequest);
            return response;
        }
    }
}
