using System.Collections.Generic;

namespace RCodingSchool.Models
{
	public class DoneTask: Entity
	{
		public string Text { get; set; }
		public int Mark { get; set; }

		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		public int TaskId { get; set; }
		public virtual Task Task { get; set; }

		public virtual ICollection<File> Files { get; set; }
	}
}