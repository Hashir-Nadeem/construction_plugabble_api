namespace Dataverse.Interfaces
{
    public interface IOrganization
    {
        Task<HttpResponseMessage> GetConfiguration(HttpClient client);
        Task<HttpResponseMessage> GetOrganizationDetails(HttpClient client);
    }
}