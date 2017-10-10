using RCodingSchool.Models;

namespace RCodingSchool.ViewModels
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