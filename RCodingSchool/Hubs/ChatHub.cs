using Microsoft.AspNet.SignalR;
using RCodingSchool.Services;
using System;

namespace RCodingSchool.Hubs
{
	public class ChatHub : Hub
	{
        private readonly MessageService _messageService;

        public ChatHub(MessageService messageService)
        {
            _messageService = messageService;
        }

        public void Send(string message, string email)
		{
			DateTime now = DateTime.Now;
			string stringTime = now.ToString("g");
			//string fullUserNAme = user.FirstName+" "+ user.LastName;
			Clients.All.broadcastMessage("Bla", message, stringTime);
		}

		public void SendPrivate(string name, string message, string connectionId)
		{
			Clients.Client(Context.ConnectionId).send(message);
		}
	}
}