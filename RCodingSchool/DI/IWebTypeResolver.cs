using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.DI
{
	public interface IWebTypeResolver
	{
		void RegisterType(IUnityContainer container);
	}
}