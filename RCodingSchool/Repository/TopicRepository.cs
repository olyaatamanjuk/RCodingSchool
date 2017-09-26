using RCodingSchool.EF;
using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}