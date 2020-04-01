using InsurancePoliciesRepository.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy
{
    public interface IExternalAPIProxy
    {
        Task<List<ExternalClientModel>> GetAllClients();

        Task<List<ExternalPolicyModel>> GetAllPolicies();
    }
}
