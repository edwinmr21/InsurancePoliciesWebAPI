using InsurancePolicies.WebApi.Controllers.V1;
using InsurancePolicies.WebApi.Tests.Controllers.ScenarioFactories.V1;
using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Contracts.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace InsurancePolicies.WebApi.Tests.Controllers.V1
{
    [TestClass]
    public class ClientControllerTest
    {
        private static MockFactory _mockFactory;
        private static Mock<ICompanyClientsService> _clientsServiceMocked;
        private static Mock<ICompanyClientPolicyFacadeService> _clientsPolicyServiceMocked;
        private static ClientsController _sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _mockFactory = new MockFactory();
            _clientsServiceMocked = _mockFactory.CreateMock<ICompanyClientsService>();
            _clientsPolicyServiceMocked = _mockFactory.CreateMock<ICompanyClientPolicyFacadeService>();

            _sut = new ClientsController(_clientsServiceMocked.MockObject, _clientsPolicyServiceMocked.MockObject);
        }

        [TestMethod]
        public async Task GetClientById()
        {
            var requestedClientId = Guid.NewGuid().ToString();
            var client = ClientFactory.BuildClientRepositoryModelWithSpecificId(requestedClientId);

            _clientsServiceMocked
                .Expects
                .One
                .Method(x => x.GetClientById(requestedClientId))
                .With(requestedClientId)
                .Will(Return.Value(Task.FromResult(client)));

            var result = await _sut.GetClientById(requestedClientId) as OkNegotiatedContentResult<Client>;

            Assert.IsNotNull(result);
            Assert.AreEqual(requestedClientId, result.Content.Id);
        }
    }
}
