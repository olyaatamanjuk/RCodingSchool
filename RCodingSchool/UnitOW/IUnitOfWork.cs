using RCodingSchool.EF;
using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.UnitOW
{
	public interface IUnitOfWork : IDisposable
	{
		RCodingSchoolContext Context { get; }
		void SaveChanges();
		
	}
}