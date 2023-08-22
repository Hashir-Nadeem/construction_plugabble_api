namespace Dataverse.Interfaces
{
    public interface ILocation
    {
        Task<HttpResponseMessage> GetLocations(HttpClient client, string jobId);
    }
}