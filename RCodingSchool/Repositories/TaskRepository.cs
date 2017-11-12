using System;
using System.Collections.Generic;
using RCodingSchool.Interfaces;
using RCodingSchool.Models;
using System.Linq;

namespace RCodingSchool.Repositories
{
	public class TaskRepository : Repository<Task>, ITaskRepository
	{
		public TaskRepository(RCodingSchoolContext context)
            : base(context)
        {
		}

		public IEnumerable<Task> GetTaskListBySubjectId(int id)
		{
			return dbContext.Tasks.Where(x => x.SubjectId == id);
		}

		public IEnumerable<DoneTask> GetDoneTasks(int taskId)
		{
			return dbContext.DoneTasks.Where(x => x.TaskId == taskId);
		}

		public DoneTask AddDoneTask(DoneTask doneTask)
		{
			return dbContext.DoneTasks.Add(doneTask);
		}

		public DoneTask GetDoneTask(int id)
		{
			return dbContext.DoneTasks.Where(x => x.Id == id).FirstOrDefault();
		}
	}
}