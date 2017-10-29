using RCodingSchool.Interfaces;
using RCodingSchool.Models;

namespace RCodingSchool.Repositories
{
	public class TaskRepository : Repository<Task>, ITaskRepository
	{
		public TaskRepository(RCodingSchoolContext context)
            : base(context)
        {
		}
	}
}