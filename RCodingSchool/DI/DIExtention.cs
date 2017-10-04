using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Owin;
using RCodingSchool.Hubs;
using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.Services;
using RCodingSchool.UnitOW;
using System.Web.Mvc;

namespace RCodingSchool.DI
{
    public static class DIExtention
    {
        public static void ConfigureApp(this IAppBuilder app)
        {
            var signalrResolver = new DefaultDependencyResolver();
            var container = new UnityContainer();

            // Db context
            container.RegisterType<RCodingSchoolContext>();

            // Repositories
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IMessageRepository, MessageRepository>();

            // Services
            container.RegisterType<MessageService>();
			container.RegisterType<UserService>();

			// Hubs
			container.RegisterType<ChatHub>();
			container.RegisterType<Connections>();

			signalrResolver.Register(typeof(ChatHub), () => container.Resolve<ChatHub>());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            app.MapSignalR(new HubConfiguration
            {
                Resolver = signalrResolver
            });
        }
    }
}