using System.Collections.Generic;

namespace StudLine.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
		public string Calendar { get; set; }

		public IEnumerable<TeacherSubject> Teachers { get; set; }
        public IEnumerable<GroupSubject> GroupSubject { get; set; }
        public bool IsExam { get; set; }
    }
}