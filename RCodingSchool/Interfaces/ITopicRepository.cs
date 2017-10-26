using RCodingSchool.Models;

namespace RCodingSchool.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
		Topic GetFirstFromChapter(int id);
	}
}