using Autofac;
using Company.Domain;
using Company.Infrastructure;

namespace Company.API
{
    class CompanyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryContext<>))
                .As(typeof(IRepositoryContext<>));
            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>));
            builder.RegisterType<RolePermissionService>()
                .As<IRolePermissionService>();
            builder.RegisterType<UserService>()
                .As<IUserService>();
            builder.RegisterType<NewsService>()
                .As<INewsService>();
        }
    }
}
