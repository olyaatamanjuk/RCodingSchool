using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using RCodingSchool.DI;
using System;

[assembly: OwinStartup(typeof(RCodingSchool.App_Start.Startup))]
namespace RCodingSchool.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureApp();
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/home/index"),
				SlidingExpiration = false,
				ExpireTimeSpan = TimeSpan.FromDays(20)
			});
		}
    }
}