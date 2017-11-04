using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
		List<Message> GetLastMessages(int count);
	}
}