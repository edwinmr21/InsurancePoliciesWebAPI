
namespace InsurancePoliciesRepository.Impl.Configuration
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public string ApiClientsURI { get; private set; }

        public string ApiPoliciesURI { get; private set; }

        public RepositoryConfiguration()
        {
            ApiClientsURI = "http://www.mocky.io/v2/5808862710000087232b75ac";
            ApiPoliciesURI = "http://www.mocky.io/v2/580891a4100000e8242b75c5";
        }
    }
}
