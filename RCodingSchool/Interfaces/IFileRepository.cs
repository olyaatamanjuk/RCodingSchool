using StudLine.Models;
using System.Linq;

namespace StudLine.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        IQueryable<File> GetByTopicId(int topicId);
    }
}
