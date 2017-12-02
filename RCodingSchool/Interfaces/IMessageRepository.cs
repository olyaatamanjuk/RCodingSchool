using RCodingSchool.Models;
using System.Linq;

namespace RCodingSchool.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
		IQueryable<Message> GetLastMessages(int count, string groupName);
	}
}