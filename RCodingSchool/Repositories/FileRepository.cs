using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Linq;

namespace RCodingSchool.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public IQueryable<File> GetByTopicId(int topicId)
        {
            return dbContext.Set<File>().Where(x => x.TopicId == topicId);
        }

        public override void Remove(File entity)
        {
            System.IO.File.Delete(entity.Location);
            base.Remove(entity);
        }
    }
}