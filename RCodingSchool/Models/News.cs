using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
	public class News : Entity
	{
		public virtual ICollection<Comment> Comments { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }

		[ForeignKey("NewsAuthorId")]
		public virtual Teacher NewsAuthor { get; set; }
		[ForeignKey("NewsAuthor")]
		public int NewsAuthorId { get; set; }
	}
}