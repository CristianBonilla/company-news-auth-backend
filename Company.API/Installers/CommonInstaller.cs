using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Company.API
{
    class CommonInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration _)
        {
            services.AddControllers()
                .AddNewtonsoftJson(JsonSerializer);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company.API", Version = "v1" });
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
