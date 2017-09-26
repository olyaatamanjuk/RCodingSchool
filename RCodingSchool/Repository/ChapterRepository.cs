using RCodingSchool.EF;
using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public class ChapterRepository :Repository<Chapter>, IChapterRepository
    {
        public ChapterRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}