using System.Collections.Generic;

namespace StudLine.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
		public string Calendar { get; set; }

		public IEnumerable<TeacherSubject> Teachers { get; set; }
        public virtual ICollection<GroupSubject> GroupSubject { get; set; }
		public virtual ICollection<Group> Groups { get; set; }
		public virtual ICollection<Group> Chapters { get; set; }
		public bool IsExam { get; set; }


    }
}