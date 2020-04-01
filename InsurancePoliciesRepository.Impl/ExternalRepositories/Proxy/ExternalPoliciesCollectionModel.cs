using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy
{
    public class ExternalPoliciesCollectionModel
    {
        [JsonProperty("policies")]
        public List<ExternalPolicyModel> Policies { get; set; }

        public ExternalPoliciesCollectionModel()
        {
            Policies = new List<ExternalPolicyModel>();
        }
    }
}
