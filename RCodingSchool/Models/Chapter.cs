using System.Collections.Generic;

namespace StudLine.Models
{
    public class Chapter : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}