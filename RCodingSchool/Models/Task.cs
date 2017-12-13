using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudLine.Models
{
	public class Task: Entity
	{
		public string Name { get; set; }
		public string Text { get; set; }

		public virtual Subject Subject { get; set; }
		public int SubjectId { get; set; }

		public virtual Teacher Teacher { get; set; }
		public int TeacherId { get; set; }

		public virtual ICollection<File> Files { get; set; }
		public virtual ICollection<Group> Groups { get; set; }
		public virtual ICollection<DoneTask> DoneTasks { get; set; }
	}
}