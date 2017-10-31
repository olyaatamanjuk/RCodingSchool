using RCodingSchool.Models;
using RCodingSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class GroupController : Controller
    {
		private readonly TeacherService _teacherService;

		public GroupController(TeacherService teacherService)
		{
			_teacherService = teacherService;
		}
		public ActionResult Groups()
        {
			//List<Group>groups = _teacherService.GetGroupsOfTeacher(_teacherService.GetTeacherByUserId());
			// TODO: через teacher include user where user id = currentUserId
            return View();
        }
    }
}