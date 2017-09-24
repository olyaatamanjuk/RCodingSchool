using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Session
{
	public static class SessionManager
	{
		private static void SetSessionData<T>(string key, object value) where T : class
		{
			HttpContext.Current.Session[key] = value;
		}

		private static T GetSessionData<T>(string key) where T : class
		{
			var value = HttpContext.Current.Session[key];
			if (value != null && value is T)
				return value as T;
			else
				return null;
		}

		public static UserContext CurentUserContext
		{
			get { return GetSessionData<UserContext>(MVCManager.SessionData.UserContext); }
			set { SetSessionData<UserContext>(MVCManager.SessionData.UserContext, value); }
		}
	}
}