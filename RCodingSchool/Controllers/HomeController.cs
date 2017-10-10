using RCodingSchool.Repository;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    [Authorize]
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
            // TODO: Test
            var userId = User.Identity;

            return View();
        }
	}
}