using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using InsurancePoliciesRepository.Contracts.Model;
using InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly IExternalAPIProxy _externalAPIProxy;

        public ClientsRepository(IExternalAPIProxy externalAPIProxy)
        {
            _externalAPIProxy = externalAPIProxy;
        }

        public async Task<InsuranceClientModel> GetClientById(string id)
        {
            var allClients = await GetAllClients();
            var client = allClients.FirstOrDefault(x => x.Id.Equals(id));

            return MapToClientModelOrNull(client);
        }

        public async Task<InsuranceClientModel> GetClientByName(string name)
        {
            var allClients = await GetAllClients();
            var client = allClients.FirstOrDefault(x => x.Name.Equals(name));

            return MapToClientModelOrNull(client);
        }

        public async Task<InsuranceClientModel> GetClientByEmail(string email)
        {
            var allClients = await GetAllClients();
            var client = allClients.FirstOrDefault(x => x.Email.Equals(email));

            return MapToClientModelOrNull(client);
        }

        private async Task<List<ExternalClientModel>> GetAllClients()
        {
            return await _externalAPIProxy.GetAllClients();
        }

        private static InsuranceClientModel MapToClientModelOrNull(ExternalClientModel client)
        {
            InsuranceClientModel mappedClient = null;

            if (client != null)
            {
                mappedClient = new InsuranceClientModel
                {
                    Email = client.Email,
                    Id = client.Id,
                    Name = client.Name,
                    Role = client.Role
                }; 
            }

            return mappedClient;
        }
    }
}
