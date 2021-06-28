using AutoMapper;

namespace Company.API
{
    class MapperStart
    {
        public static MapperConfiguration Build()
        {
            MapperConfiguration config = new(configuration =>
            {
                configuration.AddProfile<AuthProfile>();
                configuration.AddProfile<CompanyProfile>();
            });
            config.AssertConfigurationIsValid<AuthProfile>();
            config.AssertConfigurationIsValid<CompanyProfile>();

            return config;
        }
    }
}
