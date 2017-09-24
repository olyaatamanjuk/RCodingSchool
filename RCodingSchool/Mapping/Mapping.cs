using AutoMapper;
using RCodingSchool.Mapping.ModelsVM;
using RCodingSchool.Models;
using RCodingSchool.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Mapping
{
	public class AutoMapperProfile : Profile
	{
	 public AutoMapperProfile()
		{
			CreateMap<User, UserVM>()
			.ForMember(d => d.RememberMe, o => o.Ignore());
			CreateMap<User, UserContext>();
		}
	}
}