using RCodingSchool.Models;

namespace RCodingSchool.ViewModels
{
	public class TeacherVM: Entity
	{
		public int UserId { get; set; }
		public User User { get; set; }
	}
}