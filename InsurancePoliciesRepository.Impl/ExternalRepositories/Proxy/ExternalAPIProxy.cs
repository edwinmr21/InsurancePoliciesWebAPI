using InsurancePoliciesRepository.Impl.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy
{
    public class ExternalAPIProxy : IExternalAPIProxy
    {
        private HttpClient _httpClient;
        private readonly IRepositoryConfiguration _repositoryConfiguration;

        public ExternalAPIProxy(IRepositoryConfiguration repositoryConfiguration)
        {
            _httpClient = new HttpClient();
            _repositoryConfiguration = repositoryConfiguration;
        }

        public async Task<List<ExternalClientModel>> GetAllClients()
        {
            var externalClientsCollection = new ExternalClientCollectionModel();

            try
            {
                var response = await _httpClient.GetAsync(_repositoryConfiguration.ApiClientsURI).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    externalClientsCollection = JsonConvert.DeserializeObject<ExternalClientCollectionModel>(jsonResponse);
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError("Error getting clients data from the external web service '{0}'. Exeption => {1}.",
                                _repositoryConfiguration.ApiClientsURI,
                                exception.ToString());
                throw;
            }

            return externalClientsCollection.Clients;
        }

        public async Task<List<ExternalPolicyModel>> GetAllPolicies()
        {
            var externalPoliciesCollection = new ExternalPoliciesCollectionModel();

            try
            {
                var response = await _httpClient.GetAsync(_repositoryConfiguration.ApiPoliciesURI).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    externalPoliciesCollection = JsonConvert.DeserializeObject<ExternalPoliciesCollectionModel>(jsonResponse);
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError("Error getting policies data from the external web service '{0}'. Exeption => {1}.",
                                _repositoryConfiguration.ApiPoliciesURI,
                                exception.ToString());
                throw;
            }

            return externalPoliciesCollection.Policies;
        }
    }
}
