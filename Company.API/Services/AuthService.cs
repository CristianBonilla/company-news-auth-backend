using AutoMapper;
using Company.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Company.API
{
    class AuthService : IAuthService
    {
        readonly IMapper mapper;
        readonly IUserService userService;
        readonly IRolePermissionService rolePermissionService;
        readonly JwtOptions jwtOptions;

        static Func<string, Expression<Func<UserEntity, bool>>> UserExistsExpression => usernameOrEmail =>
            user => user.Username == usernameOrEmail || user.Email == usernameOrEmail;

        public AuthService(
            IMapper mapper,
            IUserService userService,
            IRolePermissionService rolePermissionService,
            IOptions<JwtOptions> options)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.rolePermissionService = rolePermissionService;
            jwtOptions = options.Value;
        }

        public async Task<bool> UserExits(string usernameOrEmail)
        {
            bool existingUser = await userService.UserExists(UserExistsExpression(usernameOrEmail));

            return existingUser;
        }

        public async Task<AuthenticationResult> Register(UserRegisterRequest userRegisterRequest, string roleName = null)
        {
            bool existingUser = await UserExits(userRegisterRequest.Username) || await UserExits(userRegisterRequest.Email);
            if (existingUser)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "User with provided email or username already exists" }
                };
            }
            RoleEntity role = await GetRole(roleName);
            if (role == null)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "The user cannot be created if an existing role is not specified" }
                };
            }
            UserEntity userMapped = mapper.Map<UserEntity>(userRegisterRequest, options => options.AfterMap((_, user) => user.Role = role));
            UserEntity userCreated = await userService.AddUser(userMapped);

            return await GetJwtAuthentication(userCreated, role);
        }

        public async Task<AuthenticationResult> Login(UserLoginRequest userLoginRequest)
        {
            string usernameOrEmail = userLoginRequest.UsernameOrEmail;
            UserEntity userFound = await userService.FindUser(UserExistsExpression(userLoginRequest.UsernameOrEmail));
            if (userFound == null)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "User is not registered or is incorrect" }
                };
            }
            if (userFound.Password != userLoginRequest.Password)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "User password is invalid" }
                };
            }
            RoleEntity roleFound = await rolePermissionService.FindRole(role => role.Id == userFound.RoleId);

            return await GetJwtAuthentication(userFound, roleFound);
        }

        private async Task<AuthenticationResult> GetJwtAuthentication(UserEntity user, RoleEntity role)
        {
            var permissionsByRole = rolePermissionService.GetPermissionsByRole(role);
            var permissionsMapped = mapper.Map<IAsyncEnumerable<PermissionResponse>>(permissionsByRole);
            var permissions = await permissionsMapped.ToArrayAsync();
            string permissionNamesJson = await GetPermissionNamesToJson(permissionsMapped);
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(jwtOptions.Secret);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(JwtRegisteredClaimNames.Sub, user.Email),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(JwtRegisteredClaimNames.Email, user.Email),
                    new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new(ClaimTypes.NameIdentifier, user.Username),
                    new(ClaimTypes.Role, role.Name),
                    new(CommonValues.UserPermissions, permissionNamesJson, JsonClaimValueTypes.JsonArray)
                }),
                Expires = DateTime.UtcNow.AddDays(jwtOptions.ExpiresInDays),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            UserResponse userResponse = mapper.Map<UserResponse>(user);
            RoleResponse roleResponse = mapper.Map<RoleResponse>(role);

            return new()
            {
                Success = true,
                Token = token,
                Permissions = permissions,
                User = userResponse,
                Role = roleResponse
            };
        }

        private async Task<RoleEntity> GetRole(string roleName = null)
        {
            bool isEmptyUsers = !(await userService.GetUsers().AnyAsync());
            if (!isEmptyUsers && roleName != null)
                return await rolePermissionService.FindRole(role => role.Name == roleName);
            string defaultRoleName = isEmptyUsers ? RoleTypes.AdminUser : RoleTypes.VisitorUser;

            return await rolePermissionService.FindRole(role => role.Name == defaultRoleName);
        }

        private static async Task<string> GetPermissionNamesToJson(IAsyncEnumerable<PermissionResponse> permissions)
        {
            var permissionNames = await permissions.Select(permission => new
            {
                type = permission.Type,
                names = permission.Content.Select(content => content.Name)
            }).ToArrayAsync();
            string permissionNamesToJson = JsonConvert.SerializeObject(permissionNames, Formatting.Indented);

            return permissionNamesToJson;
        }
    }
}
