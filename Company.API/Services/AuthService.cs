using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Company.Domain;

namespace Company.API
{
    class AuthService : IAuthService
    {
        readonly IMapper mapper;
        readonly IUserService userService;
        readonly IRolePermissionService rolePermissionService;
        readonly IJwtAuthentication jwtAuthentication;

        static Func<string, Expression<Func<UserEntity, bool>>> UserExistsExpression => usernameOrEmail =>
            user => user.Username == usernameOrEmail || user.Email == usernameOrEmail;

        public AuthService(
            IMapper mapper,
            IUserService userService,
            IRolePermissionService rolePermissionService,
            IJwtAuthentication jwtAuthentication)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.rolePermissionService = rolePermissionService;
            this.jwtAuthentication = jwtAuthentication;
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

            return await jwtAuthentication.GetAuthentication(userCreated, role);
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

            return await jwtAuthentication.GetAuthentication(userFound, roleFound);
        }

        private async Task<RoleEntity> GetRole(string roleName = null)
        {
            bool isEmptyUsers = !(await userService.GetUsers().AnyAsync());
            if (!isEmptyUsers && roleName != null)
                return await rolePermissionService.FindRole(role => role.Name == roleName);
            string defaultRoleName = isEmptyUsers ? RoleTypes.AdminUser : RoleTypes.VisitorUser;

            return await rolePermissionService.FindRole(role => role.Name == defaultRoleName);
        }
    }
}
