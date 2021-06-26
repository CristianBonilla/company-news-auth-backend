using Company.Infrastructure;

namespace Company.Domain
{
    public class DataContext : RepositoryContext<CompanyContext>, IDataContext
    {
        public DataContext(CompanyContext context) : base(context) { }
    }
}
