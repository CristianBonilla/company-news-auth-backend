using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Company.Domain;

namespace Company.API
{
    public class AuthService : IAuthService
    {
        readonly IMapper mapper;
        readonly IUserService userService;
        readonly IRolePermissionService rolePermissionService;
        readonly IJwtAuthentication jwtAuthentication;

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

        public async Task<bool> UserExists(UserRegisterRequest userRegisterRequest)
        {
            var (username, email, identificationNumber) = UserRegisterProperties(userRegisterRequest);
            bool existingUser = await userService.UserExists(user => user.Username == username) ||
                await userService.UserExists(user => user.Email == email) ||
                await userService.UserExists(user => user.IdentificationNumber == identificationNumber);

            return existingUser;
        }

        public async Task<AuthResult> Register(UserRegisterRequest userRegisterRequest)
        {
            bool existingUser = await UserExists(userRegisterRequest);
            if (existingUser)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "User with email, username or identification number provided already exists" }
                };
            }
            RoleEntity role = await GetRole(userRegisterRequest.Role);
            if (role == null)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "User cannot be created if an existing role is not specified" }
                };
            }
            UserEntity userMapped = mapper.Map<UserEntity>(userRegisterRequest, options => options.AfterMap((_, user) => user.Role = role));
            UserEntity userCreated = await userService.AddUser(userMapped);

            return await jwtAuthentication.GetAuthentication(userCreated, role);
        }

        public async Task<AuthResult> Login(UserLoginRequest userLoginRequest)
        {
            var (usernameOrEmail, password) = UserLoginProperties(userLoginRequest);
            UserEntity userFound = await userService.FindUser(user => user.Username == usernameOrEmail || user.Email == usernameOrEmail);
            if (userFound == null)
            {
                return new()
                {
                    Success = false,
                    Errors = new[] { "User is not registered or is incorrect" }
                };
            }
            if (userFound.Password != password)
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
            string defaultRoleName = Enum.GetName(isEmptyUsers ? DefaultRoleTypes.AdminUser : DefaultRoleTypes.VisitorUser);

            return await rolePermissionService.FindRole(role => role.Name == defaultRoleName);
        }

        private static (string Username, string Email, long IdentificationNumber) UserRegisterProperties(
            UserRegisterRequest userRegisterRequest) => (
                userRegisterRequest.Username,
                userRegisterRequest.Email,
                userRegisterRequest.IdentificationNumber);

        private static (string UsernameOrEmail, string Password) UserLoginProperties(
            UserLoginRequest userLoginRequest) => (
                userLoginRequest.UsernameOrEmail,
                userLoginRequest.Password);
    }
}
