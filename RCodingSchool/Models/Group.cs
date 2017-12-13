using System.Collections.Generic;

namespace StudLine.Models
{
	public class Group : Entity
	{
		public string Name { get; set; }

		public virtual ICollection<Student> Students { get; set; }
		public virtual ICollection<Teacher> Teachers { get; set; }
	}
}