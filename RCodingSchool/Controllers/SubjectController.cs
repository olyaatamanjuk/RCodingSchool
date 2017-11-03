using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Linq;
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

		public ActionResult Tasks(int? id)
		{
			List<Task> tasks = new List<Models.Task>();
			if(id == null)
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
			Task task = _subjectService.TrySaveTask(taskVM);
			int filesCount = files.Count(file => file != null && file.ContentLength > 0);

			if (!(task == null)&& filesCount>0)
			{
				_fileService.SaveFilesFromTask(task.Id, files);
			};
			return RedirectToAction("Task", new { id = task.Id });
		}

		public ActionResult Download(int id)
		{
			File file = _fileService.Get(id);

            return File(file.Location, "application/octet-stream", file.Name);
		}
	}
}