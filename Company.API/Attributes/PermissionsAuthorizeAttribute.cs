using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Company.Domain;

namespace Company.API
{
    class PermissionsAuthorizeAttribute : AuthorizeAttribute
    {
        readonly Dictionary<DefaultPermissionTypes, string> policyPermissionTypes = Enum.GetValues<DefaultPermissionTypes>()
            .ToDictionary(
                permissionType => permissionType,
                permissionType => (string)null);
        RolePermissionTypes[] canRoles = Array.Empty<RolePermissionTypes>();
        UserPermissionTypes[] canUsers = Array.Empty<UserPermissionTypes>();
        NewsPermissionTypes[] canNews = Array.Empty<NewsPermissionTypes>();

        public RolePermissionTypes[] CanRoles
        {
            get => canRoles;
            set
            {
                canRoles = value;
                BuildPolicyPermissions(canRoles);
            }
        }
        public UserPermissionTypes[] CanUsers
        {
            get => canUsers;
            set
            {
                canUsers = value;
                BuildPolicyPermissions(canUsers);
            }
        }
        public NewsPermissionTypes[] CanNews
        {
            get => canNews;
            set
            {
                canNews = value;
                BuildPolicyPermissions(canNews);
            }
        }

        private void BuildPolicyPermissions<TPermissionType>(TPermissionType[] permissions) where TPermissionType : struct, Enum
        {
            if (!permissions.Any())
                return;
            CleanPolicyProperty();
            DefaultPermissionTypes? permissionType = typeof(TPermissionType).Name switch
            {
                nameof(RolePermissionTypes) => DefaultPermissionTypes.CanRoles,
                nameof(UserPermissionTypes) => DefaultPermissionTypes.CanUsers,
                nameof(NewsPermissionTypes) => DefaultPermissionTypes.CanNews,
                _ => null
            };
            if (!permissionType.HasValue)
                return;
            policyPermissionTypes[permissionType.Value] = permissions.Select(permission => Enum.GetName(permission))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Aggregate("", (permissions, next) => permissions += permissions.Any() ? $",{ next }" : next);
            SetPolicyPermissionType(permissionType.Value);
        }

        private string GetPolicyPermissionType(DefaultPermissionTypes permissionType)
        {
            string permissionTypeName = Enum.GetName(permissionType);
            if (!Policy.Contains($"[{ permissionTypeName }]"))
                return null;
            int permissionTypeStart = Policy.IndexOf($"[{ permissionTypeName }]");
            int permissionTypeEnd = Policy.IndexOf('|', permissionTypeStart);
            permissionTypeEnd = (permissionTypeEnd > 0 ? permissionTypeEnd : Policy.Length) - permissionTypeStart;

            return Policy.Substring(permissionTypeStart, permissionTypeEnd);
        }

        private void SetPolicyPermissionType(DefaultPermissionTypes permissionType)
        {
            string permissionTypeName = Enum.GetName(permissionType);
            if (!Policy.Contains($"[{ permissionTypeName }]"))
            {
                Policy += Policy.Any() ? $"|[{ permissionTypeName }]" : $"[{ permissionTypeName }]";
                Policy += policyPermissionTypes[permissionType];

                return;
            }
            int permissionTypeStart = Policy.IndexOf($"[{ permissionTypeName }");
            permissionTypeStart = Policy.IndexOf(']', permissionTypeStart) + 1;
            int permissionTypeEnd = Policy.IndexOf('|', permissionTypeStart);
            permissionTypeEnd = (permissionTypeEnd > 0 ? permissionTypeEnd : Policy.Length) - permissionTypeStart;

            Policy = Policy.Replace(Policy.Substring(permissionTypeStart, permissionTypeEnd), policyPermissionTypes[permissionType]);
        }

        private bool HasPolicyPermissionTypes() =>
            policyPermissionTypes.Keys.Any(permission => GetPolicyPermissionType(permission) != null);

        private void CleanPolicyProperty()
        {
            Policy ??= "";
            Policy = Regex.Replace(Policy, @"\s+", "");
            if (!HasPolicyPermissionTypes())
                Policy = "";
        }
    }
}
