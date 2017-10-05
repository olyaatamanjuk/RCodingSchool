using Microsoft.AspNet.SignalR;
using RCodingSchool.Models;
using RCodingSchool.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace RCodingSchool.Hubs
{
	//[Authorize(Roles = "User")]
	public class ChatHub : Hub
	{
        private readonly MessageService _messageService;
		private readonly Connections _connections;


		public ChatHub(MessageService messageService)
        {
            _messageService = messageService;
		}

		//public override Task OnConnected()
		//{
		//	string name = Context.User.Identity.Name;

		//	_connections.Add(name, Context.ConnectionId);

		//	return base.OnConnected();
		//}

		//public override Task OnDisconnected(bool stopCalled)
		//{
		//	string name = Context.User.Identity.Name;

		//	_connections.Remove(name, Context.ConnectionId);

		//	return base.OnDisconnected(stopCalled);
		//}

		//public override Task OnReconnected()
		//{
		//	string name = Context.User.Identity.Name;

		//	if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
		//	{
		//		_connections.Add(name, Context.ConnectionId);
		//	}

		//	return base.OnReconnected();
		//}

		public void Send(string message, string email)
		{
			DateTime now = DateTime.Now;
			string stringTime = now.ToString("g");
			User user = _connections.GetUserByEmail(email);
			string fullUserNAme = user.FirstName+" "+ user.LastName;
			Clients.All.broadcastMessage(fullUserNAme, message, stringTime);
		}

		public void SendPrivate(string name, string message, string connectionId)
		{
			Clients.Client(Context.ConnectionId).send(message);
		}
	}
}