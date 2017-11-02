using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RCodingSchool.Services
{
    public class SubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
		private readonly ITaskRepository _taskRepository;


		public SubjectService(ISubjectRepository subjectRepository, ITaskRepository taskRepository)
        {
            _subjectRepository = subjectRepository;
			_taskRepository = taskRepository;

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
	}
}