namespace RCodingSchool.Models
{
    public class Topic : Entity
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public Teacher Author { get; set; }
        public int AuthorId { get; set; }
    }
}