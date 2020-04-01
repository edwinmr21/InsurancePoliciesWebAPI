using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesLibrary.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace InsurancePolicies.WebApi.Security
{
    public class ApiAuthorizationAttribute : AuthorizeAttribute
    {
        private const string AUTH_SCHEMA_NAME = "Basic";
        private readonly ICompanyClientsService _companyClientsService;

        public ApiAuthorizationAttribute(ICompanyClientsService companyClientsService)
        {
            _companyClientsService = companyClientsService;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool isAuthorized = false;

            if (IsValidContext(actionContext))
            {
                string[] userCredentials = GetUserCredentials(actionContext);
                var userName = userCredentials[0];
                var userPassword = userCredentials[1];
                var clientUser = Task.Run(() => _companyClientsService.GetClientByEmail(userName)).Result;

                if (ValidPassword(userPassword, clientUser))
                {
                    actionContext.RequestContext.Principal = BuildPrincipalWithUserData(clientUser);
                    isAuthorized = true;
                }
            }

            return isAuthorized;
        }

        private bool ValidPassword(string userPassword, Client clientUser)
        {
            return !string.IsNullOrEmpty(userPassword) && userPassword.Equals(clientUser.Id, StringComparison.OrdinalIgnoreCase);
        }

        private static ClaimsPrincipal BuildPrincipalWithUserData(Client clientUser)
        {
            var claimsCollection = BuildUserClaims(clientUser);
            var identity = new ClaimsIdentity(claimsCollection, AUTH_SCHEMA_NAME);

            return new ClaimsPrincipal(new[] { identity });
        }

        private static List<Claim> BuildUserClaims(Client clientUser)
        {
            return new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, clientUser.Name),
                    new Claim(ClaimTypes.Role, clientUser.Role),
                };
        }

        private Client GetClientUserData(HttpActionContext actionContext)
        {
            string[] userCredentials = GetUserCredentials(actionContext);
            var userName = userCredentials[0];
            var userPassword = userCredentials[1];

            return Task.Run(() => _companyClientsService.GetClientByName(userName)).Result;
        }

        private static string[] GetUserCredentials(HttpActionContext actionContext)
        {
            var data = Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter.ToString());
            var authParam = ASCIIEncoding.ASCII.GetString(data);

            return authParam.Split(':');
        }

        private static bool IsValidContext(HttpActionContext actionContext)
        {
            return actionContext.Request.Headers.Authorization != null
                && actionContext.Request.Headers.Authorization.Scheme.Equals(AUTH_SCHEMA_NAME, StringComparison.OrdinalIgnoreCase);
        }
    }
}