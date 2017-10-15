
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
			return dbContext.Topics.FirstOrDefault(e => e.ChapterId == id);
		}
    }
}