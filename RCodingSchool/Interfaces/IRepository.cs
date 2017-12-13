using System;
using System.Collections.Generic;

namespace StudLine.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
		where TEntity : class 
	{
		TEntity Get(int id);
		IEnumerable<TEntity> GetAll();
		TEntity Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
