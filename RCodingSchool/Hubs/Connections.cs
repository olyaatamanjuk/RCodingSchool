﻿using RCodingSchool.Models;
using RCodingSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Hubs
{
	public class Connections
	{
		public  Dictionary<string, HashSet<string>> _connections;
		public int Count
		{
			get
			{
				return _connections.Count;
			}
		}
		public Connections()
		{
			_connections = new Dictionary<string, HashSet<string>>();
		}

		public void Add(string key, string connectionId)
		{
			lock (_connections)
			{
				HashSet<string> connections;
				if (!_connections.TryGetValue(key, out connections))
				{
					connections = new HashSet<string>();
					_connections.Add(key, connections);
				}

				lock (connections)
				{
					connections.Add(connectionId);
				}
			}
		}

		public IEnumerable<string> GetConnections(string key)
		{
			HashSet<string> connections;
			if (_connections.TryGetValue(key, out connections))
			{
				return connections;
			}

			return Enumerable.Empty<string>();
		}

		public void Remove(string key, string connectionId)
		{
			lock (_connections)
			{
				HashSet<string> connections;
				if (!_connections.TryGetValue(key, out connections))
				{
					return;
				}

				lock (connections)
				{
					connections.Remove(connectionId);

					if (connections.Count == 0)
					{
						_connections.Remove(key);
					}
				}
			}
		}
	}
}