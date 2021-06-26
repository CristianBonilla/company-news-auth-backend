using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.API
{
    class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
            services.Configure<SwaggerOptions>(swaggerSection);
            SwaggerOptions swagger = swaggerSection.Get<SwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Title = "Company News Auth API",
                    Version = "v1",
                    Description = "Grant permissions depending on the role of the user and list the news available from the company with security",
                    Contact = swagger.Contact
                });
                options.AddSecurityDefinition(CommonValues.Bearer, new()
                {
                    Description = "JWT Authentication header using the bearer scheme",
                    Name = "Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = CommonValues.Bearer,
                    BearerFormat = "JWT"
                });
                OpenApiSecurityScheme apiSecurity = new()
                {
                    Reference = new OpenApiReference
                    {
                        Id = CommonValues.Bearer,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { apiSecurity, new List<string>() } });
            });
        }
    }
}
