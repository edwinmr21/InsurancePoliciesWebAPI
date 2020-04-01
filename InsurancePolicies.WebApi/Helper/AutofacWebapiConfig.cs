using Autofac;
using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi;
using InsurancePoliciesLibrary.Impl;
using InsurancePoliciesLibrary.Contracts;
using InsurancePoliciesRepository.Impl.ExternalRepositories;
using InsurancePoliciesRepository.Contracts.ExternalRepositories;
using InsurancePoliciesRepository.Impl.ExternalRepositories.Proxy;
using InsurancePoliciesRepository.Impl.Configuration;

namespace InsurancePolicies.WebApi.Helper
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CompanyClientsService>().As<ICompanyClientsService>();
            builder.RegisterType<CompanyPoliciesService>().As<ICompanyPoliciesService>();

            
            builder.RegisterType<RepositoryConfiguration>().As<IRepositoryConfiguration>();
            builder.RegisterType<ExternalAPIProxy>().As<IExternalAPIProxy>();
            builder.RegisterType<ClientsRepository>().As<IClientsRepository>();
            builder.RegisterType<PoliciesRepository>().As<IPoliciesRepository>();
            builder.RegisterType<CompanyClientPolicyFacadeService>().As<ICompanyClientPolicyFacadeService>();       

            //builder.RegisterType<DBCustomerEntities>().As<DbContext>().InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}