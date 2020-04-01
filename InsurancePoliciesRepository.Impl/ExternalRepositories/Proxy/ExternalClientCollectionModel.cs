using Newtonsoft.Json;
using System.Collections.Generic;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy
{
    public class ExternalClientCollectionModel
    {
        [JsonProperty("clients")]
        public List<ExternalClientModel> Clients { get; set; }

        public ExternalClientCollectionModel()
        {
            Clients = new List<ExternalClientModel>();
        }
    }
}
