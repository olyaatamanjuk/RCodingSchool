using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class Teacher : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<TeacherGroup> Groups { get; set; }
        public IEnumerable<TeacherSubject> Subjects { get; set; }
    }
}