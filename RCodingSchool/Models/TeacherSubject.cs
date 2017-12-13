namespace StudLine.Models
{
    public class TeacherSubject
    {
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}