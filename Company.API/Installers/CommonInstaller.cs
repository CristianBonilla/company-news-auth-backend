using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Company.API
{
    class CommonInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers()
                .AddNewtonsoftJson(JsonSerializer);
            services.AddCors(options =>
            {
                options.AddPolicy(CommonValues.AllowOrigins, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST", "PUT", "DELETE");
                });
            });

            IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
            services.Configure<SwaggerOptions>(swaggerSection);
            SwaggerOptions swagger = swaggerSection.Get<SwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Title = "Company.API",
                    Version = "v1",
                    Description = "Grant permissions depending on the role of the user and list the news available from the company with security",
                    Contact = swagger.Contact
                });
                options.AddSecurityDefinition(CommonValues.Bearer, new()
                {
                    Description = "JWT Authentication header using the bearer scheme",
                    Name = "Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
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

        private void JsonSerializer(MvcNewtonsoftJsonOptions options)
        {
            JsonSerializerSettings settings = options.SerializerSettings;
            settings.Converters.Add(new StringEnumConverter());
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.None;
        }
    }
}
