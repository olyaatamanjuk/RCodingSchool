using Microsoft.AspNet.SignalR;
using RCodingSchool.Mapping.ModelsVM;
using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.Services;
using RCodingSchool.Session;
using System;
using System.Web.Mvc;

namespace RCodingSchool.Hubs
{
	public class ChatHub : Hub
	{

		public void Send(string message, string email)
		{
			DateTime now = DateTime.Now;
			string stringTime = now.ToString("g");
			UserRepository _userRepository = new UserRepository(new RCodingSchoolContext());
			User user = _userRepository.GetByEmail(email);
			string fullUserNAme = user.FirstName+" "+ user.LastName;
			Clients.All.broadcastMessage(fullUserNAme, message, stringTime);
		}
		public void SendPrivate(string name, string message, string connectionId)
		{
			Clients.Client(Context.ConnectionId).send(message);
		}
	}
}