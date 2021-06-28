using System.Threading.Tasks;
using Company.Domain;

namespace Company.API
{
    public interface IJwtAuthentication
    {
        Task<AuthResult> GetAuthentication(UserEntity user, RoleEntity role);
    }
}
