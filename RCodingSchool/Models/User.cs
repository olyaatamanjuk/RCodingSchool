using System;

namespace StudLine.Models
{
    public class User : Entity
    {
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
        public string RoleName { get; set; }
		public bool IsAdmin { get; set; }
        public Guid RegisterCode { get; set; }
		public bool IsActive { get; set; }
	}
}