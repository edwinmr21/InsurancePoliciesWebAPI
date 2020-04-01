using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Impl;
using InsurancePoliciesLibrary.UnitTest.ScenarioFactories;
using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System;
using System.Threading.Tasks;

namespace InsurancePoliciesLibrary.UnitTest.Given_Clients
{
    [TestClass]
    public class When_A_Client_Is_Requested
    {
        private static MockFactory _mockFactory;
        private static Mock<IClientsRepository> _clientsRepositoryMocked;
        private static ICompanyClientsService _sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _mockFactory = new MockFactory();
            _clientsRepositoryMocked = _mockFactory.CreateMock<IClientsRepository>();
            _sut = new CompanyClientsService(_clientsRepositoryMocked.MockObject);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _clientsRepositoryMocked.ClearExpectations();
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Then_A_ClientRequestedById()
        {
            var requestedClientId = Guid.NewGuid().ToString();
            var client = ClientFactory.BuildClientRepositoryModelWithSpecificId(requestedClientId);

            _clientsRepositoryMocked
                .Expects
                .One
                .Method(x => x.GetClientById(requestedClientId))
                .With(requestedClientId)
                .Will(Return.Value(Task.FromResult(client)));

            var clientResult = _sut.GetClientById(requestedClientId).Result;

            Assert.IsNotNull(clientResult);
            Assert.AreEqual(requestedClientId, clientResult.Id);
        }
       
        [TestMethod]
        [TestCategory("UnitTest")]
        public void Then_A_ClientRequestedByName()
        {
            var requestedName = "ClientName";
            var client = ClientFactory.BuildClientRepositoryModelWithSpecificName(requestedName);

            _clientsRepositoryMocked
                .Expects
                .One
                .Method(x => x.GetClientByName(requestedName))
                .With(requestedName)
                .Will(Return.Value(Task.FromResult(client)));

            var clientResult = _sut.GetClientByName(requestedName).Result;

            Assert.IsNotNull(clientResult);
            Assert.AreEqual(requestedName, clientResult.Name);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Then_A_ClientRequestedByEmail()
        {
            var requestedEmail = ClientFactory.GENERIC_CLIENT_EMAIL;
            var client = ClientFactory.BuildDefaultClient();

            _clientsRepositoryMocked
                .Expects
                .One
                .Method(x => x.GetClientByEmail(requestedEmail))
                .With(requestedEmail)
                .Will(Return.Value(Task.FromResult(client)));

            var clientResult = _sut.GetClientByEmail(requestedEmail).Result;

            Assert.IsNotNull(clientResult);
            Assert.AreEqual(requestedEmail, clientResult.Email);
        }
    }
}
