using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using RCodingSchool.EF;
using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.UnitOW;
using System.Data.Entity;



namespace RCodingSchool.DI
{
	public class WebTypeResolver : IWebTypeResolver
	{
		public void RegisterType(IUnityContainer container)
		{
			container.RegisterType<DbContext, RCodingSchoolContext>(new InjectionConstructor());
			container.RegisterType<IUnitOfWork, UnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
			/*container.RegisterType<ISubjectRepository, SubjectRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<IImageRepository, ImageRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<INoweltyRepository, NoweltyRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<IFileRepository, FileRepository>(new HierarchicalLifetimeManager()); */

			System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}