using StudLine.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudLine.ViewModels
{
	public class StudentVM: Entity
	{
		public int GroupId { get; set; }
		public Group Group { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public int newGroupId { get; set; }

		public bool MyGroups { get; set; }
		public bool AllGroups { get; set; }

		public bool MarkForDelete { get; set; }
	}
}