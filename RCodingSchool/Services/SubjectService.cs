﻿using RCodingSchool.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using RCodingSchool.ViewModels;
using System.Web;
using RCodingSchool.UnitOW;

namespace RCodingSchool.Services
{
    public class SubjectService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FileService _fileService;

        public SubjectService(IUnitOfWork unitOfWork, FileService fileService, HttpContextBase httpContext)
            : base(httpContext)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public List<Subject> GetList()
        {
            return _unitOfWork.SubjectRepository.GetAll().ToList<Subject>();
        }

		public Subject Get(int id)
		{
			return _unitOfWork.SubjectRepository.Get(id);
		}

		public List<Task> GetTaskList()
        {
            return _unitOfWork.TaskRepository.GetAll().ToList<Task>();
        }

        public Task GetTaskById(int id)
        {
            return _unitOfWork.TaskRepository.Get(id);
        }

        public List<Task> GetTaskListBySubjectId(int id)
        {
            return _unitOfWork.TaskRepository.GetTaskListBySubjectId(id).ToList();
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
                task.TeacherId = _unitOfWork.TeacherRepository.GetTeacherByUserId(UserId).Id;
                var newEntity = _unitOfWork.TaskRepository.Add(task);
                _unitOfWork.SaveChanges();

                _fileService.SaveTaskFiles(newEntity.Id, files);

                return task;
            }
        }

        public DoneTask TrySaveDoneTask(DoneTaskVM doneTaskVM, IEnumerable<HttpPostedFileBase> files)
        {
            bool isNew = false;
            DoneTask task = _unitOfWork.TaskRepository.GetDoneTask(doneTaskVM.Id);

            if (task == null)
            {
                task = new DoneTask();
                isNew = true;
            }

            task.Text = doneTaskVM.Text;
            task.TaskId = doneTaskVM.TaskId;
            task.StudentId = _unitOfWork.UserRepository.GetActualUserById<Student>(UserId).Id;
            task.Mark = doneTaskVM.Mark;
            task.Comment = doneTaskVM.Comment;
            task.Finished = doneTaskVM.Finished;
            if (isNew)
            {
                _unitOfWork.TaskRepository.AddDoneTask(task);
            }
            _unitOfWork.SaveChanges();

            _fileService.SaveDoneTaskFiles(task.TaskId, task.Id, files);

            return task;
        }

        public DoneTask GetDoneTask(int id)
        {
            return _unitOfWork.TaskRepository.GetDoneTask(id);
        }

        public bool TryChangeDoneTask(DoneTaskVM doneTaskVM)
        {
            DoneTask doneTask = _unitOfWork.TaskRepository.GetDoneTask(doneTaskVM.Id);

            if (!doneTaskVM.Finished && String.IsNullOrWhiteSpace(doneTaskVM.Comment))
            {
                return false;
            }
            else
            {
                doneTask.Mark = doneTaskVM.Mark;
                doneTask.Finished = doneTaskVM.Finished;
                doneTask.Comment = doneTaskVM.Comment;
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public DoneTask GetDoneTaskByTaskId(int taskId)
        {
            return _unitOfWork.TaskRepository.GetDoneTaskByTaskId(taskId, UserId);
        }

		public bool TrySaveCalendar(SubjectVM subjectVM)
		{
			if (String.IsNullOrWhiteSpace(subjectVM.Calendar))
			{
				return false;
			}
			else if (!(subjectVM.Calendar.Contains(".calendar.google.com")))
			{
				return false;
			}
			else
			{
				Subject subject = Get(subjectVM.Id);
				subject.Calendar = subjectVM.Calendar;
				_unitOfWork.SaveChanges();
				return true;
			}
		}

	}
}