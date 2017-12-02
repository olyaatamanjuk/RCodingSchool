using Microsoft.AspNet.SignalR;
using RCodingSchool.Extensions;
using RCodingSchool.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RCodingSchool.Hubs
{
    [Authorize(Roles = "Student")]
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

        public override async Task OnConnected()
        {
            await Groups.Add(Context.ConnectionId, GroupName);

            _connections.Add(Context.User.Identity.Name, Context.ConnectionId);

            await base.OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            await Groups.Remove(Context.ConnectionId, GroupName);

            await base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
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
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            var newDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(long.Parse(date));

            Clients.Group(GroupName).broadcastMessage(Context.User.Identity.GetFullName(), message, date);

            _messageService.SaveMessage(message, newDate);
        }

        public void SendPrivate(string name, string message, string connectionId)
        {
            Clients.Client(Context.ConnectionId).send(message);
        }

        public string GroupName
        {
            get
            {
                return (Context.User.Identity as ClaimsIdentity).Claims.First(x => x.Type == "groupName").Value;
            }
        }
    }
}