using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public class Default
    {
        [JsonProperty("imz_id")]
        public string Id { get; set; }

        [JsonProperty("imz_radius")]
        public long Radius { get; set; }

        [JsonProperty("imz_constructionfeaturesid")]
        public Guid UniqueId { get; set; }
    }
}
