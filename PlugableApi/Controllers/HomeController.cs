using ApiBase;
using DynamicContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlugableApi.Logics;
using PlugableApi.Models;
using System;
using System.Web.Helpers;
using Dataverse;
using FO;
using Location = PlugableApi.Models.Location;

namespace PlugableApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        
        private readonly IApiBase _api;
        
        public HomeController(IContext context,IConfiguration configuration)
        {
            _api = context.createObj();

        }


        [HttpGet("Login")]
        public async Task<ActionResult> LogIn(string email,string password)
        {
            
            var response = await _api.LogIn();
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();
            var validEmployee=validUser.isValid(JsonConvert.DeserializeObject<List<Employee>>(content), email, password);
  
            if (validEmployee!=null)
            {
                return Ok(validEmployee);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("Signup")]
        public async Task<ActionResult>SignUp(string firstName,string lastName,string email, string password)
        {

            var response = await _api.SignUp(firstName,lastName,email, password);
            var body=response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                //returing the id of the record
                return Ok(body);

            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("Code")]
        public async Task<ActionResult>Code(string Id,string code)
        {
            var response = await _api.SentCode(Id, code);
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Recode")]
        public async Task<ActionResult> ReCode(string Id)
        {
            var response = await _api.ReSentCode(Id);
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Jobs")]
        public async Task<ActionResult> GetJobs(string id)
        {
            var response= await _api.GetJobs(id);
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();

            if (response.IsSuccessStatusCode)
            {

                var jobs_list = JsonConvert.DeserializeObject<List<AssignedJob>>(content);
                return Ok(jobs_list);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpPost("CheckIn")]
        public async Task<ActionResult>CheckIn(string empId,string jobId,double latitude,double longitude)
        {
            //duplicated code need to encapsulate somewhere
            //fetch all related locations
            var response = await _api.GetLocations(jobId);
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();
            var locations = JsonConvert.DeserializeObject<List<JobLocation>>(content);

            var status = checkDistance.distance(locations,latitude, longitude);

           if (status == true)
            {
                var res = await _api.CheckIn(longitude, latitude, DateTime.Now.ToString("dd/MM/yy"), DateTime.Now.ToString("HH:mm:ss"), "0", empId,jobId);
                if (Convert.ToInt32(response.StatusCode) == 204)
                {
                    if (response.IsSuccessStatusCode)
                    {

                        return Ok();

                    }
                }
            }
            return BadRequest("CheckIn Failed");

        }
        
        [HttpPost("CheckOut")]
        public async Task<ActionResult> CheckOut(double latitude, double longitude,string empId,string jobId)
        {
           
            var response = await _api.CheckIn(longitude, latitude, DateTime.Now.ToString("dd/MM/yy"), DateTime.Now.ToString("HH:mm:ss"), "0", empId,jobId);
            if (Convert.ToInt32(response.StatusCode) == 204)
            {
                if (response.IsSuccessStatusCode)
                {

                    return Ok();

                }
            }
            return BadRequest("CheckOut Failed");

        }

        [HttpGet("OrganizationDetails")]
        public async Task<ActionResult> OrganizationDetails()
        {
            var response = await _api.GetOrganizationDetails();
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();
            var organizationDetails = JsonConvert.DeserializeObject<List<OrganizationDetail>>(content);
            if (response.IsSuccessStatusCode)
            {
                return Ok(organizationDetails[0]);
            }
            return BadRequest();

        }
        [HttpGet("Configurations")]
        public async Task<ActionResult> Configuration(String email,String url,String password)
        {

            var response = await _api.GetConfiguration();
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();
            var validConfig = ValidConfiguration.isValid(JsonConvert.DeserializeObject<List<Configuration>>(content), email, url,password);

            if (validConfig == true)
            {

                return Ok(validConfig);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("TimeSheetEntries")]
        public async Task<ActionResult> TimeSheetEntries()
        {

            var response = await _api.GetTimeSheetEntries();
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();
            var validConfig = true;

            if (validConfig == true)
            {

                return Ok(validConfig);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("Locations")]
        public async Task<ActionResult> Locations(string jobId)
        {

            var response = await _api.GetLocations(jobId);
            var content = JObject.Parse(response.Content.ReadAsStringAsync().Result)["value"].ToString();
            if (Response.StatusCode==200)
            {
                var Locations = JsonConvert.DeserializeObject<List<JobLocation>>(content);
                return Ok(Locations);
            }
            else
            {
                return NotFound();
            }

        }


    }
}
