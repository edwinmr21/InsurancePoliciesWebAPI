using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Impl;
using InsurancePoliciesLibrary.UnitTest.ScenarioFactories;
using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.UnitTest.Given_Policies
{
    [TestClass]
    public class When_A_Policy_Is_Requested
    {
        private static MockFactory _mockFactory;
        private static ICompanyPoliciesService _sut;
        private static Mock<IPoliciesRepository> _policiesRepositoryMocked;
        private static Mock<ICompanyClientsService> _companyClientsService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _mockFactory = new MockFactory();
            _policiesRepositoryMocked = _mockFactory.CreateMock<IPoliciesRepository>();
            _companyClientsService = _mockFactory.CreateMock<ICompanyClientsService>();

            _sut = new CompanyPoliciesService(_companyClientsService.MockObject, _policiesRepositoryMocked.MockObject);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _policiesRepositoryMocked.ClearExpectations();
            _companyClientsService.ClearExpectations();
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Then_A_PolicyRequestedByNumber()
        {
            var requestedPolicyNumber = Guid.NewGuid().ToString();
            var policy = PolicyFactory.BuildPolicyWithSpecificPolicyNumber(requestedPolicyNumber);
            var policies = PolicyFactory.BuildDefaultPolicyCollection(2);
            policies.Add(policy);

            _policiesRepositoryMocked
                .Expects
                .One
                .Method(x => x.GetAllPolicies())
                .Will(Return.Value(Task.FromResult(policies)));

            var policyResult = _sut.GetPolicyByNumber(requestedPolicyNumber).Result;

            Assert.IsNotNull(policyResult);
            Assert.AreEqual(requestedPolicyNumber, policyResult.Id);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Then_A_PolicyRequestedByNumberNotFound()
        {
            var requestedPolicyNumber = Guid.NewGuid().ToString();
            var policy = PolicyFactory.BuildPolicyWithSpecificPolicyNumber(requestedPolicyNumber);
            var policies = PolicyFactory.BuildDefaultPolicyCollection(2);

            _policiesRepositoryMocked
                .Expects
                .One
                .Method(x => x.GetAllPolicies())
                .Will(Return.Value(Task.FromResult(policies)));

            var policyResult = _sut.GetPolicyByNumber(requestedPolicyNumber).Result;

            Assert.IsNull(policyResult);
        }
    }
}
