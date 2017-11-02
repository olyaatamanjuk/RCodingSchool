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
		private readonly ITaskRepository _taskRepository;
		private readonly ITeacherRepository _teacherRepository;


		public SubjectService(ISubjectRepository subjectRepository, ITaskRepository taskRepository, ITeacherRepository teacherRepository, HttpContextBase httpContext)
			:base(httpContext)
        {
            _subjectRepository = subjectRepository;
			_taskRepository = taskRepository;
			_teacherRepository = teacherRepository;

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

		public Task TrySaveTask(TaskVM taskVM)
		{
			if(String.IsNullOrEmpty(taskVM.Name)|| String.IsNullOrEmpty(taskVM.Name))
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
				_taskRepository.Add(task);
				_taskRepository.SaveChanges();
				return task;
			}

			throw new NotImplementedException();
		}
	}
}