using AwesomeBankingApp.Authorization.Filters;
using AwesomeBankingApp.Authorization.Interfaces;
using AwesomeBankingApp.Authorization.Services;
using AwesomeBankingApp.Bootstrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AwesomeBankingApp.Authorization
{
    public class AuthorizationModule : ModuleBootstrap
    {
        public AuthorizationModule(IServiceCollection serviceCollection, IConfiguration configuration) 
            : base(serviceCollection, configuration)
        {
            RegisterConfiguration<AuthorizationModuleConfiguration>(GetType().Name);
        }

        public override void RegisterDependencies()
        {
            _serviceCollection.AddTransient<IUserService, UserService>();
            _serviceCollection.AddMvcCore(q => q.Filters.Add(new BasicAuthorizationFilter()));
            _serviceCollection.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme. " +
                    "For demo purposes, use admin/admin credentials."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });
        }
    }
}
