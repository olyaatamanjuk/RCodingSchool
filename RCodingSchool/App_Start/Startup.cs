using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using RCodingSchool.Extensions;
using System;

[assembly: OwinStartup(typeof(RCodingSchool.App_Start.Startup))]
namespace RCodingSchool.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                SlidingExpiration = false,
                ExpireTimeSpan = TimeSpan.FromDays(20)
            });

            app.Configure();
        }
    }
}