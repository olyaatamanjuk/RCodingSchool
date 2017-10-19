
using RCodingSchool.Models;
using System.Linq;
using System;

namespace RCodingSchool.Repository
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(RCodingSchoolContext context)
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