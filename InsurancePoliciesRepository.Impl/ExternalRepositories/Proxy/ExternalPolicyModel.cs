using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy
{
    public class ExternalPolicyModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("amountInsured")]
        public decimal AmountInsured { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("inceptionDate")]
        public DateTime InceptionDate { get; set; }
        [JsonProperty("installmentPayment")]
        public bool InstallmentPayment { get; set; }
    }
}
