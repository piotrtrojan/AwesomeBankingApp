using AwesomeBankingApp.Api.Validator;
using AwesomeBankingApp.Api.WebContracts.Loan;
using AwesomeBankingApp.Bootstrap;
using AwesomeBankingApp.Loan;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeBankingApp.Api
{
    /// <summary>
    /// Responsible for prepraing .NET Core WebApi pipeline, registering services and configurations.
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Instantiates Startup.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        /// <summary>
        /// // This method gets called by the runtime. Adds services to the container, registers modules.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddControllers()
                // Disable default net core error pages, use FluentValidation errors.
                .ConfigureApiBehaviorOptions(opt => opt.SuppressMapClientErrors = true); 

            services.AddSwaggerGen(c =>
            {
                GetSwaggerXmlCommentsPath().ToList().ForEach(q => c.IncludeXmlComments(q));
            });

            // Register automapper profile
            services.AddAutoMapper(new[] { typeof(AutomapperProfile) });

            services.AddModule<LoanModule>((IConfigurationRoot)Configuration);
            services.AddModule<ApiWebContractsValidatorModule>();
        }

        /// <summary>
        /// This method gets called by the runtime. It configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AwesomeBankingApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEnumerable<string> GetSwaggerXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            var assemblyDocumentation = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name.Replace(".dll", ".xml");
            yield return System.IO.Path.Combine(app, assemblyDocumentation);
            var contractsDocumentation = System.Reflection.Assembly.GetAssembly(typeof(LoanCalculationRequest)).ManifestModule.Name.Replace(".dll", ".xml");
            yield return System.IO.Path.Combine(app, contractsDocumentation);
        }
    }
}
