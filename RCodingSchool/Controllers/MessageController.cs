using RCodingSchool.Mapping.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class MessageController : Controller
    {
		// GET: Message
		//[Authorize(Roles = "User")]
		public ActionResult Message(UserVM currentUser)
        {
            return View(currentUser);
        }
    }
}