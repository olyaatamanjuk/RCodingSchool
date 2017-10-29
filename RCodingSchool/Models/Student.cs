using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class Student : Entity
    {
		public int GroupId { get; set; }
        public Group Group { get; set; }

		public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}