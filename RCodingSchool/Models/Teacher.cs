﻿using System.Collections.Generic;

namespace StudLine.Models
{
    public class Teacher : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

		public ICollection<TeacherGroup> Groups { get; set; }
        public ICollection<TeacherSubject> Subjects { get; set; }
		public ICollection<News> News { get; set; }
	}
}