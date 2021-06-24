using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.API
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env);
    }
}
