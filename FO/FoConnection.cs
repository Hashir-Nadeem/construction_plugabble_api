using ApiBase;
using Microsoft.Graph;

namespace FO
{
    public class FoConnection : IApiBase
    {
        

        public Task<HttpResponseMessage> CheckIn(string longitude, string latitude, string empId, string date, string time, string status)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckIn(double longitude, double latitude, double empId, string date, string time, double status)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckIn(double longitude, double latitude, string empId, string date, string time, string status)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckIn(double longitude, double latitude, string date, string time, string status)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckIn(double longitude, double latitude, string date, string time, string status, string empId, string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckOut(double longitude, double latitude, string date, string time, string status, string empId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckOut(double longitude, double latitude, string date, string time, string status, string empId, string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> emp()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Emp(string id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Emp()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetConfiguration()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetJobLocations()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetJobLocations(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetJobs(string id = "")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetLocations(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetOrganizationDetails()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> getPendings()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetPolicy()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetTimeSheetEntries(HttpClient client)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetTimeSheetEntries()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> LogIn()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Patch()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Post()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ReSentCode(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SentCode(string email, string password, string code)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SentCode(string Id, string code)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SignUp(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SignUp(string firstName, string lastName, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}