using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class MessageController : Controller
    {
		private readonly UserService _userService;
		public MessageController(UserService userService)
		{
			_userService = userService;
		}
		// GET: Message
		[Authorize(Roles = "User")]
		public ActionResult Message()
        {
			User user = _userService.GetUserByEmail(HttpContext.User.Identity.Name);
			UserVM userVM = Mapper.Map<User, UserVM>(user);
			return View(userVM);
        }
    }
}