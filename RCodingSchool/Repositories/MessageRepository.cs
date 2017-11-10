using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Linq;

namespace RCodingSchool.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public IQueryable<Message> GetLastMessages(int count)
        {
            return dbContext.Messages.Include("User").OrderBy(s => s.ReceiveTime).Take(count);
        }
    }
}