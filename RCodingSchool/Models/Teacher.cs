using System.Collections.Generic;

namespace StudLine.Models
{
    public class Teacher : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

		public virtual ICollection<TeacherGroup> Groups { get; set; }
        public virtual ICollection<TeacherSubject> Subjects { get; set; }
		
	}
}