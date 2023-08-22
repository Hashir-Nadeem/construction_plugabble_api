using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlugableApi.Models
{
    public class Employee
    {

        [JsonProperty("new_email")]
        public string Email { get; set; }


        [JsonProperty("new_employeeid")]
        public string UniqueId { get; set; }

        [JsonProperty("new_empid")]
        public string Id { get; set; }

        [JsonProperty]
        public string new_password { get; set; }

        [JsonProperty("_imz_manager_value")]
        public string ManagerUniqueId { get; set; }

        [JsonProperty("new_active")]
        public bool Active { get; set; }


        [JsonProperty("new_approved")]
        public bool Approved { get; set; }
    }
}
