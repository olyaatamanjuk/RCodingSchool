using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RCodingSchool.App_Start.Startup))]

namespace RCodingSchool.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
