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
                new Claim("id", user.Id.ToString()),
                //new Claim("fullname", user.Id.ToString())
            };

            if (user.isAdmin)
                claims.Add(new Claim(ClaimTypes.Role, Roles.Admin));
            else
                claims.Add(new Claim(ClaimTypes.Role, Roles.User));

            var identity = new ClaimsIdentity(claims.ToArray<Claim>(), DefaultAuthenticationTypes.ApplicationCookie);
            HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = userVM.RememberMe }, identity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

		[HttpGet]
		public ActionResult Register()
		{
			List<Group> groupList = _userService.GetGroups();
			List<string> groupNames = new List<string>();
			foreach (var group in groupList)
			{
				groupNames.Add(group.Name);
			}
			SelectList groups = new SelectList(groupNames,"Name");
			ViewBag.Groups = groups;
			return View();
		}
		[HttpPost]
		public ActionResult Register(UserVM userVM)
		{
			if (_userService.CheckValidation(userVM))
			{
				User user = _userService.RegisterNew(userVM);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("credentials", "Некоректно введені дані.");
				return View();
			}
		}
	}
}