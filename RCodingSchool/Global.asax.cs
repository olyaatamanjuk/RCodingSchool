﻿using RCodingSchool.Extensions;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace RCodingSchool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new MyContextInitializer());
			AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }
    }
}
