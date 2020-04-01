using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using InsurancePoliciesRepository.Contracts.Model;
using InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories
{
    public class PoliciesRepository : IPoliciesRepository
    {
        private readonly IExternalAPIProxy _externalAPIProxy;

        public PoliciesRepository(IExternalAPIProxy externalAPIProxy)
        {
            _externalAPIProxy = externalAPIProxy;
        }

        public async Task<List<InsuranceClientPolicyModel>> GetAllPolicies()
        {
            var allPolicies = await _externalAPIProxy.GetAllPolicies();

            return allPolicies.Any() ? MapToPoliciesModel(allPolicies) : new List<InsuranceClientPolicyModel>();
        }

        private List<InsuranceClientPolicyModel> MapToPoliciesModel(List<ExternalPolicyModel> allPolicies)
        {
            var policiesModelMapped = new List<InsuranceClientPolicyModel>();

            foreach (var policy in allPolicies)
            {
                policiesModelMapped.Add(new InsuranceClientPolicyModel
                {
                    AmountInsured = policy.AmountInsured,
                    ClientId = policy.ClientId,
                    Email = policy.Email,
                    Id = policy.Id,
                    InceptionDate = policy.InceptionDate,
                    InstallmentPayment = policy.InstallmentPayment
                });
            }

            return policiesModelMapped;
        }
    }
}
