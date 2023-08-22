using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataverse.Interfaces;

namespace Dataverse.Implementations
{
    public class Job : IJob
    {
        public async Task<HttpResponseMessage> GetJobs(HttpClient client, string empId)
        {
            HttpRequestMessage getRequest = new(
            method: HttpMethod.Get,
            requestUri: String.Format("imz_assignedjobs?$filter=_imz_new_employee_value eq '{0}'&$expand=imz_cr6fc_Project", empId));
            getRequest.Headers.Add("Prefer", "odata.include-annotations=\"*\"");
            HttpResponseMessage response = await client.SendAsync(request: getRequest);
            return response;
        }
    }
}
