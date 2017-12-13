using StudLine.Models;
using System.Linq;
using StudLine.Interfaces;

namespace StudLine.Repositories
{
	public class CommentRepository : Repository<Comment>, ICommentRepository
	{
		public CommentRepository(StudLineContext context)
            : base(context)
        {
		}
		public override Comment Get(int id)
		{
			return dbContext.Comments.Include("User").FirstOrDefault(x => x.Id == id);
		}
	}
}