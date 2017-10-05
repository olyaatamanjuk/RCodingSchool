using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
	public class MessageGroup: Entity
	{
		public string Name { get; set; }
		public IEnumerable<User> Users { get; set; }
	}
}