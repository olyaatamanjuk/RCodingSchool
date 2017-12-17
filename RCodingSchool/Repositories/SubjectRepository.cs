using StudLine.Models;
using StudLine.Interfaces;

namespace StudLine.Repositories
{
	public class SubjectRepository : Repository<Subject>, ISubjectRepository
	{
		public SubjectRepository(StudLineContext context)
			: base(context)
		{
		}
	}
}