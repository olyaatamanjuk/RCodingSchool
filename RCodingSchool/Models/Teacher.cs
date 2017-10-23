using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class Teacher : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }

		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }

		public ICollection<TeacherGroup> Groups { get; set; }
        public ICollection<TeacherSubject> Subjects { get; set; }
		public ICollection<News> News { get; set; }
	}
}