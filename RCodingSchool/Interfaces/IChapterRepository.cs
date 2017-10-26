using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool.Interfaces
{
    public interface IChapterRepository : IRepository<Chapter>
    {
		Chapter GetFirst();
		IEnumerable<Chapter> GetListChaptersBySubjectId(int id);
	}
}