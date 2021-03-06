﻿using StudLine.Models;
using System.Collections.Generic;

namespace StudLine.Interfaces
{
	public interface ITaskRepository : IRepository<Task>
	{
		IEnumerable<Task> GetTaskListBySubjectId(int id);
		IEnumerable<DoneTask> GetDoneTasks(int taskId);
		DoneTask AddDoneTask(DoneTask doneTask);
		DoneTask GetDoneTask(int id);
		DoneTask GetDoneTaskByTaskId(int taskId, int userId);
	}
}
