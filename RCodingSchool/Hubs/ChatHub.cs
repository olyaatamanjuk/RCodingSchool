using Microsoft.AspNet.SignalR;

namespace RCodingSchool.Hubs
{
	public class ChatHub : Hub
	{

		public void Send(string name, string message)
		{
			// Call the broadcastMessage method to update clients.
			Clients.All.broadcastMessage(name, message);
		}
		public void SendPrivate(string name, string message, string connectionId)
		{
			Clients.Client(Context.ConnectionId).send(message);

		}
	}
}