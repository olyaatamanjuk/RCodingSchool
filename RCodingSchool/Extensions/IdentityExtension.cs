using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace StudLine.Extensions
{
	public static class IdentityExtensions
	{
		public static string GetFullName(this IIdentity identity)
		{
			var claim = ((ClaimsIdentity)identity).FindFirst("fullName");
			return (claim != null) ? claim.Value : string.Empty;
		}

		public static string GetGroupName(this IIdentity identity)
		{
			var claim = ((ClaimsIdentity)identity).FindFirst("groupName");
			return (claim != null) ? claim.Value : string.Empty;
		}
	}
}