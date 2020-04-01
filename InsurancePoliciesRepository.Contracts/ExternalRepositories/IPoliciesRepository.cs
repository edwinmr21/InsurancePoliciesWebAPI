using InsurancePoliciesRepository.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePoliciesRepository.Contracts.ExternalRepositories
{
    public interface IPoliciesRepository
    {
        Task<List<InsuranceClientPolicyModel>> GetAllPolicies();
    }
}
