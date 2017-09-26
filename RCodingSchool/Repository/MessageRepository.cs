using RCodingSchool.Models;
using RCodingSchool.EF;

namespace RCodingSchool.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}