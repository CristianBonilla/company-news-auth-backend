using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Company.Domain
{
    public class RolePermissionService : IRolePermissionService
    {
        readonly IRoleRepository roleRepository;
        readonly IPermissionRepository permissionRepository;
        readonly IRolePermissionRepository rolePermissionRepository;

        public RolePermissionService(
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository,
            IRolePermissionRepository rolePermissionRepository)
        {
            this.roleRepository = roleRepository;
            this.permissionRepository = permissionRepository;
            this.rolePermissionRepository = rolePermissionRepository;
        }

        public Task<RoleEntity> FindRole(Expression<Func<RoleEntity, bool>> expression)
        {
            RoleEntity role = roleRepository.Find(expression);

            return Task.FromResult(role);
        }

        public IAsyncEnumerable<RoleEntity> GetRoles()
        {
            var roles = roleRepository.Get(null, order => order.OrderBy(role => role.Name))
                .ToAsyncEnumerable();

            return roles;
        }

        public IAsyncEnumerable<PermissionEntity> GetPermissions()
        {
            var permissions = permissionRepository.Get(null, order => order.OrderBy(permission => permission.Name))
                .ToAsyncEnumerable();

            return permissions;
        }

        public IAsyncEnumerable<PermissionEntity> GetPermissionsByRole(RoleEntity role)
        {
            var permissions = rolePermissionRepository.Get(permission => permission.RoleId == role.Id)
                .Select(permission => permissionRepository.Find(permission.PermissionId))
                .OrderBy(order => order.Type)
                .ToAsyncEnumerable();

            return permissions;
        }
    }
}
