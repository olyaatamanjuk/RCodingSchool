using StudLine.Models;

namespace StudLine.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
		Topic GetFirstFromChapter(int id);
	}
}