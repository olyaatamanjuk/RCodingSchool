using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool.Repository
{
    public interface IChapterRepository : IRepository<Chapter>
    {
		Chapter GetFirst();
		IEnumerable<Chapter> GetListChaptersBySubjectId(int id);
	}
}