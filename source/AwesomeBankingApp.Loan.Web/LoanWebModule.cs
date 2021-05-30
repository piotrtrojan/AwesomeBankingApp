using AwesomeBankingApp.Bootstrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AwesomeBankingApp.Loan.Web
{
    /// <summary>
    /// Module, containing endpoints and contracts (requests, responses) for Loans handling.
    /// </summary>
    public class LoanWebModule : ModuleBootstrap
    {
        /// <summary>
        /// Instantiates LoanWebModule
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public LoanWebModule(IServiceCollection serviceCollection, IConfiguration configuration)
            : base(serviceCollection, configuration)
        {
            RegisterConfiguration<LoanWebModuleConfiguration>(GetType().Name);
        }

        /// <summary>
        /// Registers LoanWebModule dependencies - LoanModule, automapper, swagger and controllers from LoanWebModule.
        /// </summary>
        public override void RegisterDependencies()
        {
            RegisterDependenciesGuard();
            
            _serviceCollection.AddModule<LoanModule>((IConfigurationRoot)_configuration);
            _serviceCollection.AddAutoMapper(new[] { typeof(LoanAutomapperProfile) });
            _serviceCollection.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(GetSwaggerXmlCommentsPath());
            });
            _serviceCollection.AddMvcCore()
                .AddApplicationPart(Assembly.GetExecutingAssembly())
                .AddControllersAsServices();
            
        }
        private static string GetSwaggerXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            var assemblyDocumentation = Assembly.GetExecutingAssembly().ManifestModule.Name.Replace(".dll", ".xml");
            return System.IO.Path.Combine(app, assemblyDocumentation);
        }

    }
}
