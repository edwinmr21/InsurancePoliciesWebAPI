using InsurancePoliciesRepository.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePoliciesRepository.Contracts.ExternalRepositories
{
    public interface IClientsRepository
    {
        Task<InsuranceClientModel> GetClientById(string id);

        Task<InsuranceClientModel> GetClientByName(string name);

        Task<InsuranceClientModel> GetClientByEmail(string email);
    }
}
