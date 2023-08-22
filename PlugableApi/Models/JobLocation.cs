using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public class JobLocation
    {
        [JsonProperty("_imz_new_joblocation_value")]
        public Guid LocationId { get; set; }

        [JsonProperty("_imz_cr6fc_project_value")]
        public Guid JobId { get; set; }

        [JsonProperty("imz_name")]
        public string Name { get; set; }

        [JsonProperty("imz_assignedlocationid")]
        public Guid UniqueId { get; set; }

        [JsonProperty("imz_new_JobLocation")]
        public Location Location { get; set; }
    }
}
