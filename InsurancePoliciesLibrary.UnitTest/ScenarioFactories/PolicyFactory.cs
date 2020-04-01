using InsurancePoliciesRepository.Contracts.Model;
using System;
using System.Collections.Generic;

namespace InsurancePoliciesLibrary.UnitTest.ScenarioFactories
{
    public static class PolicyFactory
    {
        public const string GENERIC_POLICY_EMAIL = "policy@policymail.com";
               
        public static InsuranceClientPolicyModel BuildPolicyWithSpecificClientId(string clientId)
        {
            var policy = BuildDefaultPolicy();
            policy.ClientId = clientId;

            return policy;
        }

        public static List<InsuranceClientPolicyModel> BuildDefaultPolicyCollection(int numberOfItemsToCreate)
        {
            var policies = new List<InsuranceClientPolicyModel>();

            for (int i = 0; i < numberOfItemsToCreate; i++)
            {
                policies.Add(BuildDefaultPolicy());
            }

            return policies;
        }

        public static InsuranceClientPolicyModel BuildPolicyWithSpecificPolicyNumber(string policyNumber)
        {
            var policy = BuildDefaultPolicy();
            policy.Id = policyNumber;

            return policy;
        }

        private static InsuranceClientPolicyModel BuildDefaultPolicy()
        {
            return new InsuranceClientPolicyModel
            {
                AmountInsured = 500000,
                ClientId = Guid.NewGuid().ToString(),
                Email = GENERIC_POLICY_EMAIL,
                Id = Guid.NewGuid().ToString(),
                InceptionDate = DateTime.Now.AddMonths(-3),
                InstallmentPayment = false
            };
        }
    }
}
