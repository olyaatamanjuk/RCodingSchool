using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using RCodingSchool.Interfaces;
using Owin;
using RCodingSchool.Hubs;
using RCodingSchool.Models;
using RCodingSchool.Repositories;
using RCodingSchool.Services;
using RCodingSchool.UnitOW;
using System.Web;
using System.Web.Mvc;

namespace RCodingSchool.Extensions
{
    public static class DIExtention
    {
        public static void Configure(this IAppBuilder app)
        {
            var signalrResolver = new DefaultDependencyResolver();
            var container = new UnityContainer();

            // Db context
            container.RegisterType<RCodingSchoolContext>();

            // Repositories
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IMessageRepository, MessageRepository>();
            container.RegisterType<IMessageGroupRepository, MessageGroupRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<IChapterRepository, ChapterRepository>();
            container.RegisterType<ITopicRepository, TopicRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<ITeacherRepository, TeacherRepository>();
            container.RegisterType<IGroupRepository, GroupRepository>();
			container.RegisterType<INewsRepository, NewsRepository>();
			container.RegisterType<ICommentRepository, CommentRepository>();

			// Services
			container.RegisterType<MessageService>();
            container.RegisterType<UserService>();
            container.RegisterType<SubjectService>();
            container.RegisterType<ChapterService>();
			container.RegisterType<NewsService>();

			// Hubs
			container.RegisterType<ChatHub>();
            container.RegisterType<Connections>();

            // Dark magic
            container.RegisterType<HttpContextBase>(new InjectionFactory(x => new HttpContextWrapper(HttpContext.Current)));

            signalrResolver.Register(typeof(ChatHub), () => container.Resolve<ChatHub>());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            app.MapSignalR(new HubConfiguration
            {
                Resolver = signalrResolver
            });
        }
    }
}