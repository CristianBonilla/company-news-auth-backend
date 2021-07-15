using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Company.Domain;

namespace Company.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PermissionController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IRolePermissionService rolePermissionService;

        public PermissionController(IMapper mapper, IRolePermissionService rolePermissionService) =>
            (this.mapper, this.rolePermissionService) = (mapper, rolePermissionService);

        [HttpGet]
        [PermissionsAuthorize(
            CanRoles = new[] { RolePermissionTypes.GetPermissions }
        )]
        public IAsyncEnumerable<PermissionResponse> Get()
        {
            var permissions = rolePermissionService.GetPermissions();
            var permissionsMapped = mapper.Map<IAsyncEnumerable<PermissionResponse>>(permissions);

            return permissionsMapped;
        }
    }
}
