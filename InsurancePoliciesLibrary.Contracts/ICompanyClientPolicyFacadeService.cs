using InsurancePoliciesLibrary.Contracts.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.Contracts
{
    public interface ICompanyClientPolicyFacadeService
    {
        Task<List<ClientPolicy>> GetPoliciesByClientName(string clientName);

        Task<Client> GetClientByPolicyNumber(string policyNumber);
    }
}
