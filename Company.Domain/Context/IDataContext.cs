using Company.Infrastructure;

namespace Company.Domain
{
    public interface IDataContext : IRepositoryContext<CompanyContext> { }
}
