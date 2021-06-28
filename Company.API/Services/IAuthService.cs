using System.Threading.Tasks;

namespace Company.API
{
    public interface IAuthService
    {
        Task<bool> UserExists(UserRegisterRequest userRegisterRequest);
        Task<AuthResult> Register(UserRegisterRequest userRegisterRequest);
        Task<AuthResult> Login(UserLoginRequest userLoginRequest);
    }
}
