using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public class ChapterRepository :Repository<Chapter>, IChapterRepository
    {
        public ChapterRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public void Test()
        {
            var chapter = dbContext.Chapters.Add(new Chapter { }); // chapter.id = -3456346;
            dbContext.SaveChanges();
            // chapter.id = 23;
        }
    }
}