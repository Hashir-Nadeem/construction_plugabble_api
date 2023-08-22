using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataverse.Interfaces;

namespace Dataverse.Implementations
{
    public class Location : ILocation
    {
        public async Task<HttpResponseMessage> GetLocations(HttpClient client, string jobId)
        {
            HttpRequestMessage getRequest = new(
            method: HttpMethod.Get,
            requestUri: String.Format("imz_assignedlocations?$filter=_imz_cr6fc_project_value eq '{0}'&$expand=imz_new_JobLocation($expand=imz_Defaults)", jobId));
            getRequest.Headers.Add("Prefer", "odata.include-annotations=\"*\"");



            HttpResponseMessage response = await client.SendAsync(request: getRequest);
            return response;
        }
    }
}
