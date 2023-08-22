namespace Dataverse.Interfaces
{
    public interface IJob
    {
        Task<HttpResponseMessage> GetJobs(HttpClient client, string empId);
    }
}