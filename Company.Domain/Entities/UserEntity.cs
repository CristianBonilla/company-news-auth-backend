using System;

namespace Company.Domain
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public long IdentificationNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public short Age { get; set; }
        public RoleEntity Role { get; set; }
    }
}
