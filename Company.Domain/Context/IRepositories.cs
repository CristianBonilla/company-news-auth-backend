using Company.Infrastructure;

namespace Company.Domain
{
    public interface IRoleRepository : IRepository<CompanyContext, RoleEntity> { }

    public interface IUserRepository : IRepository<CompanyContext, UserEntity> { }

    public interface INewsRepository : IRepository<CompanyContext, NewsEntity> { }
}
