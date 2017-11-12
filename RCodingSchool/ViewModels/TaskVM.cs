using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.ViewModels
{
	public class TaskVM: Entity
	{
		public string Name { get; set; }
		public string Text { get; set; }

		public virtual Subject Subject { get; set; }
		public int SubjectId { get; set; }

		public virtual Teacher Teacher { get; set; }
		public int TeacherId { get; set; }

		public ICollection<File> Files;
		public ICollection<Group> Groups;
		public virtual ICollection<DoneTask> DoneTasks { get; set; }
	}
}