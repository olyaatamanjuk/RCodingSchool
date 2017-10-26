using RCodingSchool.Models;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}