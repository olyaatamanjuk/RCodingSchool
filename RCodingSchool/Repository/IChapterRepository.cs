using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public interface IChapterRepository : IRepository<Chapter>
    {
		Chapter GetFirst();
	}
}