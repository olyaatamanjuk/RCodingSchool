using RCodingSchool.Mapping.ModelsVM;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class MessageController : Controller
    {
		// GET: Message
		[Authorize(Roles = "User")]
		public ActionResult Message(UserVM currentUser)
        {
            return View(currentUser);
        }
    }
}