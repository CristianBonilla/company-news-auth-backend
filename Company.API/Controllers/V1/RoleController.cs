using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Company.Domain;

namespace Company.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IRolePermissionService rolePermissionService;

        public RoleController(IMapper mapper, IRolePermissionService rolePermissionService) =>
            (this.mapper, this.rolePermissionService) = (mapper, rolePermissionService);

        [HttpGet]
        public async IAsyncEnumerable<RoleResponse> Get()
        {
            var roles = rolePermissionService.GetRoles();
            await foreach (RoleEntity role in roles)
                yield return mapper.Map<RoleResponse>(role);
        }

        [HttpGet("{roleId:guid}")]
        public async Task<IActionResult> Get(Guid roleId)
        {
            RoleEntity roleFound = await rolePermissionService.FindRole(role => role.Id == roleId);
            if (roleFound == null)
                return NotFound(new { Errors = new[] { "The role has not been found, surely it does not exist" } });
            RoleResponse role = mapper.Map<RoleResponse>(roleFound);

            return Ok(role);
        }

        [HttpGet("{roleId:guid}/permissions")]
        public async Task<IActionResult> GetPermissionsByRole(Guid roleId)
        {
            RoleEntity roleFound = await rolePermissionService.FindRole(role => role.Id == roleId);
            if (roleFound == null)
                return NotFound(new { Errors = new[] { "Unable to get permissions if role does not exist" } });
            var permissions = rolePermissionService.GetPermissionsByRole(roleFound);
            var permissionsMapped = mapper.Map<IAsyncEnumerable<PermissionResponse>>(permissions);

            return Ok(permissionsMapped);
        }
    }
}
