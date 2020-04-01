using InsurancePoliciesLibrary.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicies.WebApi.Tests.Controllers.ScenarioFactories.V1
{
    public static class ClientFactory
    {
        public const string GENERIC_CLIENT_EMAIL = "client@clientmail.com";
        public const string GENERIC_CLIENT_NAME = "Alias";
        public const string CLIENT_ROLE_AS_ADMIN = "admin";
        public const string CLIENT_ROLE_AS_USER = "user";

        public static Client BuildClientRepositoryModelWithSpecificId(string id)
        {
            var client = BuildDefaultClient();
            client.Id = id;

            return client;
        }

        private static Client BuildDefaultClient()
        {
            return new Client()
            {
                Id = Guid.NewGuid().ToString(),
                Name = GENERIC_CLIENT_NAME,
                Email = GENERIC_CLIENT_EMAIL,
                Role = CLIENT_ROLE_AS_USER
            };
        }
    }
}
