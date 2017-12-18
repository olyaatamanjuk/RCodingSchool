using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudLine.Models
{
	public class News : Entity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }

		public virtual User User { get; set; }
		public int UserId { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }
	}
}