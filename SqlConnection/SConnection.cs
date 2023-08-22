using ApiBase;

namespace SqlConnection
{
    public class SConnection : IApiBase
    {
        public Task<HttpResponseMessage> CheckIn(double longitude, double latitude, string date, string time, string status, string empId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CheckOut(double longitude, double latitude, string date, string time, string status, string empId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Emp()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetJobs(string id = "")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetPolicy()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> LogIn()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SentCode(string email, string password, string code)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SignUp(string firstName, string lastName, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}