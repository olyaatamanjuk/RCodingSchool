using StudLine.Models;
using System.Collections.Generic;

namespace StudLine.ViewModels
{
	public class GroupVM : Entity
	{
		public string Name { get; set; }

		public List<Student> Students { get; set; }
		public List<Teacher> Teachers { get; set; }
	}
}