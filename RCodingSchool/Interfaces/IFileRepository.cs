using RCodingSchool.Models;
using System.Linq;

namespace RCodingSchool.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        IQueryable<File> GetByTopicId(int topicId);
    }
}
