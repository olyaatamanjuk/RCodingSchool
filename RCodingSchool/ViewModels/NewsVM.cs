using StudLine.Models;
using System;
using System.Collections.Generic;

namespace StudLine.ViewModels
{
	public class NewsVM : Entity
	{
		public virtual IList<Comment> Comments { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }

		public virtual User User { get; set; }
		public int UserId { get; set; }

		public string CommentText { get; set; }
	}
}