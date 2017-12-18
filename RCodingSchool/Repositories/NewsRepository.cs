using StudLine.Models;
using System.Linq;
using StudLine.Interfaces;

namespace StudLine.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(StudLineContext context)
            : base(context)
        {
        }

		public override News Get(int id)
		{
			return dbContext.News.Include("User").Include("Comments").FirstOrDefault(x => x.Id == id);
		}
	}
}