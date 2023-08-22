using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public partial class PrivacyPolicy
    {
        [JsonProperty("new_policyid")]
        public Guid PolicyUniqueId { get; set; }

        [JsonProperty("statuscode")]
        public long Statuscode { get; set; }

        [JsonProperty("new_policy")]
        public string Policy { get; set; }

        [JsonProperty("new_name")]
        public string Name { get; set; }
    }
}
