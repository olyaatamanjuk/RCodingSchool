using AutoMapper;
using StudLine.Extensions;
using StudLine.Models;
using StudLine.Services;
using StudLine.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudLine.Controllers
{
	[Authorize(Roles = "Student")]
	public class MessageController : Controller
    {
		private readonly MessageService _messageService;

		public MessageController(MessageService messageService)
		{
			_messageService = messageService;
		}
		
		[HttpGet]
		public ActionResult Message(int currentMessageCount = 0)
        {
			string groupName = User.Identity.GetGroupName();
			int messageCount = currentMessageCount + 5; 
			IEnumerable<Message> messages = _messageService.GetLastMessages(messageCount, groupName);
			IEnumerable<MessageVM> messagesVM = Mapper.Map<IEnumerable<MessageVM>>(messages);
			
			return View(messagesVM);
        }
    }
}