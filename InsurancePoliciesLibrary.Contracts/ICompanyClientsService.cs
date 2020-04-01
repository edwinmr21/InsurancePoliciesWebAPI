using InsurancePoliciesLibrary.Contracts.DTOs;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.Contracts
{
    public interface ICompanyClientsService
    {
        Task<Client> GetClientById(string id);

        Task<Client> GetClientByName(string name);

        Task<Client> GetClientByEmail(string email);
    }
}
