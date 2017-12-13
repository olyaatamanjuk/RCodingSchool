using StudLine.Models;

namespace StudLine.ViewModels
{
	public class TeacherVM: Entity
	{
		public int UserId { get; set; }
		public User User { get; set; }

		public bool MarkForDelete { get; set; }
	}
}