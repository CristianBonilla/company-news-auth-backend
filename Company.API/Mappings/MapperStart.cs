using AutoMapper;

namespace Company.API
{
    class MapperStart
    {
        public static MapperConfiguration Build()
        {
            MapperConfiguration config = new(configuration => configuration.AddProfile<CompanyProfile>());
            config.AssertConfigurationIsValid<CompanyProfile>();

            return config;
        }
    }
}
