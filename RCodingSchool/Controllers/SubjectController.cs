using AutoMapper;
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
		private readonly FileService _fileService;
		public SubjectController(SubjectService subjectService, FileService fileService)
        {
            _subjectService = subjectService;
			_fileService = fileService;
        }

        public ActionResult Subject()
        {
            List<Subject> subjects = _subjectService.GetList();
            List <SubjectVM> subjectsVM= Mapper.Map<List<Subject>, List<SubjectVM>>(subjects);
            return View(subjectsVM);
        }

		public ActionResult Tasks()
		{
			List<Task> tasks = _subjectService.GetTaskList();
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
		public ActionResult CreateTask()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateTask(IEnumerable<HttpPostedFileBase> files, TaskVM taskVM)
		{
			taskVM.SubjectId = 1;
			Task task = _subjectService.TrySaveTask(taskVM);
			if (!(task == null) )
			{
				_fileService.SaveFilesFromTask(task.Id, files);
			};
			return RedirectToAction("Task", new { id = task.Id });
		}
	}
}