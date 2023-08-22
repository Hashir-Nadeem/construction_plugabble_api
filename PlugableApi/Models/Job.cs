using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public class Job
    {
        [JsonProperty("imz_stage")]
        public long JobStage { get; set; }

        [JsonProperty("cr6fc_startdate")]
        public DateTimeOffset Startdate { get; set; }

        [JsonProperty("imz_plannedenddate")]
        public DateTimeOffset Plannedenddate { get; set; }

        [JsonProperty("cr6fc_enddate")]
        public DateTimeOffset Enddate { get; set; }

        [JsonProperty("imz_plannedstartdate")]
        public DateTimeOffset Plannedstartdate { get; set; }

        [JsonProperty("cr6fc_projectid")]
        public Guid UniqueProjectid { get; set; }

        [JsonProperty("_imz_employee_value")]
        public Guid ProjectManagerId { get; set; }

        [JsonProperty("cr6fc_name")]
        public string JobName { get; set; }
    }

}
