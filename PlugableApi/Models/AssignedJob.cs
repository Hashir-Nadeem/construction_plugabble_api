using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public class AssignedJob
    {
        [JsonProperty("imz_status")]
        public long AssignedJobStatus { get; set; }

        [JsonProperty("imz_assignedjobid")]
        public Guid UniqueAssignedjobid { get; set; }

        [JsonProperty("imz_name")]
        public string Name { get; set; }

        [JsonProperty("_imz_cr6fc_project_value")]
        public Guid JobId { get; set; }

        [JsonProperty("_imz_new_employee_value")]
        public Guid EmployeeId { get; set; }

        [JsonProperty("imz_cr6fc_Project")]
        public Job Job { get; set; }
    }
}
