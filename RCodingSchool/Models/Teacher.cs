using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
    public class Teacher : Entity
    {
		public IEnumerable<Group> Groups;
		public int UserId { get; set; }
	}
}