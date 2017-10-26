using System.Collections.Generic;
using RCodingSchool.Models;
using System.Linq;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
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

		public Chapter GetFirst()
		{
			return dbContext.Chapters.Include("Topics").FirstOrDefault();
		}

		public IEnumerable<Chapter> GetListChaptersBySubjectId(int id)
		{
			return dbContext.Chapters.Include("Topics").Where(x => x.SubjectId == id);
		}

        public override Chapter Get(int id)
        {
            return dbContext.Chapters.Include("Topics").Include("Subject").FirstOrDefault(x => x.Id == id);
        }
    }
}