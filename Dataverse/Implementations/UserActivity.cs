using Dataverse.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dataverse.Implementations
{
    public class UserActivity : IUserActivity
    {
        public async Task<HttpResponseMessage> CheckIn(HttpClient client, double longitude, double latitude, string date, string time, string status, string empId,string jobId)
        {
            var content = new JObject
            {

                {"new_latitude",latitude.ToString()},
                {"new_longitutde",longitude.ToString()},
                {"new_date",date },
                {"new_time",time },
                {"new_checkin",status },
                {"new_Employee@odata.bind",String.Format("/new_employees({0})",empId)},
                {"imz_cr6fc_Project@odata.bind",String.Format("/cr6fc_projects({0})",jobId) }
            };
            HttpRequestMessage createRequest = new(
                method: HttpMethod.Post,
                requestUri: new Uri(
                    uriString: "new_employeecheckinevents",
                    uriKind: UriKind.Relative))
            {
                Content = new StringContent(
                    content: content.ToString(),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request: createRequest);//make call


            return response;
        }
        public async Task<HttpResponseMessage> CheckOut(HttpClient client, double longitude, double latitude, string date, string time, string status, string empId, string jobId)
        {
            var content = new JObject
            {

               {"new_latitude",latitude.ToString()},
                {"new_longitutde",longitude.ToString()},
                {"new_date",date },
                {"new_time",time },
                {"new_checkin",status },
                {"new_Employee@odata.bind",String.Format("/new_employees({0})",empId)},
                {"imz_cr6fc_Project@odata.bind",String.Format("/cr6fc_projects({0})",jobId) }
            };
            HttpRequestMessage createRequest = new(
                method: HttpMethod.Post,
                requestUri: new Uri(
                    uriString: "new_employeecheckinevents",
                    uriKind: UriKind.Relative))
            {
                Content = new StringContent(
                    content: content.ToString(),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request: createRequest);//make call


            return response;
        }

    }
}
