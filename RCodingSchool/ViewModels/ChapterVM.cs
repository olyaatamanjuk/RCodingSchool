﻿using StudLine.Models;
using System.Collections.Generic;

namespace StudLine.ViewModels
{
    public class ChapterVM: Entity
    {
        public string Name { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<TopicVM> Topics { get; set; }
		public int CurrentTopicId { get; set; }
    }
}