using Autofac;

namespace Company.API
{
    class AuthModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtAuthentication>()
                .As<IJwtAuthentication>();
            builder.RegisterType<AuthService>()
                .As<IAuthService>();
        }
    }
}
