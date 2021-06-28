using AutoMapper;
using Company.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Company.API
{
    class JwtAuthentication : IJwtAuthentication
    {
        readonly IMapper mapper;
        readonly IRolePermissionService rolePermissionService;
        readonly JwtOptions jwtOptions;

        public JwtAuthentication(
            IMapper mapper,
            IRolePermissionService rolePermissionService,
            IOptions<JwtOptions> options)
        {
            this.mapper = mapper;
            this.rolePermissionService = rolePermissionService;
            jwtOptions = options.Value;
        }

        public async Task<AuthenticationResult> GetAuthentication(UserEntity user, RoleEntity role)
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
