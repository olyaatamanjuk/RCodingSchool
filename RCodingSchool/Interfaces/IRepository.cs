using System;
using System.Collections.Generic;

namespace RCodingSchool.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
		where TEntity : class 
	{
		TEntity Get(int id);
		IEnumerable<TEntity> GetAll();
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
		void SaveChanges();
	}
}
