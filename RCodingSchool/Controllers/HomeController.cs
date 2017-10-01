using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using RCodingSchool.Mapping.ModelsVM;
using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.Session;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class HomeController : Controller
    {
		private readonly IUserRepository _userRepository;

		public HomeController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(UserVM userVM)
		{
			User user = _userRepository.GetByCredentials(userVM.Email, userVM.Password);
			if (user == null)
			{
				ModelState.AddModelError("credentials", "Invalid username or password");
				return View();
			}

			SessionManager.CurentUserContext = Mapper.Map<User, UserContext>(user);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            if (SessionManager.CurentUserContext.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, Roles.Admin));
            else
                claims.Add(new Claim(ClaimTypes.Role, Roles.User));

			var identity = new ClaimsIdentity(claims.ToArray<Claim>(), DefaultAuthenticationTypes.ApplicationCookie);
			HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = userVM.RememberMe }, identity);
			userVM = Mapper.Map<User, UserVM>(user);

			return RedirectToAction("Message", "Message", userVM );
		}

	}
}