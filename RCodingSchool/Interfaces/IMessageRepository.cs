using StudLine.Models;
using System.Linq;

namespace StudLine.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
		IQueryable<Message> GetLastMessages(int count, string groupName);
	}
}