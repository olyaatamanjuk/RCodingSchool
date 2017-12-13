using StudLine.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudLine.ViewModels
{
    public class UserVM: Entity
	{
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public bool isAdmin { get; set; }
		public bool IsActive { get; set; }

		public bool RememberMe { get; set; }
		public int GroupId { get; set; }
		public string ConfirmPassword { get; set; }
		public bool IsTeacher { get; set; }
		public IEnumerable<SelectListItem> Categories { get; set; }
	}
}