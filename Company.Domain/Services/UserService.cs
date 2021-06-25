using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Company.Domain
{
    public class UserService : IUserService
    {
        readonly IContext context;
        readonly IUserRepository userRepository;

        public UserService(IContext context, IUserRepository userRepository) =>
            (this.context, this.userRepository) = (context, userRepository);

        public async Task<UserEntity> AddUser(UserEntity user)
        {
            UserEntity userAdded = userRepository.Create(user);
            _ = await context.SaveAsync();

            return userAdded;
        }

        public async Task<UserEntity> EditUser(UserEntity user)
        {
            UserEntity userEdited = userRepository.Update(user);
            _ = await context.SaveAsync();

            return userEdited;
        }

        public Task<UserEntity> FindUser(Expression<Func<UserEntity, bool>> expression)
        {
            UserEntity user = userRepository.Find(expression);

            return Task.FromResult(user);
        }

        public IAsyncEnumerable<UserEntity> GetUsers()
        {
            var users = userRepository.Get(null, order => order.OrderBy(user => user.IdentificationNumber)
                .ThenBy(user => user.Username))
                .ToAsyncEnumerable();

            return users;
        }

        public async Task<UserEntity> RemoveUser(UserEntity user)
        {
            UserEntity userRemoved = userRepository.Delete(user);
            _ = await context.SaveAsync();

            return userRemoved;
        }
    }
}
