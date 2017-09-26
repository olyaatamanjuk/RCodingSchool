using RCodingSchool.DI;

namespace RCodingSchool
{
    public static class Bootstrapper
	{
		public static void Initialize()
		{
			DependencyResolverConfig.RegisterType(
				new WebTypeResolver()
			);
		}
	}
}