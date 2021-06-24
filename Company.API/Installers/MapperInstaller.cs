using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.API
{
    class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            MapperConfiguration mapperConfiguration = MapperStart.Build();
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
