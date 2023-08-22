namespace Dataverse.Interfaces
{
    public interface IUserActivity
    {
        Task<HttpResponseMessage> CheckIn(HttpClient client, double longitude, double latitude, string date, string time, string status, string empId ,string jobId);
        Task<HttpResponseMessage> CheckOut(HttpClient client, double longitude, double latitude, string date, string time, string status, string empId, string jobId);
    }
}