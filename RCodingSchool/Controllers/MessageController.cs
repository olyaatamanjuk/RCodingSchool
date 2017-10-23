using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
	[Authorize]
	public class MessageController : Controller
    {
		private readonly UserService _userService;
		public MessageController(UserService userService)
		{
			_userService = userService;
		}
		
		[HttpGet]
		public ActionResult Message()
        {
			User user = _userService.GetUserByEmail(HttpContext.User.Identity.Name);
			UserVM userVM = Mapper.Map<User, UserVM>(user);
			return View(userVM);
        }
    }
}