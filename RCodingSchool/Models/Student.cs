using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class Student : Entity
    {
		public int GroupId { get; set; }
        public Group Group { get; set; }

		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }

		public int UserId { get; set; }
        public User User { get; set; }
    }
}