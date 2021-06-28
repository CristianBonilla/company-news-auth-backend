namespace Company.API
{
    struct CommonValues
    {
        public const string Bearer = nameof(Bearer);
        public const string CompanyAuthConnection = nameof(CompanyAuthConnection);
        public const string AllowOrigins = nameof(AllowOrigins);
        public static string UserPermissions => ToCamelCase(nameof(UserPermissions));

        private static string ToCamelCase(string source) => char.ToLowerInvariant(source[0]) + source[1..];
    }
}
