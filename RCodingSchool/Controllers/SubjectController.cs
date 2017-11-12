﻿using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public ActionResult Subject()
        {
            List<Subject> subjects = _subjectService.GetList();
            List<SubjectVM> subjectsVM = Mapper.Map<List<Subject>, List<SubjectVM>>(subjects);
            return View(subjectsVM);
        }

        public ActionResult Tasks(int? id)
        {
            List<Task> tasks = new List<Task>();
            if (id == null)
            {
                tasks = _subjectService.GetTaskList();
            }
            else
            {
                tasks = _subjectService.GetTaskListBySubjectId((int)id);
            }
            List<TaskVM> tasksVM = Mapper.Map<List<Task>, List<TaskVM>>(tasks);
            return View(tasksVM);
        }

        public ActionResult Task(int id)
        {
            Task task = _subjectService.GetTaskById(id);
            TaskVM taskVM = Mapper.Map<Task, TaskVM>(task);
            return View(taskVM);
        }

        [HttpGet]
        public ActionResult CreateTask(int id)
        {
            TaskVM taskVM = new TaskVM();
            taskVM.SubjectId = id;
            return View(taskVM);
        }

        [HttpPost]
        public ActionResult CreateTask(IEnumerable<HttpPostedFileBase> files, TaskVM taskVM)
        {
            Task task = _subjectService.TrySaveTask(taskVM, files);
            
            return RedirectToAction("Task", new { id = task.Id });
        }

		[HttpGet]
		public ActionResult SolveTask(int taskId)
		{
			DoneTaskVM doneTaskVM = new DoneTaskVM();
			doneTaskVM.TaskId = taskId;
			Task task = _subjectService.GetTaskById(taskId);
			doneTaskVM.Task = task;
			return View(doneTaskVM);
		}

		[HttpPost]
		public ActionResult SolveTask(IEnumerable<HttpPostedFileBase> files, DoneTaskVM doneTaskVM)
		{
			DoneTask task = _subjectService.GetDoneTask( _subjectService.TrySaveDoneTask(doneTaskVM, files).Id);
			return RedirectToAction("Task", new { id = task.TaskId });
		}

		[HttpGet]
		public ActionResult DoneTask(int doneTaskId)
		{
			DoneTaskVM doneTaskVM = Mapper.Map<DoneTaskVM>(_subjectService.GetDoneTask(doneTaskId));
			return View(doneTaskVM);
		}

		[HttpPost]
		public ActionResult DoneTask(DoneTaskVM doneTask)
		{
			_subjectService.EvaluateTask(doneTask.Id, doneTask.Mark);
			return RedirectToAction("Task", new { id = doneTask.TaskId });
		}
	}
}