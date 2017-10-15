using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public interface ITopicRepository : IRepository<Topic>
    {
		Topic GetFirstFromChapter(int id);
	}
}