using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using RCodingSchool.EF;
using RCodingSchool.Repository;
using RCodingSchool.UnitOW;

namespace RCodingSchool.DI
{
	public class WebTypeResolver : IWebTypeResolver
	{
		public void RegisterType(IUnityContainer container)
		{
			container.RegisterType<RCodingSchoolContext>();
			container.RegisterType<IUnitOfWork, UnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

			System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}