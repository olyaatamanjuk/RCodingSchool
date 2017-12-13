using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Owin;
using StudLine.Hubs;
using StudLine.Interfaces;
using StudLine.Models;
using StudLine.Repositories;
using StudLine.Services;
using StudLine.UnitOW;
using System.Web;
using System.Web.Mvc;

namespace StudLine.Extensions
{
    public static class DIExtention
    {
        public static void Configure(this IAppBuilder app)
        {
            var signalrResolver = new DefaultDependencyResolver();
            var container = new UnityContainer();

            // Db context
            container.RegisterType<StudLineContext>();

            // Repositories
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IMessageRepository, MessageRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<IChapterRepository, ChapterRepository>();
            container.RegisterType<ITopicRepository, TopicRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<ITeacherRepository, TeacherRepository>();
            container.RegisterType<IGroupRepository, GroupRepository>();
            container.RegisterType<INewsRepository, NewsRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();

            // Services
            container.RegisterType<MessageService>();
            container.RegisterType<UserService>();
            container.RegisterType<SubjectService>();
            container.RegisterType<ChapterService>();
            container.RegisterType<NewsService>();
            container.RegisterType<TeacherService>();

            // Hubs
            container.RegisterType<ChatHub>();
            container.RegisterType<Connections>();

            // Dark magic
            container.RegisterType<HttpContextBase>(new InjectionFactory(x => HttpContext.Current != null ? new HttpContextWrapper(HttpContext.Current) : null));

            signalrResolver.Register(typeof(ChatHub), () => container.Resolve<ChatHub>());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            app.MapSignalR(new HubConfiguration
            {
                Resolver = signalrResolver
            });
        }
    }
}