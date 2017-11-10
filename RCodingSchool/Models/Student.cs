namespace RCodingSchool.Models
{
    public class Student : Entity
    {
		public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

		public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}