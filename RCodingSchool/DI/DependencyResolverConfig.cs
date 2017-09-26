using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Linq;

namespace RCodingSchool.DI
{
    public static class DependencyResolverConfig
    {
        private static IUnityContainer _container;

        public static void RegisterType(params IWebTypeResolver[] typeResolvers)
        {
            _container = BuildUnityContainer(typeResolvers);
        }

        public static IUnityContainer BuildUnityContainer(params IWebTypeResolver[] typeResolvers)
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();
            if (typeResolvers != null && typeResolvers.Any())
            {
                foreach (var typeResolver in typeResolvers)
                {
                    typeResolver.RegisterType(container);
                }
            }
            return container;
        }
    }
}