using InsurancePoliciesLibrary.Contracts.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.Contracts
{
    public interface ICompanyPoliciesService
    {
        Task<List<ClientPolicy>> GetPoliciesByClientId(string clientId);

        Task<ClientPolicy> GetPolicyByNumber(string policyNumber);
    }
}
