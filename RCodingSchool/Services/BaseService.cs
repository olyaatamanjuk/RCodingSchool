using System.Linq;
using System.Security.Claims;
using System.Web;

namespace StudLine.Services
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

        public string GroupName
        {
            get
            {
                return (_httpContext.User.Identity as ClaimsIdentity).Claims.First(x => x.Type == "groupName").Value;
            }
        }
    }
}