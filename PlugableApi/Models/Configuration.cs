using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public class Configuration
    {
        
            [JsonProperty("new_url")]
            public string Url { get; set; }

            [JsonProperty("new_password")]
            public string Password { get; set; }

            [JsonProperty("msdyn_name")]
            public string Name { get; set; }

            [JsonProperty("new_email")]
            public string Email { get; set; }
        
    }
}
