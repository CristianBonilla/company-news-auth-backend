namespace Company.API
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public int ExpiresInDays { get; set; }
    }
}
