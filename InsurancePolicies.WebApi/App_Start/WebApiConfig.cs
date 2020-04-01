using InsurancePoliciesLibrary.Contracts;
using Microsoft.Web.Http.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace InsurancePolicies.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.AddApiVersioning();
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) }
            };

            config.MapHttpAttributeRoutes(constraintResolver);
            var clientService = config.DependencyResolver.GetService(typeof(ICompanyClientsService)) as ICompanyClientsService;
            config.Filters.Add(new Security.ApiAuthorizationAttribute(clientService));
          

        }

        
    }
}
