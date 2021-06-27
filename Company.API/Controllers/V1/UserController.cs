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
    public class UserController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IRolePermissionService rolePermissionService;
        readonly IUserService userService;

        public UserController(IMapper mapper, IRolePermissionService rolePermissionService, IUserService userService) =>
            (this.mapper, this.rolePermissionService, this.userService) = (mapper, rolePermissionService, userService);

        [HttpGet]
        public async IAsyncEnumerable<UserResponse> Get()
        {
            var users = userService.GetUsers();
            await foreach (UserEntity user in users)
                yield return mapper.Map<UserResponse>(user);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            UserEntity userFound = await userService.FindUser(user => user.Id == userId);
            if (User == null)
                return NotFound();
            UserResponse user = mapper.Map<UserResponse>(userFound);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegisterRequest userRegisterRequest)
        {
            RoleEntity roleFound = await rolePermissionService.FindRole(role => role.Name == userRegisterRequest.Role);
            if (roleFound == null)
                return BadRequest(new { Errors = new[] { "The user cannot be created if an existing role is not specified" } });
            UserEntity userMapped = mapper.Map<UserEntity>(userRegisterRequest);
            userMapped.RoleId = roleFound.Id;
            UserEntity userAdded = await userService.AddUser(userMapped);
            UserResponse user = mapper.Map<UserResponse>(userAdded);

            return Ok(user);
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UserRegisterRequest userRegisterRequest)
        {
            UserEntity userFound = await userService.FindUser(user => user.Id == userId);
            if (userFound == null)
                return NotFound();
            UserEntity userMapped = mapper.Map(userRegisterRequest, userFound);
            UserEntity userEdited = await userService.EditUser(userMapped);
            UserResponse user = mapper.Map<UserResponse>(userEdited);

            return Ok(user);
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            UserEntity userFound = await userService.FindUser(user => user.Id == userId);
            if (userFound == null)
                return NotFound();
            _ = await userService.RemoveUser(userFound);

            return NoContent();
        }
    }
}
