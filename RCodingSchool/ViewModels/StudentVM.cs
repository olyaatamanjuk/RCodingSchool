using RCodingSchool.Models;

namespace RCodingSchool.ViewModels
{
	public class StudentVM: Entity
	{
		public int GroupId { get; set; }
		public Group Group { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}