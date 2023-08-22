using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBase
{
    public interface IApiBase
    {
        Task<HttpResponseMessage> LogIn();
        Task<HttpResponseMessage> SignUp(string firstName, string lastName, string email, string password);
        Task<HttpResponseMessage> GetJobs(string id = "");

        Task<HttpResponseMessage> CheckIn(double longitude, double latitude, string date, string time, string status,string empId, string jobId);
        Task<HttpResponseMessage> CheckOut(double longitude, double latitude, string date, string time, string status, string empId, string jobId);

        Task<HttpResponseMessage> SentCode(string Id, string code);
        Task<HttpResponseMessage> ReSentCode(string Id);
        Task<HttpResponseMessage> GetOrganizationDetails();
        Task<HttpResponseMessage> GetLocations(string jobId);
        Task<HttpResponseMessage> GetConfiguration();
        Task<HttpResponseMessage> GetTimeSheetEntries();






    }
}
