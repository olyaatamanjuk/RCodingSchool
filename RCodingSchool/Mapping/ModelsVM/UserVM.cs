using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Mapping.ModelsVM
{
	public class UserVM: Entity
	{
		public bool RememberMe { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public bool isAdmin { get; set; }
	}
}