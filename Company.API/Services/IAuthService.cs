using System.Threading.Tasks;

namespace Company.API
{
    interface IAuthService
    {
        Task<bool> UserExits(string usernameOrEmail);
        Task<AuthenticationResult> Register(UserRegisterRequest userRegisterRequest, string roleName = null);
        Task<AuthenticationResult> Login(UserLoginRequest userLoginRequest);
    }
}
