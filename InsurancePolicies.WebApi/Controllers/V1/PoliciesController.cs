using InsurancePoliciesLibrary.Contracts;
using Microsoft.Web.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InsurancePolicies.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/policies")]
    public class PoliciesController : ApiController
    {
        private readonly ICompanyClientPolicyFacadeService _companyClientPolicyFacadeService;

        public PoliciesController(ICompanyClientPolicyFacadeService companyClientPolicyFacadeService)
        {
            _companyClientPolicyFacadeService = companyClientPolicyFacadeService;
        }

        [HttpGet]
        [Route("GetPoliciesByClientName/{clientName}")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetPoliciesByClientName(string clientName)
        {
            var policiesClient = await _companyClientPolicyFacadeService.GetPoliciesByClientName(clientName);

            if (policiesClient == null)
            {
                return NotFound();
            }

            return Ok(policiesClient);
        }
    }
}
