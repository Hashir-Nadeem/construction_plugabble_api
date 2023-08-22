using Microsoft.AspNetCore.Server.IISIntegration;
using Newtonsoft.Json;

namespace PlugableApi.Models
{
    public class Location
    {
        [JsonProperty("new_state")]
        public string State { get; set; }

        [JsonProperty("new_city")]
        public string City { get; set; }

        [JsonProperty("new_latitude")]
        public object Latitude { get; set; }

        [JsonProperty("new_zipcode")]
        public long Zipcode { get; set; }

        [JsonProperty("new_address")]
        public object Address { get; set; }

        [JsonProperty("new_joblocationid")]
        public Guid UniqueId { get; set; }

        [JsonProperty("new_street")]
        public string Street { get; set; }

        [JsonProperty("new_longitude")]
        public object Longitude { get; set; }

        [JsonProperty("_imz_defaults_value")]
        public Guid DefaultsId { get; set; }

        [JsonProperty("new_locationid")]
        public string Id { get; set; }

        [JsonProperty("new_locationname")]
        public string Locationname { get; set; }

        [JsonProperty("new_country")]
        public string Country { get; set; }

        [JsonProperty("imz_Defaults")]
        public Default Defaults { get; set; }
    }
}
