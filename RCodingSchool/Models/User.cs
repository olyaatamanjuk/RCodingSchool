using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public bool isAdmin { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}