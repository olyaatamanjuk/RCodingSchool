using StudLine.Models;
using System.Linq;
using StudLine.Interfaces;
using System;
using System.Collections.Generic;

namespace StudLine.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(StudLineContext context)
            : base(context)
        {
        }

		public override News Get(int id)
		{
			return dbContext.News.Include("User").Include("Comments").FirstOrDefault(x => x.Id == id);
		}

		public List<News> GetByMonth(int month)
		{
			return dbContext.News.Where(x => x.Date.Month == month).OrderByDescending(x => x.Date).ToList();
		}
	}
}