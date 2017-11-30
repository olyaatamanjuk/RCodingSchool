using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool.ViewModels
{
    public class TopicVM : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Teacher Author { get; set; }
        public int AuthorId { get; set; }

		public Chapter Chapter { get; set; }
		public int ChapterId { get; set; }

        public int SubjectId { get; set; }

        public ICollection<File> Files { get; set; }
    }
}