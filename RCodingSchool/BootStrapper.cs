using AutoMapper;
using RCodingSchool.DI;
using RCodingSchool.Mapping.ModelsVM;
using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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