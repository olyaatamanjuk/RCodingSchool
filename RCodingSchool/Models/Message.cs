using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
	public class Message: Entity
	{
		public int UserId { get; set; }
		public string Text { get; set; }
		public int ReceiverId { get; set; }
	}
}