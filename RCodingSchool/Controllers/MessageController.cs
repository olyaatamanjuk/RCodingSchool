using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
	[Authorize]
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
			int messageCount = currentMessageCount + 5; 
			List<Message> messages = _messageService.GetLastMessages(messageCount);
			List<MessageVM> messagesVM = Mapper.Map<List<Message>, List<MessageVM>>(messages);
			
			return View(messagesVM);
        }

    }
}