using InsurancePoliciesRepository.Contracts.Model;
using System;

namespace InsurancePoliciesLibrary.UnitTest.ScenarioFactories
{
    public static class ClientFactory
    {
        public const string GENERIC_CLIENT_EMAIL = "client@clientmail.com";
        public const string GENERIC_CLIENT_NAME = "Alias";
        public const string CLIENT_ROLE_AS_ADMIN = "admin";
        public const string CLIENT_ROLE_AS_USER = "user";

        public static InsuranceClientModel BuildClientRepositoryModelWithSpecificId(string id)
        {
            var client = BuildDefaultClient();
            client.Id = id;

            return client;
        }

        public static InsuranceClientModel BuildClientRepositoryModelWithSpecificName(string name)
        {
            var client = BuildDefaultClient();
            client.Name = name;

            return client;
        }

        public static InsuranceClientModel BuildDefaultClient()
        {
            return new InsuranceClientModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = GENERIC_CLIENT_NAME,
                Email = GENERIC_CLIENT_EMAIL,
                Role = CLIENT_ROLE_AS_USER
            };
        }
    }
}
