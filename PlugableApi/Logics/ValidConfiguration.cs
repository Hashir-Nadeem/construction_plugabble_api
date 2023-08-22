using Dataverse;
using PlugableApi.Models;

namespace PlugableApi.Logics
{
    public class ValidConfiguration
    {
        public static bool isValid(List<Configuration>configurations,string email, string url,string password)
        {
            foreach (var config in configurations)
            {
                if (config.Email == email && config.Password == password && config.Url==url)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
