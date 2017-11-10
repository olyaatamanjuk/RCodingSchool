using System;

namespace RCodingSchool.Models
{
	public class Message: Entity
	{
        public string Text { get; set; }
        public string GroupName { get; set; }

        public virtual User User { get; set; }
		public int UserId { get; set; }

		public DateTime ReceiveTime { get; set; }
    }
}