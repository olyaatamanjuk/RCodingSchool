using RCodingSchool.EF;
using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.UnitOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly RCodingSchoolContext _dbContext;

		public UnitOfWork(RCodingSchoolContext dbcontext)
		{
			_dbContext = dbcontext;
		}
		public RCodingSchoolContext Context
		{
			get { return _dbContext; }
		}
		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
				disposedValue = true;
			}
		}
		public void Dispose()
		{

			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}