using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudLine.Models
{
	public class Comment : Entity
	{
		public DateTime Date { get; set; }
		public string Text { get; set; }

		public News News { get; set; }
		public int NewsId { get; set; }

		public virtual User User { get; set; }
		public int UserId { get; set; }
	}
}