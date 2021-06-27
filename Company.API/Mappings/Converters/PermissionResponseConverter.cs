using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Company.Domain;

namespace Company.API
{
    class PermissionResponseConverter : ITypeConverter<IAsyncEnumerable<PermissionEntity>, IAsyncEnumerable<PermissionResponse>>
    {
        public IAsyncEnumerable<PermissionResponse> Convert(
            IAsyncEnumerable<PermissionEntity> source,
            IAsyncEnumerable<PermissionResponse> destination,
            ResolutionContext context)
        {
            IRuntimeMapper mapper = context.Mapper;
            var permissionResponses = source.GroupBy(
                permission => permission.Type,
                permission => permission,
                (type, content) => new PermissionResponse
                {
                    Type = type,
                    Content = mapper.Map<IEnumerable<PermissionDetailResponse>>(content.ToEnumerable())
                });

            return permissionResponses;
        }
    }
}
