using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCodingSchool.Models
{
    public class Topic : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        public Teacher Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Chapter Chapter { get; set; }
        public int ChapterId { get; set; }

        public ICollection<File> Files { get; set; }
    }
}