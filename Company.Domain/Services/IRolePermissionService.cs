using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Company.Domain
{
    public interface IRolePermissionService
    {
        Task<RoleEntity> FindRole(Expression<Func<RoleEntity, bool>> expression);
        IAsyncEnumerable<RoleEntity> GetRoles();
        IAsyncEnumerable<PermissionEntity> GetPermissions();
        IAsyncEnumerable<PermissionEntity> GetPermissionsByRole(RoleEntity role);
    }
}
