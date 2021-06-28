using System.Threading.Tasks;
using Company.Domain;

namespace Company.API
{
    interface IJwtAuthentication
    {
        Task<AuthenticationResult> GetAuthentication(UserEntity user, RoleEntity role);
    }
}
