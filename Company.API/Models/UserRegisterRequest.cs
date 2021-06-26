namespace Company.API
{
    class UserRegisterRequest
    {
        public long IdentificationNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public short Age { get; set; }
        public string Role { get; set; }
    }
}
