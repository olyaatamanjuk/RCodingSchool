using RCodingSchool.Interfaces;
using RCodingSchool.Models;

namespace RCodingSchool.Repositories
{
	public class MessageGroupRepository : Repository<MessageGroup>, IMessageGroupRepository
	{
		public MessageGroupRepository(RCodingSchoolContext context)
			: base(context)
		{
		}
	}
}