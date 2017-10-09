using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
	public class Task: Entity
	{
		public string Name { get; set; }
		public ICollection<File> Files;
		public ICollection<Group> Groups;
	}
}