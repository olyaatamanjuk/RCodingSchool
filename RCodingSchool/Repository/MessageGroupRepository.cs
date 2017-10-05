using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
	public class MessageGroupRepository : Repository<MessageGroup>, IMessageGroupRepository
	{
		public MessageGroupRepository(RCodingSchoolContext context)
			: base(context)
		{
		}
	}
}