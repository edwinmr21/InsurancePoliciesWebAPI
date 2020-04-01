using InsurancePoliciesLibrary.Contracts;
using Microsoft.Web.Http;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InsurancePolicies.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/clients")]
    public class ClientsController : ApiController
    {
        private const string TRACE_ERROR_MESSAGE = "Error trying get a client by {0}: '{1}'. Exception => {2}";

        private readonly ICompanyClientsService _companyClientsService;
        private readonly ICompanyClientPolicyFacadeService _companyClientPolicyFacadeService;

        public ClientsController(ICompanyClientsService companyClientsService, ICompanyClientPolicyFacadeService companyClientPolicyFacadeService)
        {
            _companyClientsService = companyClientsService;
            _companyClientPolicyFacadeService = companyClientPolicyFacadeService;
        }

        [HttpGet]
        [Route("GetClientById/{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<IHttpActionResult> GetClientById(string id)
        {
            try
            {
                var userInfo = await _companyClientsService.GetClientById(id);

                if (userInfo == null)
                {
                    return NotFound();
                }

                return Ok(userInfo);
            }
            catch (Exception exception)
            {
                return ManageExceptionAndBuildResult(nameof(id), id, exception);
            }
        }

        [HttpGet]
        [Route("GetClientByName/{name}")]
        [Authorize(Roles = "user, admin")]
        public async Task<IHttpActionResult> GetClientByName(string name)
        {
            try
            {
                var userInfo = await _companyClientsService.GetClientByName(name);

                if (userInfo == null)
                {
                    return NotFound();
                }

                return Ok(userInfo);
            }
            catch (Exception exception)
            {
                return ManageExceptionAndBuildResult(nameof(name), name, exception);
            }
        }

        [HttpGet]
        [Route("GetClientByPolicyNumber/{policyNumber}")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetClientByPolicyNumber(string policyNumber)
        {
            try
            {
                var userInfo = await _companyClientPolicyFacadeService.GetClientByPolicyNumber(policyNumber);

                if (userInfo == null)
                {
                    return NotFound();
                }

                return Ok(userInfo);
            }
            catch (Exception exception)
            {
                return ManageExceptionAndBuildResult(nameof(policyNumber), policyNumber, exception);
            }
        }

        private IHttpActionResult ManageExceptionAndBuildResult(string paramName, string param, Exception exeption)
        {
            Trace.TraceError(TRACE_ERROR_MESSAGE, paramName, param, exeption.ToString());
            string erroMessage = BuildClientErrorMessage(paramName, param);

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, erroMessage));
        }

        private static string BuildClientErrorMessage(string propertyName, string id)
        {
            return string.Format(@"Internal error trying get the client looking by {0}: {1}. 
                                 Please try again later or contact with the support technical department.", 
                                 propertyName,
                                 id);
        }
    }
}
