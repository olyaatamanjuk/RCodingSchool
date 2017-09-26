using System;

namespace RCodingSchool.UnitOW
{
    public interface IUnitOfWork : IDisposable
	{
		void SaveChanges();
	}
}