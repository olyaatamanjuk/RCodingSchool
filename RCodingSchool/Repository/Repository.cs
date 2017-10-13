﻿using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCodingSchool.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
        protected readonly RCodingSchoolContext dbContext;
		private bool disposedValue = false;

		public Repository(RCodingSchoolContext context)
        {
            dbContext = context;
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
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

		public void SaveChanges()
		{
			dbContext.SaveChanges();
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
