using Microsoft.AspNet.SignalR;
using RCodingSchool.Models;
using RCodingSchool.Services;
using System;
using System.Linq;
using System.Security.Claims;

namespace RCodingSchool.Hubs
{
    //[Authorize(Roles = "User")]
    public class ChatHub : Hub
    {
        private readonly MessageService _messageService;
        private readonly UserService _userService;
        private static readonly Connections _connections;

        static ChatHub()
        {
            _connections = new Connections();
        }

        public ChatHub(MessageService messageService, UserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            _connections.Add(Context.User.Identity.Name, Context.ConnectionId);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

        public void Send(string message, string date)
        {
            var newDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(long.Parse(date));

            _messageService.SaveMessage(message, new MessageGroup { Name = "General" }, new User { Id = UserId }, newDate);

            Clients.All.broadcastMessage(Context.User.Identity.Name, message, date);
        }

        public void SendPrivate(string name, string message, string connectionId)
        {
            Clients.Client(Context.ConnectionId).send(message);
        }

        public int UserId
        {
            get
            {
                return int.Parse((new ClaimsIdentity(Context.User.Identity)).Claims.FirstOrDefault(x => x.Type.Equals("id")).Value);
            }
            set { }
        }
    }
}