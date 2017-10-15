using RCodingSchool.Models;

namespace RCodingSchool.ViewModels
{
    public class UserVM: Entity
	{
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public bool isAdmin { get; set; }

		public bool RememberMe { get; set; }
		public string GroupName { get; set; }
		public string ConfirmPassword { get; set; }
		public bool IsTeacher { get; set; }
	}
}