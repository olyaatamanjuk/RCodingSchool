using StudLine.Models;
using System.Linq;
using StudLine.Interfaces;

namespace StudLine.Repositories
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(StudLineContext context)
            : base(context)
        {
        }

		public Topic GetFirstFromChapter(int id)
		{
			return dbContext.Topics.Include("Chapter").FirstOrDefault(e => e.ChapterId == id);
		}

        public override Topic Get(int id)
        {
            return dbContext.Topics.Include("Chapter").FirstOrDefault(x => x.Id == id);
        }
    }
}