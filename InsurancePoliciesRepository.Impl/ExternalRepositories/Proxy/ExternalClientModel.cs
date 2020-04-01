using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy
{
    public class ExternalClientModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
