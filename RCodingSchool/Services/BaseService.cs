using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace RCodingSchool.Services
{
	public abstract class BaseService
	{
		protected readonly HttpContextBase _httpContext;

		public BaseService( HttpContextBase httpContext)
		{
			_httpContext = httpContext;
		}

		public int UserId
		{
			get
			{
				return int.Parse(((ClaimsIdentity)_httpContext.User.Identity).Claims.FirstOrDefault(x => x.Type == "id").Value);
			}
			private set { }
		}
	}
}