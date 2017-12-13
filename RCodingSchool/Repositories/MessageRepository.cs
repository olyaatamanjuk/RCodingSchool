using StudLine.Models;
using StudLine.Interfaces;
using System.Linq;

namespace StudLine.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(StudLineContext context)
            : base(context)
        {
        }

        public IQueryable<Message> GetLastMessages(int count, string groupName)
        {
            return dbContext.Messages.Include("User").Where(x => x.GroupName == groupName ).OrderByDescending(s => s.ReceiveTime).Take(count);
        }
    }
}