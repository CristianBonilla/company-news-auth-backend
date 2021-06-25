using Company.Infrastructure;

namespace Company.Domain
{
    public interface IContext : IRepositoryContext<CompanyContext> { }
}
