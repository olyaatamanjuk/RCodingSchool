using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class Group : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<TeacherGroup> Teachers { get; set; }
        public IEnumerable<GroupSubject> GroupSubject { get; set; }
    }
}