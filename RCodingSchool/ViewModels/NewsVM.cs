using RCodingSchool.Models;
using System;
using System.Collections.Generic;

namespace RCodingSchool.ViewModels
{
	public class NewsVM : Entity
	{
		public virtual IList<Comment> Comments { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public int NewsAuthorId { get; set; }

		public string CommentText { get; set; }
	}
}