using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Contracts.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.Impl
{
    public class CompanyClientPolicyFacadeService : ICompanyClientPolicyFacadeService
    {
        private readonly ICompanyClientsService _companyClientsService;
        private readonly ICompanyPoliciesService _companyPoliciesService;

        public CompanyClientPolicyFacadeService(ICompanyPoliciesService companyPoliciesService, ICompanyClientsService companyClientsService)
        {
            _companyClientsService = companyClientsService;
            _companyPoliciesService = companyPoliciesService;
        }

        public async Task<List<ClientPolicy>> GetPoliciesByClientName(string clientName)
        {
            var client = await _companyClientsService.GetClientByName(clientName);

            if (client != null)
            {
                return await _companyPoliciesService.GetPoliciesByClientId(client.Id);
            }
            else
            {
                return new List<ClientPolicy>();
            }
        }

        public async Task<Client> GetClientByPolicyNumber(string policyNumber)
        {
            var policy = await _companyPoliciesService.GetPolicyByNumber(policyNumber);

            return await _companyClientsService.GetClientById(policy.ClientId);
        }
    }
}
