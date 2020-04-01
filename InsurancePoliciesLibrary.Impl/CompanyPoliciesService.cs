using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Contracts.DTOs;
using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using InsurancePoliciesRepository.Contracts.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.Impl
{
    public class CompanyPoliciesService : ICompanyPoliciesService
    {
        private readonly ICompanyClientsService _companyClientsService;
        private readonly IPoliciesRepository _policiesRepository;

        public CompanyPoliciesService(ICompanyClientsService companyClientsService, IPoliciesRepository policiesRepository)
        {
            _companyClientsService = companyClientsService;
            _policiesRepository = policiesRepository;
        }

        public async Task<List<ClientPolicy>> GetPoliciesByClientId(string clientId)
        {
            var allPolicies = await _policiesRepository.GetAllPolicies();

            if (allPolicies != null && allPolicies.Any())
            {
                var clientPolicies = allPolicies.Where(x => x.ClientId.Equals(clientId)).ToList();

                return MapToPoliciesDTO(clientPolicies);
            }
            else
            {
                return new List<ClientPolicy>();
            }
        }

        public async Task<ClientPolicy> GetPolicyByNumber(string policyNumber)
        {
            var allPolicies = await _policiesRepository.GetAllPolicies();
            var policy = allPolicies.FirstOrDefault(x => x.Id.Equals(policyNumber));

            return policy != null ? MapToPolicyDTO(policy) : null;
        }

        private List<ClientPolicy> MapToPoliciesDTO(List<InsuranceClientPolicyModel> allPolicies)
        {
            var policiesMapped = new List<ClientPolicy>();

            foreach (var policy in allPolicies)
            {
                policiesMapped.Add(MapToPolicyDTO(policy));
            }

            return policiesMapped;
        }

        private ClientPolicy MapToPolicyDTO(InsuranceClientPolicyModel policy)
        {
            return new ClientPolicy
            {
                AmountInsured = policy.AmountInsured,
                ClientId = policy.ClientId,
                Email = policy.Email,
                Id = policy.Id,
                InceptionDate = policy.InceptionDate,
                InstallmentPayment = policy.InstallmentPayment
            };
        }
    }
}
