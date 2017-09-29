namespace RCodingSchool.Models
{
    public class TeacherGroup
    {
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}