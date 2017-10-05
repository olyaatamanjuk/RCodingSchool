using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCodingSchool.Models
{
	public class Message: Entity
	{
        public string Text { get; set; }
        public string GroupName { get; set; }

        public User User { get; set; }
		public int UserId { get; set; }

		public MessageGroup MessageGroup { get; set; }
		public int MessageGroupId { get; set; }

		public DateTime TimeOfSending { get; set; }

		[ForeignKey("RecieverId")]
		public User Reciever { get; set; }
        [ForeignKey("Reciever")]
        public int ReceiverId { get; set; }
    }
}