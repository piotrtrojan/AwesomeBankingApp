using AwesomeBankingApp.Bootstrap;
using AwesomeBankingApp.Loan.Validator;
using AwesomeBankingApp.Loan.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(GetSwaggerXmlCommentsPath());
            });

            // Register Loan Web Module - controllers, mappers, swagger, contracts.
            services.AddModule<LoanWebModule>((IConfigurationRoot)Configuration);
            // Reigster Loan Web Contracts Validator - validation for all requests in Loan Web Module
            services.AddModule<LoanWebContractsValidatorModule>();
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

        private static string GetSwaggerXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            var assemblyDocumentation = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name.Replace(".dll", ".xml");
            return System.IO.Path.Combine(app, assemblyDocumentation);   
        }
    }
}
