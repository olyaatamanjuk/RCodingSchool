using RCodingSchool.App_Start;
using RCodingSchool.Extensions;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;

namespace RCodingSchool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var bla = new Services.RService().AnalizeDataByRange(new System.DateTime(2000, 07, 10), System.DateTime.Now);
            //if (File.Exists("conf.txt"))
            //{
            //    AreaRegistration.RegisterAllAreas();
            //    RouteConfig.RegisterRoutes(RouteTable.Routes);
            //    Database.SetInitializer(new MyContextInitializer());
            //    BundleConfig.RegisterBundles(BundleTable.Bundles);
            //    AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            //}
        }
    }
}
