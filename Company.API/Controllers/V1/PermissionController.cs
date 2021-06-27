using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AutoMapper;
using Company.Domain;

namespace Company.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IRolePermissionService rolePermissionService;

        public PermissionController(IMapper mapper, IRolePermissionService rolePermissionService) =>
            (this.mapper, this.rolePermissionService) = (mapper, rolePermissionService);

        [HttpGet]
        public async IAsyncEnumerable<PermissionResponse> Get()
        {
            var permissions = rolePermissionService.GetPermissions();
            await foreach (PermissionEntity permission in permissions)
                yield return mapper.Map<PermissionResponse>(permission);
        }
    }
}
