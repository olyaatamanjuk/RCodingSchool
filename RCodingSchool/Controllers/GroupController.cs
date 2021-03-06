﻿using AutoMapper;
using StudLine.Models;
using StudLine.Services;
using StudLine.ViewModels;
using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace StudLine.Controllers
{
	[Authorize]
	public class GroupController : Controller
	{
		private readonly TeacherService _teacherService;

		public GroupController(TeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		public ActionResult Groups(bool myGroups = true)
		{
			List<Group> groups = new List<Group>();
			if (myGroups)
			{
				groups = _teacherService.GetTeacherGroups();
			}
			else
			{
				groups = _teacherService.GetAllGroups();
			}
			GroupsVM groupsVM = new GroupsVM();
			groupsVM.GroupList = Mapper.Map<List<Group>, List<GroupVM>>(groups);
			groupsVM.MyGroups = myGroups;
			return View(groupsVM);
		}

		[HttpPost]
		public ActionResult Groups(GroupsVM groupsVM)
		{
			if (!(String.IsNullOrEmpty(groupsVM.NewGroupName)))
			{
				_teacherService.CreateGroup(groupsVM.NewGroupName);
				return RedirectToAction("Groups", new { myGroups = groupsVM.MyGroups });
			}
			else
			{
				return View();
			}
		}

		public ActionResult RemoveGroup (int id, bool myGroups)
		{
			_teacherService.DeleteGroup(id);
			return RedirectToAction("Groups", myGroups);
		}

		[HttpGet]
		public ActionResult Teachers()
		{
			List <Teacher> teachers = _teacherService.GetAllTeachers();
			List <TeacherVM > teachersVM = Mapper.Map<List<TeacherVM>>(teachers);

			return View(teachersVM);
		}
	}
}