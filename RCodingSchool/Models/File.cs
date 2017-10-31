namespace RCodingSchool.Models
{
    public class File: Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public Topic Topic { get; set; }
        public int? TopicId { get; set; }
    }
}