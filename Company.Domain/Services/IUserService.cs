using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Company.Domain
{
    public interface IUserService
    {
        Task<UserEntity> FindUser(Expression<Func<UserEntity, bool>> expression);
        IAsyncEnumerable<UserEntity> GetUsers();
        Task<UserEntity> AddUser(UserEntity user);
        Task<UserEntity> EditUser(UserEntity user);
        Task<UserEntity> RemoveUser(UserEntity user);
    }
}
