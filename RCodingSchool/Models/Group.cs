using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
	public class Group: Entity
	{
		public string Name { get; set; }
		public IEnumerable<Teacher> Teachers { get; set; }
	}
}