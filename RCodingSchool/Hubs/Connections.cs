using RCodingSchool.Models;
using RCodingSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Hubs
{
	public class Connections
	{
		private readonly UserService _userService;
		public readonly Dictionary<Models.User, HashSet<string>> _connections;
		public Connections(UserService userService)
		{
			_userService = userService;
		}

		public void Add(string name, string connectionId)
		{
			HashSet<string> connections;
			User user = _userService.GetUserByEmail(name);
			if (!_connections.ContainsKey(user))
			{
				connections = new HashSet<string>();
				connections.Add(connectionId);
				_connections.Add(user, connections);
			}
			else
			{
				_connections[user].Add(connectionId);
			}
		}

		public IEnumerable<string> GetConnections(string name)
		{
			HashSet<string> connections;
			User user = _userService.GetUserByEmail(name);
			if (_connections.TryGetValue(user, out connections))
			{
				return connections;
			}

			return Enumerable.Empty<string>();
		}

		public User GetUserByEmail(string name)
		{
			User user = _userService.GetUserByEmail(name);
			return user;
		}

		public void Remove(string name, string connectionId)
		{
			User user = _userService.GetUserByEmail(name);
			lock (_connections)
			{
				HashSet<string> connections;
				if (!_connections.TryGetValue(user, out connections))
				{
					return;
				}

				lock (connections)
				{
					connections.Remove(connectionId);

					if (connections.Count == 0)
					{
						_connections.Remove(user);
					}
				}
			}
		}

	}
}