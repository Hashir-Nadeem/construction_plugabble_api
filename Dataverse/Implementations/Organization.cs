using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataverse.Interfaces;

namespace Dataverse.Implementations
{
    public class Organization : IOrganization
    {
        public async Task<HttpResponseMessage> GetConfiguration(HttpClient client)
        {
            HttpRequestMessage getRequest = new(
            method: HttpMethod.Get,
            requestUri: "msdyn_serviceconfigurations");
            getRequest.Headers.Add("Prefer", "odata.include-annotations=\"*\"");
            HttpResponseMessage response = await client.SendAsync(request: getRequest);
            return response;
        }
        public async Task<HttpResponseMessage> GetOrganizationDetails(HttpClient client)
        {
            HttpRequestMessage getRequest = new(
                 method: HttpMethod.Get,
                 requestUri: "new_companyinfos?$expand=new_Policy");
            getRequest.Headers.Add("Prefer", "odata.include-annotations=\"*\"");
            var response = await client.SendAsync(request: getRequest);
            return response;
        }
    }
}
