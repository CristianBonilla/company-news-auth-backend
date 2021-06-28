using System.Threading.Tasks;

namespace Company.API
{
    public interface IAuthService
    {
        Task<bool> UserExits(string usernameOrEmail);
        Task<AuthResult> Register(UserRegisterRequest userRegisterRequest);
        Task<AuthResult> Login(UserLoginRequest userLoginRequest);
    }
}
