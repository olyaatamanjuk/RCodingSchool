using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RCodingSchool.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

		public List<Message> GetLastMessages(int count)
		{
			return dbContext.Messages.Include("User").OrderByDescending(s => s.TimeOfSending).Take(count).ToList();
		}
    }
}