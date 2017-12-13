using StudLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StudLine.Interfaces;

namespace StudLine.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
        protected readonly StudLineContext dbContext;
		private bool disposedValue = false;

		public Repository(StudLineContext context)
        {
            dbContext = context;
        }

        public virtual TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					dbContext.Dispose();
				}
			}
			this.disposedValue = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
