using StudLine.Models;
using System.Collections.Generic;

namespace StudLine.Interfaces
{
    public interface IChapterRepository : IRepository<Chapter>
    {
		Chapter GetFirst();
		IEnumerable<Chapter> GetListChaptersBySubjectId(int id);
	}
}