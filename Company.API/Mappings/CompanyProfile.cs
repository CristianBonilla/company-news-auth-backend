using AutoMapper;
using Company.Domain;

namespace Company.API
{
    class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<RoleEntity, RoleResponse>();
            CreateMap<NewsEntity, NewsResponse>();
            CreateMap<RolesPermission, PermissionResponse>();
            CreateMap<UsersPermission, PermissionResponse>();
            CreateMap<NewsPermission, PermissionResponse>();
            CreateMap<UserRegisterRequest, UserEntity>()
                .ForMember(member => member.Id, options => options.Ignore())
                .ForMember(member => member.RoleId, options => options.Ignore())
                .ForMember(member => member.Role, options => options.Ignore());
            CreateMap<UserEntity, UserResponse>();
        }
    }
}
