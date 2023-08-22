namespace Dataverse.Interfaces
{
    public interface IUserSetup
    {
        Task<HttpResponseMessage> ResendCode(string Id);
        Task<HttpResponseMessage> UserLogIn(HttpClient client);
        Task<HttpResponseMessage> UserSignUp(string firstName, string lastName, string email, string password);
        Task<HttpResponseMessage> VerificationCode(string Id, string code);
    }
}