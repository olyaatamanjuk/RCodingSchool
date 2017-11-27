using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using RCodingSchool.Common;
using System;
using AutoMapper;
using OfficeOpenXml;
using System.Web.Helpers;
using System.Security.Cryptography;

namespace RCodingSchool.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _userService;

		public AccountController(UserService userService)
		{
			_userService = userService;
		}

		public ActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		public ActionResult Login(UserVM userVM)
		{
			if (!_userService.TryLogin(userVM, out User user))
			{
				ModelState.AddModelError("credentials", "Невірний логін або пароль.");
				return View();
			}

			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Email),
				new Claim("id", user.Id.ToString())
                //new Claim("fullname", user.Id.ToString())
            };

			if (!(user.IsActive))
			{
				claims.Add(new Claim(ClaimTypes.Role, Roles.User));
			}
			else if (user.isAdmin)
			{
				claims.Add(new Claim(ClaimTypes.Role, Roles.Admin));
			}
			else if (_userService.IsTeacher(user.Id))
			{
				claims.Add(new Claim(ClaimTypes.Role, Roles.Teacher));
			}
			else
			{
				claims.Add(new Claim(ClaimTypes.Role, Roles.Student));
				claims.Add(new Claim("groupName", _userService.GetActualUserById<Student>(user.Id).Group.Name));
			}

			var identity = new ClaimsIdentity(claims.ToArray<Claim>(), DefaultAuthenticationTypes.ApplicationCookie);
			HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = userVM.RememberMe }, identity);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult Logout()
		{
			HttpContext.GetOwinContext().Authentication.SignOut();

			return RedirectToAction("Login", "Account");
		}

		[HttpGet]
		public ActionResult Register()
		{
			List<Group> groupList = _userService.GetGroups();
			UserVM userVM = new UserVM();
			userVM.Categories = groupList.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Name
			});
			return View(userVM);
		}

		[HttpPost]
		public ActionResult Register(UserVM userVM)
		{
			if (_userService.CheckValidation(userVM))
			{
				User user = _userService.RegisterNew(userVM);
				//return RedirectToAction("Index", "Home"); // Change
				return null;
			}
			else
			{
				ModelState.AddModelError("credentials", "Некоректно введені дані.");
				return View();
			}
		}

		[HttpGet]
		public ActionResult EditAccount()
		{
			User user = _userService.Get(_userService.UserId);
			UserVM userVM =Mapper.Map<UserVM>(user);
			userVM.Password = ""; 
			return View(userVM);
		}

		[HttpPost]
		public ActionResult EditAccount(UserVM userVM)
		{
			if (_userService.CheckValidation(userVM, true))
			{
				if (_userService.TryEditUser(userVM))
				{
					return RedirectToAction("EditAccount");
				}
				else
				{
					ModelState.AddModelError("validValues", "При збереженні відбулась помилка, спробуйте знову");
					return View();
				}
			}
			else
			{
				ModelState.AddModelError("validValues", "Некоректно введені дані.");
				return View();
			}
		}

		[HttpGet]
		public ActionResult RegisterConfirm(Guid registerCode)
		{
			_userService.FinishRegister(registerCode);

			return RedirectToAction("Login", "Account");
		}
		[HttpGet]
		public ActionResult Users()
		{
			UserListsVM userLists = new UserListsVM();
			userLists.NoActiveStudents = Mapper.Map<List<Student>, List<StudentVM>>(_userService.GetStudents(false));
			userLists.NoActiveTeachers = Mapper.Map<List<Teacher>, List<TeacherVM>>(_userService.GetTeachers(false));
			userLists.Students = Mapper.Map<List<Student>, List<StudentVM>>(_userService.GetStudents(true));
			userLists.Teachers = Mapper.Map<List<Teacher>, List<TeacherVM>>(_userService.GetTeachers(true));

			List<Group> groupList = _userService.GetGroups();

			userLists.Categories = groupList.Select(x => new SelectListItem
			{
				Value = x.Id.ToString(),
				Text = x.Name
			});

			return View(userLists);
		}
		[HttpPost]
		public ActionResult NoActiveStudents(UserListsVM userLists)
		{
			_userService.SaveStudentChanges(userLists.NoActiveStudents);
			return RedirectToAction("Users", "Account");
		}

		[HttpPost]
		public ActionResult ActiveStudents(UserListsVM userLists)
		{
			_userService.SaveStudentChanges(userLists.Students);
			return RedirectToAction("Users", "Account"); ;
		}

		[HttpPost]
		public ActionResult NoActiveTeachers(UserListsVM userLists)
		{
			_userService.SaveTeacherChanges(userLists.NoActiveTeachers);
			return RedirectToAction("Users", "Account");
		}

		[HttpPost]
		public ActionResult ActiveTeachers(UserListsVM userLists)
		{
			_userService.SaveTeacherChanges(userLists.Teachers);
			return RedirectToAction("Users", "Account");
		}

		[HttpGet]
		public ActionResult LoadUsers()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LoadUsers(HttpPostedFileBase file, LoadUsersVM loadUsers)
		{
			if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
			{
				if (_userService.TrySaveUsersFromFile(file, loadUsers.isItTeachers))
				{
					return RedirectToAction("Users", "Account");
				}
				else
				{
					ModelState.AddModelError("validValues", "Некоректно введені дані.");
					return View();
				}
			}
			else
			{
				ModelState.AddModelError("validValues", "Ви не обрали файл.");
				return View();
			}
		}
	}
}