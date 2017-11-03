using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool.Interfaces
{
	public interface ITaskRepository : IRepository<Task>
	{
		IEnumerable<Task> GetTaskListBySubjectId(int id);
	}
}
