using System.Collections.Generic;
using RCodingSchool.Models;
using System.Linq;

namespace RCodingSchool.Repository
{
    public class ChapterRepository : Repository<Chapter>, IChapterRepository
    {
        public ChapterRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public override IEnumerable<Chapter> GetAll()
        {
            return dbContext.Chapters.Include("Topics").ToList();
        }
    }
}