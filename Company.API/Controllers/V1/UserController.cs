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
    [PermissionsAuthorize(
        CanUsers = new[] { UserPermissionTypes.ALL },
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    )]
    public class UserController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IRolePermissionService rolePermissionService;
        readonly IUserService userService;
        readonly IAuthService authService;

        public UserController(
            IMapper mapper,
            IRolePermissionService rolePermissionService,
            IUserService userService,
            IAuthService authService)
        {
            this.mapper = mapper;
            this.rolePermissionService = rolePermissionService;
            this.userService = userService;
            this.authService = authService;
        }

        [HttpGet]
        [PermissionsAuthorize(
            CanUsers = new[] { UserPermissionTypes.GetUsers }
        )]
        public async IAsyncEnumerable<UserResponse> Get()
        {
            var users = userService.GetUsers();
            await foreach (UserEntity user in users)
                yield return mapper.Map<UserResponse>(user);
        }

        [HttpGet("{userId:guid}")]
        [PermissionsAuthorize(
            CanUsers = new[] { UserPermissionTypes.GetUserById }
        )]
        public async Task<IActionResult> Get(Guid userId)
        {
            UserEntity userFound = await userService.FindUser(user => user.Id == userId);
            if (User == null)
                return NotFound(new { Errors = new[] { "User is not registered or is incorrect" } });
            UserResponse user = mapper.Map<UserResponse>(userFound);

            return Ok(user);
        }

        [HttpPost]
        [PermissionsAuthorize(
            CanUsers = new[] { UserPermissionTypes.AddUser }
        )]
        public async Task<IActionResult> Post([FromBody] UserRegisterRequest userRegisterRequest)
        {
            bool existingUser = await authService.UserExists(userRegisterRequest);
            if (existingUser)
                return BadRequest(new { Errors = new[] { "User with email, username or identification number provided already exists" } });
            RoleEntity roleFound = await rolePermissionService.FindRole(role => role.Name == userRegisterRequest.Role);
            if (roleFound == null)
                return BadRequest(new { Errors = new[] { "User cannot be created if an existing role is not specified" } });
            UserEntity userMapped = mapper.Map<UserEntity>(userRegisterRequest, options => options.AfterMap((_, user) => user.RoleId = roleFound.Id));
            UserEntity userAdded = await userService.AddUser(userMapped);
            UserResponse user = mapper.Map<UserResponse>(userAdded);

            return Ok(user);
        }

        [HttpPut("{userId:guid}")]
        [PermissionsAuthorize(
            CanUsers = new[] { UserPermissionTypes.EditUser }
        )]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UserRegisterRequest userRegisterRequest)
        {
            UserEntity userFound = await userService.FindUser(user => user.Id == userId);
            if (userFound == null)
                return NotFound(new { Errors = new[] { "User is not registered or is incorrect" } });
            bool existingUser = await authService.UserExists(userRegisterRequest);
            if (existingUser)
                return BadRequest(new { Errors = new[] { "User with email, username or identification number provided already exists" } });
            RoleEntity roleFound = await rolePermissionService.FindRole(role => role.Name == userRegisterRequest.Role);
            if (roleFound == null)
                return BadRequest(new { Errors = new[] { "User cannot be edited if an existing role is not specified" } });
            UserEntity userMapped = mapper.Map(userRegisterRequest, userFound);
            UserEntity userEdited = await userService.EditUser(userMapped);
            UserResponse user = mapper.Map<UserResponse>(userEdited);

            return Ok(user);
        }

        [HttpDelete("{userId:guid}")]
        [PermissionsAuthorize(
            CanUsers = new[] { UserPermissionTypes.RemoveUser }
        )]
        public async Task<IActionResult> Delete(Guid userId)
        {
            UserEntity userFound = await userService.FindUser(user => user.Id == userId);
            if (userFound == null)
                return NotFound(new { Errors = new[] { "User is not registered or is incorrect" } });
            _ = await userService.RemoveUser(userFound);

            return NoContent();
        }
    }
}
