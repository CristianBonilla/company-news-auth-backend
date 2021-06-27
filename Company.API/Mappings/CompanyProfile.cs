using AutoMapper;
using Company.Domain;
using System.Collections.Generic;

namespace Company.API
{
    class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<RoleEntity, RoleResponse>();
            CreateMap<NewsEntity, NewsResponse>();
            CreateMap<PermissionEntity, PermissionDetailResponse>();
            CreateMap<IAsyncEnumerable<PermissionEntity>, IAsyncEnumerable<PermissionResponse>>()
                .ConvertUsing<PermissionResponseConverter>();
            CreateMap<UserRegisterRequest, UserEntity>()
                .ForMember(member => member.Id, options => options.Ignore())
                .ForMember(member => member.RoleId, options => options.Ignore())
                .ForMember(member => member.Role, options => options.Ignore());
            CreateMap<UserEntity, UserResponse>();
        }
    }
}
