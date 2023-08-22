
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;
using ApiBase;
using Dataverse.Interfaces;

namespace Dataverse
{
    public class DataverseConnection : IApiBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOrganization _organization;
        private readonly IUserSetup _userSetup;
        private readonly IUserActivity _userActivity;
        private readonly ILocation _jobLocation;
        private readonly IJob _job;
        private AuthenticationResult token;
        private HttpClient client;

        public DataverseConnection(IConfiguration configuration,IOrganization organization,IUserSetup userSetup,IUserActivity userActivity,ILocation jobLocation,IJob job)
        {
            _configuration = configuration;
            _organization = organization;
            _userSetup = userSetup;
            _userActivity = userActivity;
            _jobLocation = jobLocation;
            _job = job;
            setup();
           
        }

        public void setup()
        {
            var authBuilder = ConfidentialClientApplicationBuilder.Create(_configuration["Configuration:ClientId"])
                            .WithClientSecret(_configuration["Configuration:ClientSecret"])
                            .WithTenantId(_configuration["Configuration:TenantId"])
                            .WithRedirectUri(_configuration["Configuration:RedirectUri"])
                            .Build();

            var scope = _configuration["Configuration:Scope"];
            string[] scopes = { scope };

            token = authBuilder.AcquireTokenForClient(scopes).ExecuteAsync().Result;
            client = new HttpClient
            {
                BaseAddress = new Uri(_configuration["Configuration:BaseAddress"]),
                Timeout = new TimeSpan(0, 2, 0)
            };
            HttpRequestHeaders headers = client.DefaultRequestHeaders;
            headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        }

        public async Task<HttpResponseMessage> LogIn()
        {

            return await _userSetup.UserLogIn(client);

        }

        public async Task<HttpResponseMessage> SignUp(string firstName,string lastName,string email,string password)
        {
            return await _userSetup.UserSignUp(firstName,lastName,email,password);
        }

        public async Task<HttpResponseMessage> SentCode(string Id,string code)
        {
            return await _userSetup.VerificationCode(Id, code);
        }
        public async Task<HttpResponseMessage> ReSentCode(string Id)
        {
            return await _userSetup.ResendCode(Id);
        }

        public async Task<HttpResponseMessage> GetJobs(string empId)
        {
            var response = await _job.GetJobs(client,empId);
            return response;
        }
        public async Task<HttpResponseMessage> GetLocations(string jobId)
        {
            var response=await _jobLocation.GetLocations(client,jobId);
            return response;
        }

        public async Task<HttpResponseMessage> CheckIn(double longitude, double latitude,  string date ,string time,string status, string empId,string jobId)
        {
            var response = await _userActivity.CheckIn(client,longitude,latitude,date,time,status,empId,jobId);
            return response;
        }
        
        public async Task<HttpResponseMessage> CheckOut(double longitude, double latitude, string date, string time, string status, string empId,string jobId)
        {
            var response = await _userActivity.CheckOut(client, longitude, latitude, date, time, status, empId,jobId);
            return response;
        }

        public async Task<HttpResponseMessage> GetOrganizationDetails()
        {
            var response=await _organization.GetOrganizationDetails(client);
            return response;
        }

        public async Task<HttpResponseMessage> GetConfiguration()
        {
            var response = await _organization.GetConfiguration(client);
            return response;
        }
        public async Task<HttpResponseMessage> GetTimeSheetEntries()
        {
            HttpRequestMessage getRequest = new(
                 method: HttpMethod.Get,
                 requestUri: "dev_crewtimesheetentries");
            getRequest.Headers.Add("Prefer", "odata.include-annotations=\"*\"");
            var response = await client.SendAsync(request: getRequest);
            return response;
        }

    }
}
