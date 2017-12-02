using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using RCodingSchool.ViewModels;
using System.Web;

namespace RCodingSchool.Services
{
	public class SubjectService : BaseService
	{
		private readonly ISubjectRepository _subjectRepository;
		private readonly IUserRepository _userRepository;
		private readonly ITaskRepository _taskRepository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly FileService _fileService;

		public SubjectService(ISubjectRepository subjectRepository, ITaskRepository taskRepository, ITeacherRepository teacherRepository,
			FileService fileService, IUserRepository userRepository, HttpContextBase httpContext)
			: base(httpContext)
		{
			_subjectRepository = subjectRepository;
			_taskRepository = taskRepository;
			_teacherRepository = teacherRepository;
			_fileService = fileService;
			_userRepository = userRepository;
		}

		public List<Subject> GetList()
		{
			return _subjectRepository.GetAll().ToList<Subject>();
		}

		public List<Task> GetTaskList()
		{
			return _taskRepository.GetAll().ToList<Task>();
		}

		public Task GetTaskById(int id)
		{
			return _taskRepository.Get(id);
		}

		public List<Task> GetTaskListBySubjectId(int id)
		{
			return _taskRepository.GetTaskListBySubjectId(id).ToList();
		}

		public Task TrySaveTask(TaskVM taskVM, IEnumerable<HttpPostedFileBase> files)
		{
			if (String.IsNullOrEmpty(taskVM.Name) || String.IsNullOrEmpty(taskVM.Name))
			{
				return null;
			}
			else
			{
				Task task = new Task();
				task.Name = taskVM.Name;
				task.Text = taskVM.Text;
				task.SubjectId = taskVM.SubjectId;
				task.TeacherId = _teacherRepository.GetTeacherByUserId(UserId).Id;
				var newEntity = _taskRepository.Add(task);
				_taskRepository.SaveChanges();

				_fileService.SaveTaskFiles(newEntity.Id, files);

				return task;
			}
		}

		public DoneTask TrySaveDoneTask(DoneTaskVM doneTaskVM, IEnumerable<HttpPostedFileBase> files)
		{
			bool isNew = false;
			DoneTask task = _taskRepository.GetDoneTask(doneTaskVM.Id);

			if (task == null)
			{
				 task = new DoneTask();
				isNew = true;
			}
				
			task.Text = doneTaskVM.Text;
			task.TaskId = doneTaskVM.TaskId;
			task.StudentId = _userRepository.GetActualUserById<Student>(UserId).Id;
			task.Mark = doneTaskVM.Mark;
			task.Comment = doneTaskVM.Comment;
			task.Finished = doneTaskVM.Finished;
			if (isNew)
			{
				 _taskRepository.AddDoneTask(task);
			}
			_taskRepository.SaveChanges();

			_fileService.SaveDoneTaskFiles(task.TaskId, task.Id, files);

			return task;
		}

		public DoneTask GetDoneTask(int id)
		{
			return _taskRepository.GetDoneTask(id);
		}

		public bool TryChangeDoneTask(DoneTaskVM doneTaskVM)
		{
			DoneTask doneTask = _taskRepository.GetDoneTask(doneTaskVM.Id);

			if (!doneTaskVM.Finished && String.IsNullOrWhiteSpace(doneTaskVM.Comment))
			{
				return false;
			}
			else
			{
				doneTask.Mark = doneTaskVM.Mark;
				doneTask.Finished = doneTaskVM.Finished;
				doneTask.Comment = doneTaskVM.Comment;
				_taskRepository.SaveChanges();
				return true;
			}
		}

		public DoneTask GetDoneTaskByTaskId(int taskId)
		{
			return _taskRepository.GetDoneTaskByTaskId(taskId, UserId);
		}
	}
}