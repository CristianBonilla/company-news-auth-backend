using Company.Infrastructure;

namespace Company.Domain
{
    public class RoleRepository : Repository<CompanyContext, RoleEntity>, IRoleRepository
    {
        public RoleRepository(IDataContext context) : base(context) { }
    }

    public class PermissionRepository : Repository<CompanyContext, PermissionEntity>, IPermissionRepository
    {
        public PermissionRepository(IDataContext context) : base(context) { }
    }

    public class RolePermissionRepository : Repository<CompanyContext, RolePermissionEntity>, IRolePermissionRepository
    {
        public RolePermissionRepository(IDataContext context) : base(context) { }
    }

    public class UserRepository : Repository<CompanyContext, UserEntity>, IUserRepository
    {
        public UserRepository(IDataContext context) : base(context) { }
    }

    public class NewsRepository : Repository<CompanyContext, NewsEntity>, INewsRepository
    {
        public NewsRepository(IDataContext context) : base(context) { }
    }
}
