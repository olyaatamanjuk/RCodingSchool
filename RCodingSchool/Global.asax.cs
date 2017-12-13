using StudLine.App_Start;
using StudLine.Extensions;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;

namespace StudLine
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
				AreaRegistration.RegisterAllAreas();
				RouteConfig.RegisterRoutes(RouteTable.Routes);
				Database.SetInitializer(new MyContextInitializer());
				BundleConfig.RegisterBundles(BundleTable.Bundles);
				AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
		}
    }
}
