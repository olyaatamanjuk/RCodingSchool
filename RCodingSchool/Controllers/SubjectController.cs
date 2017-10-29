using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
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
        // GET: Subject
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

	}
}