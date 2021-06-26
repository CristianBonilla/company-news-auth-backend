using Autofac;
using Company.Domain;
using Company.Infrastructure;

namespace Company.API
{
    class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryContext<>))
                .As(typeof(IRepositoryContext<>));
            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>));

            builder.RegisterType<DataContext>()
                .As<IDataContext>();
            builder.RegisterType<RoleRepository>()
                .As<IRoleRepository>();
            builder.RegisterType<PermissionRepository>()
                .As<IPermissionRepository>();
            builder.RegisterType<RolePermissionRepository>()
                .As<IRolePermissionRepository>();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();
            builder.RegisterType<NewsRepository>()
                .As<INewsRepository>();

            builder.RegisterType<RolePermissionService>()
                .As<IRolePermissionService>();
            builder.RegisterType<UserService>()
                .As<IUserService>();
            builder.RegisterType<NewsService>()
                .As<INewsService>();
        }
    }
}
