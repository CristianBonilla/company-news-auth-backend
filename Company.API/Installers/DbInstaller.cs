using Company.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.API
{
    class DbInstaller : IInstaller
    {
        const string CompanyAuthConnection = nameof(CompanyAuthConnection);

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(CompanyAuthConnection);
            DataDirectoryConfig.SetDataDirectoryPath(ref connectionString);

            services.AddDbContextPool<CompanyContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
