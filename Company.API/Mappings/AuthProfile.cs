using AutoMapper;

namespace Company.API
{
    class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<AuthResult, AuthFailedResponse>();
            CreateMap<AuthResult, AuthSuccessResponse>();
        }
    }
}
