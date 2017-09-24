using RCodingSchool.UnitOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Repository
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IUnitOfWork UnitOfWork { get; }
		TEntity Get(int id);
		IEnumerable<TEntity> GetAll();
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
