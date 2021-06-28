using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using AutoMapper;
using Company.Domain;

namespace Company.API
{
    public class JwtAuthentication : IJwtAuthentication
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

        public async Task<AuthResult> GetAuthentication(UserEntity user, RoleEntity role)
        {
            var permissionsByRole = rolePermissionService.GetPermissionsByRole(role);
            var permissionsMapped = mapper.Map<IAsyncEnumerable<PermissionResponse>>(permissionsByRole);
            var permissions = await permissionsMapped.ToArrayAsync();
            var (permissionNamesJson, jsonClaimType) = await GetPermissionNamesToJson(permissionsMapped);
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
                    new(JwtRegisteredClaimNames.UniqueName, $"{ user.Username }, { user.FirstName } { user.LastName }"),
                    new(ClaimTypes.Role, role.Name),
                    new(ClaimTypes.MobilePhone, user.Phone),
                    new(CommonValues.UserPermissions, permissionNamesJson, jsonClaimType)
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

        private static async Task<(string PermissionNamesJson, string JsonClaimType)> GetPermissionNamesToJson(
            IAsyncEnumerable<PermissionResponse> permissions)
        {
            var permissionNames = await permissions.ToDictionaryAsync(
                permission => permission.Type,
                permission => permission.Content.Select(content => content.Name));
            string permissionNamesJson = JsonConvert.SerializeObject(permissionNames, Formatting.Indented);

            return (permissionNamesJson, JsonClaimValueTypes.Json);
        }
    }
}
