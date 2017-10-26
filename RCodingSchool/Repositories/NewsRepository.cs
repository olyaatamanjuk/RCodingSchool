using RCodingSchool.Models;
using System.Linq;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public override News Get(int id)
        {
            return dbContext.News.Include("NewsAuthor").Include("Comments").FirstOrDefault(x => x.Id == id);
        }
    }
}