using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlugableApi.Models
{
    public class OrganizationDetail
    {
        [JsonProperty("new_logoid")]
        public object Logoid { get; set; }

        [JsonProperty("new_logo_url")]
        public object LogoUrl { get; set; }

        [JsonProperty("new_companyinfoid")]
        public Guid OrganizationDetailsUniqueId { get; set; }

        [JsonProperty("new_logo_timestamp")]
        public string LogoTimestamp { get; set; }

        [JsonProperty("new_webaddress")]
        public string Webaddress { get; set; }

        [JsonProperty("new_status")]
        public bool Status { get; set; }

        [JsonProperty("new_logo")]
        public object Logo { get; set; }

        [JsonProperty("_new_policy_value")]
        public Guid PolicyUniqueId { get; set; }

        [JsonProperty("statuscode")]
        public long Statuscode { get; set; }

        [JsonProperty("new_name")]
        public string Name { get; set; }

        [JsonProperty("new_emailaddress")]
        public string Emailaddress { get; set; }

        [JsonProperty("new_Policy")]
        public PrivacyPolicy NewPolicy { get; set; }
    }

}
