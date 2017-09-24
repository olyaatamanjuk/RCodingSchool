using AutoMapper;
using RCodingSchool.Mapping.ModelsVM;
using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Mapping
{
	public class Mapping
	{
		public Mapping()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<User, UserVM>()
					.ForMember(d => d.RememberMe, o => o.Ignore());
			});
		}
	}
}