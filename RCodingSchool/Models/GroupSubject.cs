namespace RCodingSchool.Models
{
    public class GroupSubject
    {
        public Group Group { get; set; }
        public int GroupId { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}