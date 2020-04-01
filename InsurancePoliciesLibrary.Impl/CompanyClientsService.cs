using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Contracts.DTOs;
using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using InsurancePoliciesRepository.Contracts.Model;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.Impl
{
    public class CompanyClientsService : ICompanyClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public CompanyClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<Client> GetClientById(string id)
        {
            var client = await _clientsRepository.GetClientById(id);

            return MapToClientDtoOrNull(client);
        }

        public async Task<Client> GetClientByName(string name)
        {
            var client = await _clientsRepository.GetClientByName(name);

            return MapToClientDtoOrNull(client);
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            var client = await _clientsRepository.GetClientByEmail(email);

            return MapToClientDtoOrNull(client);
        }

        private Client MapToClientDtoOrNull(InsuranceClientModel client)
        {
            Client mappedClient = null;

            if (client != null)
            {
                mappedClient = new Client
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
